using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class DokanStageManager : MonoBehaviour
{

    public GameObject block;
    public TextMeshProUGUI scoreText;
    public GameObject goal;
    public GameObject coin;

    public static int score = 0;

    

    //2�R�C��
    //3�S�[��

    //�}�b�v(�X�e�[�W)
    int[,] map =
    {
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1},
        {1,0,0,2,2,0,0,0,0,0, 0,0,2,0,0,0,0,0,2,1},
        {1,0,0,1,1,0,0,0,0,0, 0,0,1,1,0,0,0,0,3,1},
        {1,0,0,0,0,0,2,0,0,0, 0,0,0,0,0,0,0,0,1,1},
        {1,0,0,0,0,0,1,1,0,0, 2,0,0,0,0,2,2,0,0,1},
        {1,0,0,0,0,0,0,0,0,0, 1,0,0,0,0,1,1,0,0,1},
        {1,0,0,2,0,0,0,0,2,0, 0,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0, 0,0,1,0,0,0,0,2,0,1},
        {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1},
    };

    // Start is called before the first frame update
    void Start()
    {
        int lenY = map.GetLength(0);
        int lenX = map.GetLength(1);

        Vector3 position = Vector3.zero;

        //�u���b�N�`��
        for (int x = 0; x < 20; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                position.x = x;
                position.y = -y + 5;

                //�ʏ�u���b�N
                if (map[y, x] == 1)
                {
                    Instantiate(block, position, Quaternion.identity);
                }
                //�R�C��
                if (map[y, x] == 2)
                {
                    Instantiate(coin, position, Quaternion.identity);
                }
                //�S�[��
                if (map[y, x] == 3)
                {
                    goal.transform.position = position;

                    //�p�[�e�B�N��(�]�T����������o��)
                    //GoalParticle.transform.position = position;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        //�S�[������Space�������ƃ^�C�g���֖߂�(�N���A��)
        if (GoalScript.isGameClear == true)
        {
            //�X�y�[�X�������ƃ^�C�g����
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("TitleScene");
                //�X�R�A���Z�b�g
                score = 0;
                GameManagerScript.score = 0;
            }
        }

        

        scoreText.text = "Score" + GameManagerScript.score;
    }
}
