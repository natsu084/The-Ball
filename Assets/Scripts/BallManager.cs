using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ボールが何かのコリジョンに衝突
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "OutArea") {
            //「アウトエリア」に衝突
            //ゲームマネージャーを取得
            GameObject gameManager = GameObject.Find("GameManager");
            //リトライ
            gameManager.GetComponent<GameManager>().PushRetryButton();
        }
    }

    //ボールが何かのトリガーに衝突
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "ClearArea") {
            //「クリアエリア」に入った
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<GameManager>().StageClear();
        }
    }
}
