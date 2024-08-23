using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SelectPlayer : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;

    float moveSpeed = 4f;

    //ステージブロックとの当たり判定
    private void OnCollisionEnter(Collision collision)
    {
        //ステージ1
        if(collision.gameObject.tag == "stage1Tag")
        {
            //左のブロックに当たるとステージ1に飛ぶ
            SceneManager.LoadScene("SampleScene");
        }

        //ステージ2
        if(collision.gameObject.tag == "stage2Tag")
        {
            SceneManager.LoadScene("SecondScene");
        }

        //ステージ3
        if(collision.gameObject.tag == "stage3Tag")
        {
            SceneManager.LoadScene("ThirdScene");
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

        if (Input.GetKey(KeyCode.D))//右移動
        {
            v.x = moveSpeed;
            transform.rotation = Quaternion.Euler(0, 90, 0);

            animator.SetBool("move", true);
        }
        else if (Input.GetKey(KeyCode.A))//左移動
        {
            v.x = -moveSpeed;
            transform.rotation = Quaternion.Euler(0, -90, 0);

            animator.SetBool("move", true);
        }
        else if (Input.GetKey(KeyCode.W))//上移動
        {
            v.z = moveSpeed;
            transform.rotation = Quaternion.Euler(0, 0, 0);

            animator.SetBool("move", true);
        }
        else if (Input.GetKey(KeyCode.S))//下移動
        {
            v.z = -moveSpeed;
            transform.rotation = Quaternion.Euler(0, 180, 0);

            animator.SetBool("move", true);
        }
        else
        {
            v.x = 0;
            v.z = 0;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("move", false);

        }

        rb.velocity = v;

    }
}
