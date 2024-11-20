using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kariPlayerSc : MonoBehaviour
{
    public Rigidbody rb;

    //�F��ς��邽�߂Ɏg������
    public GameObject Item;
    public Color Itemcolor;
    public GameObject bullet;

    float moveSpeed = 4f;
    float jampspeed = 6f;

    int bulletTimer = 0;
    
    //�W�����v�̃t���O
    private bool isJamp;

    //�ϐg�Ɏg���t���O
    public static bool isChange = false;
    

    //�F�𔒂ɕς���֐�
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

    private void FixedUpdate()//�e��������
    {
        if(isChange == true)
        {
            if (bulletTimer == 0)
            {
                if (Input.GetKey(KeyCode.K))//����
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

        //�G�Ɠ�����ƈړ��ł��Ȃ��Ȃ�(�Q�[���I�[�o�[�ɂȂ邩��)
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

            //�W�����v����
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

            
            //�{�^���������Ǝ��Ԃ��~�܂�
            if (Input.GetKey(KeyCode.P))
            {
                //GameManagerScript.score += 1;

                //���Ԃ��~�߂�
                Time.timeScale = 0;
            }

            //���Ԃ����ɖ߂�
            if(Input.GetKey(KeyCode.S))
            {
                //���Ԃ𓮂���
                Time.timeScale = 1.0f; ;
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //�R�C�������ƃR�C���������ăX�R�A��������
        if (other.gameObject.tag == "Coin")
        {
            //�R�C����������
            other.gameObject.SetActive(false);
            //�X�R�A��������(�X�e�[�W1)
            GameManagerScript.score += 1;
            //�X�e�[�W2
            SecondGameManager.score += 1;
            //�X�e�[�W3
            ThirdGameManagerScript.score += 1;

        }

        //�A�C�e���Ƃ̔���(�������(isChange��true�ɂȂ�F���ς��)
        if (other.gameObject.tag == "item")
        {
            //�A�C�e����������
            other.gameObject.SetActive(false);

            //�F�ς���
            isChange = true;
            GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}
