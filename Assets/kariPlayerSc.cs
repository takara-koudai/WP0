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

    float moveSpeed = 4f;
    float jampspeed = 6f;

    //ジャンプのフラグ
    private bool isJamp;

    //変身に使うフラグ
    public bool isChange = false;

    private void OnCollisionStay(Collision collision)
    {
        isJamp = true;

        //animator.SetBool("jamp", false);
    }

    private void OnCollisionExit(Collision collision)
    {
        isJamp = false;
    }

    // Start is called before the first frame update
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

            //色変える
            float dx = Input.GetAxis("Horizontal") * Time.deltaTime * 3;
            float dy = Input.GetAxis("Vertical") * Time.deltaTime * 3;
            //transform.position = new Vector3(transform.position.x + dx, 0, transform.position.z + dy);

            //アイテムを取るとその姿のままでいる
            if(isChange == true)
            {
                //Item = other.gameObject;
                Itemcolor = Item.GetComponent<Renderer>().material.color;
                GetComponent<Renderer>().material.color = Itemcolor;
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

        //アイテムとの判定(当たると色が変わる)
        if (other.gameObject.tag == "item")
        {
            other.gameObject.SetActive(false);

            isChange = true;

            //色変える
            Item = other.gameObject;
            Itemcolor = Item.GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = Itemcolor;
        }
    }
}
