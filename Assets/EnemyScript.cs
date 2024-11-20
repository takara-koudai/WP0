using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{

    //�Q�[���I�[�o�[�p�e�L�X�g
    public GameObject gameOverText;

    public GameObject tartget;

    public static bool isGameOver = false;

    public Rigidbody rb;

    
    //�G�̔���
    float EnemyRightSpeed = 1.3f;
    float EnemyLeftSpeed = -1.3f;
    public static bool moveRight = true;
    public static bool moveLeft = false;



    //����������ɂ���Č��ʂ�ς���
    //�O
    //public float frontDamage = 10f;
    //public bool frontFlag = false;

    //��
    //public float TopDamage = 10f;
    //public bool TopFlag = false;

    //���
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

        if (other.gameObject.tag == "kariPlayer")//�Փ˂�����G������
        {

            //�v���C���[��߂̏�Ԃɖ߂�
            //kariPlayerSc.isChange = false;

            //�����ɓ�����ƓG�̐F���ς��R���
            if (other.gameObject.tag == "kariPlayer")
            {
                // �������g�̐F��Ԃɕς���
                GetComponent<Renderer>().material.color = Color.red;
            }

            //������Ԃ̎��ɓG�ɓ�����ƃQ�[���I�[�o�[�ɂȂ�
            //if (kariPlayerSc.isChange == false)
            //{
            //    gameOverText.SetActive(true);
            //    //isGameOver = true;//�v���C���[�������Ȃ��Ȃ�
            //    EnemyScript.isGameOver = true;
            //}
        }
        
        //�y�ǂɓ�����Ɣ��˂���
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

        //�G�̈ړ�(�m�R�m�R�݂����ɔ��˂���)
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


        //�^�C�g���ɖ߂�(�Q�[���I�[�o�[�̕������o����)
        if (isGameOver == true)
        {
            //�G���^�[�������ƃ^�C�g���ɖ߂�
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("TitleScene");

                //�X�R�A���Z�b�g
                GameManagerScript.score = 0;

                //���S�t���O��߂�
                isGameOver = false;
            }
        }
    }

    
}
