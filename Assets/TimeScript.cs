using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{

    public GameObject gameOverText;

    public static bool isGameOver = false;

    //��������
    [SerializeField] int timeLimit;

    //�^�C�}�[�p�̃e�L�X�g
    [SerializeField] Text timerText;

    //�o�ߎ��ԗp�ϐ�
    float time;

    // Use this for initialization
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //���̉��Ń^�C�}�[�����炷
        time += Time.deltaTime;

        int Alltime = timeLimit - (int)time;

        timerText.text = $"�̂���F{Alltime.ToString("D3")}";


        //�c��^�C����0�ɂȂ�����Q�[���I�[�o�[
        if(Alltime <= 0)
        {
            gameOverText.SetActive(true);

            isGameOver = true;

            //GoalScript.isGameClear = true;
        }

        //space�������ƃ^�C�g���ɖ߂�
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
