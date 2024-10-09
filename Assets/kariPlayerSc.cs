using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kariPlayerSc : MonoBehaviour
{
    public Rigidbody rb;

    float moveSpeed = 4f;
    float jampspeed = 6f;

    private bool isJamp;

    private void OnCollisionStay(Collision collision)
    {
        isJamp = true;

        //animator.SetBool("jamp", false);
    }

    private void OnCollisionExit(Collision collision)
    {
        isJamp = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            //スコアが増える(ステージ1)
            GameManagerScript.score += 1;
            //ステージ2
            SecondGameManager.score += 1;
            //ステージ3
            ThirdGameManagerScript.score += 1;



        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = rb.velocity;

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
    }
}
