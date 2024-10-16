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

    float moveSpeed = 4f;
    float jampspeed = 6f;

    //�W�����v�̃t���O
    private bool isJamp;

    //�ϐg�Ɏg���t���O
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

            //�F�ς���
            float dx = Input.GetAxis("Horizontal") * Time.deltaTime * 3;
            float dy = Input.GetAxis("Vertical") * Time.deltaTime * 3;
            //transform.position = new Vector3(transform.position.x + dx, 0, transform.position.z + dy);

            //�A�C�e�������Ƃ��̎p�̂܂܂ł���
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

        //�A�C�e���Ƃ̔���(������ƐF���ς��)
        if (other.gameObject.tag == "item")
        {
            other.gameObject.SetActive(false);

            isChange = true;

            //�F�ς���
            Item = other.gameObject;
            Itemcolor = Item.GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = Itemcolor;
        }
    }
}
