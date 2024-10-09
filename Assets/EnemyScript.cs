using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    //�Q�[���I�[�o�[�p�e�L�X�g
    public GameObject gameOverText;

    public static bool isGameOver = false;
    

    public Rigidbody rb;

    //int timer = 0;

    GameManagerScript gameManagerScript;

    float EnemySpeed = 1f;

    //GameManagerScript gameM;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "kariPlayer")//�Փ˂�����G������
        {

            //������������
            Destroy(other.gameObject);
            //�Q�[���I�[�o�[�̃e�L�X�g���o��
            gameOverText.SetActive(true);
            isGameOver = true;

            //�G��������
            Destroy(this.gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //�G�̈ړ�
        Vector3 i = rb.velocity;

        i.x = EnemySpeed;

        rb.velocity = i;

        //�^�C�}�[�̃J�E���g�𑝂₷(5�b�܂�)
        //timer++;
        //if (timer >= 100)//���΂Ɉړ�������
        //{

        //    rb.velocity *= -1;
        //    //�^�C�}�[�����Z�b�g
        //    timer = 0;
        //}

        //�t�̈ړ�
        //if(timer >= 600)//�J�E���g��10�b�i�񂾂�
        //{
        //    i *= -1;

        //    //�^�C�}�[�����Z�b�g
        //    timer = 0;
        //}


        //�^�C�g���ɖ߂�
        if(isGameOver == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("TitleScene");

                //�X�R�A���Z�b�g
                //score = 0;
                GameManagerScript.score = 0;
            }
        }
    }
}
