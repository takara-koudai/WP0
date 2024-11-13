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
    private NavMeshAgent navMeshAgent;

    //�e��������
    //int count = 0;
    int enemybulletTimer = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "kariPlayer")
        {

            //�v���C���[�����̏�Ԃ�
            kariPlayerSc.isChange = false;

            //������ԂœG�ɓ�����ƃQ�[���I�[�o�[
            if (kariPlayerSc.isChange == false)
            {
                gameOverText.SetActive(true);
                isGameOver = true;
            }

        }
    }

    private void FixedUpdate()
    {
        if(kariPlayerSc.enemyBulletflag == true)//�G���e��������
        {
            if(enemybulletTimer == 0)
            {
                enemybulletTimer++;

                Vector3 position = transform.position;

                position.y += 1f;

                Instantiate(bullet, position, Quaternion.identity);
            }
            else
            {
                enemybulletTimer++;
                if(enemybulletTimer > 5)
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
