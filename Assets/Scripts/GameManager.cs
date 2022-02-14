using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int StageNo;             //ステージナンバー

    public bool isBallMoving;       //ボールが移動中か否か

    public GameObject ballPrefeb;   //ボールプレハブ
    public GameObject ball;         //ボールオブジェクト

    public GameObject goButton;     //ボタン：ゲーム開始
    public GameObject retryButton;  //ボタン：リトライ
    public GameObject clearText;    //テキスト：クリア

    public AudioClip clearSE;       //効果音：クリア
    private AudioSource audioSource;//オーディオソース                               //

    // Start is called before the first frame update
    void Start()
    {
        retryButton.SetActive (false); //リトライボタンを非表示
        isBallMoving = false;          //ボールは「移動中ではない」

        //オーディオソースを取得
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    //バックボタンを押した
    public void PushBackButton()
    {
        GobackStageSelect();
    }

    //ステージクリア処理
    public void StageClear() {
        audioSource.PlayOneShot(clearSE);  //クリア音再生
        //セーブデータ更新
        if (PlayerPrefs.GetInt("CLEAR", 0) < StageNo) {
            //セーブされているステージナンバーより今のステージナンバーが大きければ
            PlayerPrefs.SetInt("CLEAR", StageNo);  //ステージナンバーを記録
        }
        
        clearText.SetActive(true);         //クリア表示
        retryButton.SetActive(false);      //リトライボタン非表示

        //3秒後に自動的にステージセレクト画面へ
        Invoke("GoBackStageSelect", 3.0f);
    }

    //移動処理
    void GobackStageSelect() {
        SceneManager.LoadScene("StageSelectScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //GOボタンを押した
    public void PushGoButton() {
        //ボールの重力を有効化
        Rigidbody2D rd = ball.GetComponent<Rigidbody2D>();
        rd.isKinematic = false;

        retryButton.SetActive (true);  //リトライボタンを表示 
        goButton.SetActive (false);    //GOボタンを非表示
        isBallMoving = true;           //ボールは「移動中」
    }

    //RETRYボタンを押した
    public void PushRetryButton()　{
        Destroy (ball);               //ボールオブジェクトを削除

        //プレハブより新しいボールオブジェクトを作成
        ball = (GameObject)Instantiate(ballPrefeb);

        retryButton.SetActive(false);  //リトライボタンを非表示 
        goButton.SetActive(true);    //GOボタンを表示
        isBallMoving = false;          //ボールは「移動中ではない」
    }
}
