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

    //�X�e�[�W�u���b�N�Ƃ̓����蔻��
    private void OnCollisionEnter(Collision collision)
    {
        //�X�e�[�W1
        if(collision.gameObject.tag == "stage1Tag")
        {
            //���̃u���b�N�ɓ�����ƃX�e�[�W1�ɔ��
            SceneManager.LoadScene("SampleScene");
        }

        //�X�e�[�W2
        if(collision.gameObject.tag == "stage2Tag")
        {
            SceneManager.LoadScene("SecondScene");
        }

        //�X�e�[�W3
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

        if (Input.GetKey(KeyCode.D))//�E�ړ�
        {
            v.x = moveSpeed;
            transform.rotation = Quaternion.Euler(0, 90, 0);

            animator.SetBool("move", true);
        }
        else if (Input.GetKey(KeyCode.A))//���ړ�
        {
            v.x = -moveSpeed;
            transform.rotation = Quaternion.Euler(0, -90, 0);

            animator.SetBool("move", true);
        }
        else if (Input.GetKey(KeyCode.W))//��ړ�
        {
            v.z = moveSpeed;
            transform.rotation = Quaternion.Euler(0, 0, 0);

            animator.SetBool("move", true);
        }
        else if (Input.GetKey(KeyCode.S))//���ړ�
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
