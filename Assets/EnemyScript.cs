using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    //ゲームオーバー用テキスト
    public GameObject gameOverText;

    public static bool isGameOver = false;
    

    public Rigidbody rb;

    //int timer = 0;

    GameManagerScript gameManagerScript;

    float EnemySpeed = 1f;

    //GameManagerScript gameM;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "kariPlayer")//衝突したら敵を消す
        {

            //自分が消える
            Destroy(other.gameObject);
            //ゲームオーバーのテキストを出す
            gameOverText.SetActive(true);
            isGameOver = true;

            //敵が消える
            Destroy(this.gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //敵の移動
        Vector3 i = rb.velocity;

        i.x = EnemySpeed;

        rb.velocity = i;

        //タイマーのカウントを増やす(5秒まで)
        //timer++;
        //if (timer >= 100)//反対に移動させる
        //{

        //    rb.velocity *= -1;
        //    //タイマーをリセット
        //    timer = 0;
        //}

        //逆の移動
        //if(timer >= 600)//カウントが10秒進んだら
        //{
        //    i *= -1;

        //    //タイマーをリセット
        //    timer = 0;
        //}


        //タイトルに戻る
        if(isGameOver == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("TitleScene");

                //スコアリセット
                //score = 0;
                GameManagerScript.score = 0;
            }
        }
    }
}
