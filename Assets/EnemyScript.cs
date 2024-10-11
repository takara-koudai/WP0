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
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "kariPlayer")//衝突したら敵を消す
        {

            //自分が消える
            //Destroy(other.gameObject);
            //ゲームオーバーのテキストを出す

            gameOverText.SetActive(true);

            isGameOver = true;

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
