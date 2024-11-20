using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kariPlayerSc : MonoBehaviour
{
    public Rigidbody rb;

    //色を変えるために使うもの
    public GameObject Item;
    public Color Itemcolor;
    public GameObject bullet;

    float moveSpeed = 4f;
    float jampspeed = 6f;

    int bulletTimer = 0;
    
    //ジャンプのフラグ
    private bool isJamp;

    //変身に使うフラグ
    public static bool isChange = false;
    

    //色を白に変える関数
    public void ChangeColorWhite(Color newcolor)
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    private void OnCollisionStay(Collision collision)
    {
        isJamp = true;

        //animator.SetBool("jamp", false);
    }

    private void OnCollisionExit(Collision collision)
    {
        isJamp = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    // Start is called before the first frame update

    private void FixedUpdate()//弾を撃つ処理
    {
        if(isChange == true)
        {
            if (bulletTimer == 0)
            {
                if (Input.GetKey(KeyCode.K))//発射
                {
                    bulletTimer = 1;

                    Vector3 position = transform.position;
                    position.y += 0.2f;
                    position.z += 0.2f;
                    position.x += 1.0f;

                    Instantiate(bullet, position, Quaternion.identity);
                }
            }
            else
            {
                bulletTimer++;
                if (bulletTimer > 20)
                {
                    bulletTimer = 0;
                }
            }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = rb.velocity;

        //敵と当たると移動できなくなる(ゲームオーバーになるから)
        if (EnemyScript.isGameOver == false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                v.x = moveSpeed;
                transform.rotation = Quaternion.Euler(0, 90, 0);

                //animator.SetBool("walk", true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                v.x = -moveSpeed;
                transform.rotation = Quaternion.Euler(0, -90, 0);

                //animator.SetBool("walk", true);
            }
            else
            {
                v.x = 0;
                //animator.SetBool("walk", false);
            }

            //ジャンプ処理
            if (isJamp && Input.GetKey(KeyCode.Space))
            {
                if (isJamp)
                {
                    //animator.SetBool("jamp", true);
                }
                else
                {
                    // animator.SetBool("jamp", false);
                }

                v.y = jampspeed;
            }

            rb.velocity = v;

            
            //ボタンを押すと時間が止まる
            if (Input.GetKey(KeyCode.P))
            {
                //GameManagerScript.score += 1;

                //時間を止める
                Time.timeScale = 0;
            }

            //時間を元に戻す
            if(Input.GetKey(KeyCode.S))
            {
                //時間を動かす
                Time.timeScale = 1.0f; ;
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //コインを取るとコインが消えてスコアが増える
        if (other.gameObject.tag == "Coin")
        {
            //コインが消える
            other.gameObject.SetActive(false);
            //スコアが増える(ステージ1)
            GameManagerScript.score += 1;
            //ステージ2
            SecondGameManager.score += 1;
            //ステージ3
            ThirdGameManagerScript.score += 1;

        }

        //アイテムとの判定(当たると(isChangeがtrueになり色が変わる)
        if (other.gameObject.tag == "item")
        {
            //アイテムが消える
            other.gameObject.SetActive(false);

            //色変える
            isChange = true;
            GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}
