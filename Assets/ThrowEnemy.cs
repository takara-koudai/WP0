using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ThrowEnemy : MonoBehaviour
{

    //ゲームオーバー用テキスト
    public GameObject gameOverText;
    public GameObject bullet;

    public static bool isGameOver = false;

    public Rigidbody rb;

    GameManagerScript gameManagerScript;

    //一定範囲に入ると
    private NavMeshAgent navMeshAgent;

    //弾を撃つ処理
    //int count = 0;
    int enemybulletTimer = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "kariPlayer")
        {

            //プレイヤーを元の状態に
            kariPlayerSc.isChange = false;

            //初期状態で敵に当たるとゲームオーバー
            if (kariPlayerSc.isChange == false)
            {
                gameOverText.SetActive(true);
                isGameOver = true;
            }

        }
    }

    private void FixedUpdate()
    {
        if(kariPlayerSc.enemyBulletflag == true)//敵が弾を撃つ処理
        {
            if(enemybulletTimer == 0)
            {
                enemybulletTimer++;

                Vector3 position = transform.position;

                position.y += 1f;

                Instantiate(bullet, position, Quaternion.identity);
            }
            else
            {
                enemybulletTimer++;
                if(enemybulletTimer > 5)
                {
                    enemybulletTimer = 0;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

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
