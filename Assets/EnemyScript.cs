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

    
    GameManagerScript gameManagerScript;

    float EnemySpeed = 1f;
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "kariPlayer")//�Փ˂�����G������
        {

            //������������
            //Destroy(other.gameObject);
            //�Q�[���I�[�o�[�̃e�L�X�g���o��

            gameOverText.SetActive(true);

            isGameOver = true;

            //�G��������
            //Destroy(this.gameObject);
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

        //�^�C�g���ɖ߂�(�Q�[���I�[�o�[�̕������o����)
        if (isGameOver == true)
        {
            //�G���^�[�������ƃ^�C�g���ɖ߂�
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("TitleScene");

                //�X�R�A���Z�b�g
                //score = 0;
                GameManagerScript.score = 0;

                //���S�t���O��߂�
                isGameOver = false;
            }
        }
    }
}
