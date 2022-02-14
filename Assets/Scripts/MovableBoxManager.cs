using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBoxManager : MonoBehaviour
{

    private GameObject gameManager;        //�Q�[���}�l�[�W���[

    // Start is called before the first frame update
    void Start()
    {
        //�Q�[���}�l�[�W���[���擾
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�h���b�O����
    void OnMouseDrag() {
        if (gameManager.GetComponent<GameManager>().isBallMoving == false) {
            //�ʒu���擾
            float x = Input.mousePosition.x;
            float y = Input.mousePosition.y;
            float z = 100.0f;
            //�ʒu��ϊ����ăI�u�W�F�N�g�̍��W�Ɏw��
             transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, z));
        }
    }
}
