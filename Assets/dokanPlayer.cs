using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dokanPlayer : MonoBehaviour
{

    public Rigidbody rb;
    //public Animator animator;

    float moveSpeed = 4f;
    float jampspeed = 8f;

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

    //�R�C���̓����蔻��
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")//�R�C���ɓ�����ƃR�C����������
        {
            other.gameObject.SetActive(false);
            //�y�ǂ̃X�e�[�W�ł��X�R�A�������p���ŃX�R�A��������
            GameManagerScript.score += 1;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //���ʂ�����
        transform.rotation = Quaternion.Euler(0, 180, 0);
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

        //�W�����v����
        if (isJamp && Input.GetKey(KeyCode.Space))
        {
            if (isJamp)
            {
                //animator.SetBool("jamp", true);
            }
            else
            {
                //animator.SetBool("jamp", false);
            }

            v.y = jampspeed;
        }

        rb.velocity = v;
    }
}
