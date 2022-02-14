using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int StageNo;             //�X�e�[�W�i���o�[

    public bool isBallMoving;       //�{�[�����ړ������ۂ�

    public GameObject ballPrefeb;   //�{�[���v���n�u
    public GameObject ball;         //�{�[���I�u�W�F�N�g

    public GameObject goButton;     //�{�^���F�Q�[���J�n
    public GameObject retryButton;  //�{�^���F���g���C
    public GameObject clearText;    //�e�L�X�g�F�N���A

    public AudioClip clearSE;       //���ʉ��F�N���A
    private AudioSource audioSource;//�I�[�f�B�I�\�[�X                               //

    // Start is called before the first frame update
    void Start()
    {
        retryButton.SetActive (false); //���g���C�{�^�����\��
        isBallMoving = false;          //�{�[���́u�ړ����ł͂Ȃ��v

        //�I�[�f�B�I�\�[�X���擾
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    //�o�b�N�{�^����������
    public void PushBackButton()
    {
        GobackStageSelect();
    }

    //�X�e�[�W�N���A����
    public void StageClear() {
        audioSource.PlayOneShot(clearSE);  //�N���A���Đ�
        //�Z�[�u�f�[�^�X�V
        if (PlayerPrefs.GetInt("CLEAR", 0) < StageNo) {
            //�Z�[�u����Ă���X�e�[�W�i���o�[��荡�̃X�e�[�W�i���o�[���傫�����
            PlayerPrefs.SetInt("CLEAR", StageNo);  //�X�e�[�W�i���o�[���L�^
        }
        
        clearText.SetActive(true);         //�N���A�\��
        retryButton.SetActive(false);      //���g���C�{�^����\��

        //3�b��Ɏ����I�ɃX�e�[�W�Z���N�g��ʂ�
        Invoke("GoBackStageSelect", 3.0f);
    }

    //�ړ�����
    void GobackStageSelect() {
        SceneManager.LoadScene("StageSelectScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //GO�{�^����������
    public void PushGoButton() {
        //�{�[���̏d�͂�L����
        Rigidbody2D rd = ball.GetComponent<Rigidbody2D>();
        rd.isKinematic = false;

        retryButton.SetActive (true);  //���g���C�{�^����\�� 
        goButton.SetActive (false);    //GO�{�^�����\��
        isBallMoving = true;           //�{�[���́u�ړ����v
    }

    //RETRY�{�^����������
    public void PushRetryButton()�@{
        Destroy (ball);               //�{�[���I�u�W�F�N�g���폜

        //�v���n�u���V�����{�[���I�u�W�F�N�g���쐬
        ball = (GameObject)Instantiate(ballPrefeb);

        retryButton.SetActive(false);  //���g���C�{�^�����\�� 
        goButton.SetActive(true);    //GO�{�^����\��
        isBallMoving = false;          //�{�[���́u�ړ����ł͂Ȃ��v
    }
}
