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

    
    GameManagerScript gameManagerScript;

    float EnemySpeed = 1f;

    int count = 0;


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "kariPlayer")//衝突したら敵を消す
        {

            //自分が消える
            //Destroy(other.gameObject);

           

            //プレイヤーを戻の状態に戻す
            kariPlayerSc.isChange = false;

            //初期状態の時に敵に当たるとゲームオーバーになる
            if(kariPlayerSc.isChange == false)
            {
                gameOverText.SetActive(true);
                isGameOver = true;//プレイヤーが動かなくなる
            }

            //敵が消える
            //Destroy(this.gameObject);
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


        count++;

        //敵を反射させる
        if(count >= 200)
        {
            i.x *= -1;
            count = 0;
        }

        //タイトルに戻る(ゲームオーバーの文字が出たら)
        if (isGameOver == true)
        {
            //エンターを押すとタイトルに戻る
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("TitleScene");

                //スコアリセット
                //score = 0;
                GameManagerScript.score = 0;

                //死亡フラグを戻す
                isGameOver = false;
            }
        }
    }
}
