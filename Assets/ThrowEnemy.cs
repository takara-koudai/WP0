using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ThrowEnemy : MonoBehaviour
{

    //�Q�[���I�[�o�[�p�e�L�X�g
    public GameObject gameOverText;
    public GameObject bullet;

    public static bool isGameOver = false;

    public Rigidbody rb;

    GameManagerScript gameManagerScript;

    //���͈͂ɓ����
    

    //�e��������
    //int count = 0;
    int enemybulletTimer = 0;
    

    bool isb = true;

    private void OnCollisionEnter(Collision collision)
    {
        //�G�{�̂Ǝ��������������Ƃ��̔���
        if(collision.gameObject.tag == "kariPlayer")
        {
            //�v���C���[�����̏�Ԃ�
            kariPlayerSc.isChange = false;

            //������ԂœG�ɓ�����ƃQ�[���I�[�o�[
            if (kariPlayerSc.isChange == false)
            {
                gameOverText.SetActive(true);
                //isGameOver = true;

                EnemyScript.isGameOver = true;
            }
        }
    }

    private void FixedUpdate()
    {
        //kariPlayerSc.enemyBulletflag == true;
        if(isb == true)//�G���e��������
        {
            if(enemybulletTimer == 0)
            {
                enemybulletTimer++;

                Vector3 position = transform.position;

                position.y += 0.6f;
                position.z += 0.2f;
                position.x += 1.5f;

                Instantiate(bullet, position, Quaternion.identity);
            }
            else
            {
                enemybulletTimer++;
                if(enemybulletTimer > 30)
                {
                    enemybulletTimer = 0;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

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
