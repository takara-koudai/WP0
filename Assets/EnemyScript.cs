using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{

    //ゲームオーバー用テキスト
    public GameObject gameOverText;

    public GameObject tartget;

    public static bool isGameOver = false;

    public Rigidbody rb;

    
    //敵の反射
    float EnemyRightSpeed = 1.3f;
    float EnemyLeftSpeed = -1.3f;
    public static bool moveRight = true;
    public static bool moveLeft = false;



    //当たる方向によって効果を変える
    //前
    //public float frontDamage = 10f;
    //public bool frontFlag = false;

    //上
    //public float TopDamage = 10f;
    //public bool TopFlag = false;

    //後ろ
    //public float BackDamage = 10f;
    //public bool BackFlag = false;

    
    private void OnCollisionEnter(Collision other)
    {
        if (kariPlayerSc.isChange == true)
        {
            if (other.gameObject.tag == "kariPlayer")
            {
                kariPlayerSc.isChange = false;
                tartget.GetComponent<kariPlayerSc>().ChangeColorWhite(Color.white);
            }
        }

        if (other.gameObject.tag == "kariPlayer")//衝突したら敵を消す
        {

            //プレイヤーを戻の状態に戻す
            //kariPlayerSc.isChange = false;

            //自分に当たると敵の色が変わり蹴れる
            if (other.gameObject.tag == "kariPlayer")
            {
                // 自分自身の色を赤に変える
                GetComponent<Renderer>().material.color = Color.red;
            }

            //初期状態の時に敵に当たるとゲームオーバーになる
            //if (kariPlayerSc.isChange == false)
            //{
            //    gameOverText.SetActive(true);
            //    //isGameOver = true;//プレイヤーが動かなくなる
            //    EnemyScript.isGameOver = true;
            //}
        }
        
        //土管に当たると反射する
        if(other.gameObject.tag == "Dokan")
        {
            moveRight = true;
            moveLeft = false;
        }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //敵の移動(ノコノコみたいに反射する)
        if (moveRight == true)
        {
            Vector3 i = rb.velocity;

            i.x = EnemyRightSpeed;

            rb.velocity = i;
        }

        if (moveLeft == true)
        {
            Vector3 L = rb.velocity;
            L.x = EnemyLeftSpeed;
            rb.velocity = L;
        }


        //タイトルに戻る(ゲームオーバーの文字が出たら)
        if (isGameOver == true)
        {
            //エンターを押すとタイトルに戻る
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("TitleScene");

                //スコアリセット
                GameManagerScript.score = 0;

                //死亡フラグを戻す
                isGameOver = false;
            }
        }
    }

    
}
