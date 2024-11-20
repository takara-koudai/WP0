using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManagerScript : MonoBehaviour
{

    public GameObject block;
    public GameObject block2;
    public GameObject goal;
    public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI timeText;
    public GameObject coin;
    public GameObject Item;

    public static int score = 0;

    //1�u���b�N
    //2�G��p�̃u���b�N
    //4�R�C��
    //5�A�C�e��

    //�R�C���͍��v20��

    //�}�b�v(�X�e�[�W)
    int[,] map =
    {
        {1,0,0,1,1,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,4,0, 0,0,0,0,0,4,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,1,1,0,0,4,1},
        {1,0,0,1,1,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,4,0,0, 0,0,0,0,0,0,0,0,4,1},
        {1,0,0,0,0,0,0,5,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,4,0,0,0,1,1},
        {1,0,0,0,0,0,0,5,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 1,1,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,1,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,1,1,0,0,1},
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,1,0,0, 0,0,0,4,1,0,0,4,0,1},
        {1,0,0,0,0,0,0,0,0,0, 0,0,1,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,4,1},
        {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,0,1, 1,1,1,1,0,1,1,1,1,1},
    };

    // Start is called before the first frame update
    void Start()
    {
        int lenY = map.GetLength(0);
        int lenX = map.GetLength(1);

        Vector3 position = Vector3.zero;

        //�u���b�N�`��
        for (int x = 0; x < 40; x++)
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
                //�G��p�u���b�N
                if (map[y, x] == 2)
                {
                    Instantiate(block, position, Quaternion.identity);
                }
                //�S�[��
                //if (map[y, x] == 3)
                //{
                //    goal.transform.position = position;
                //
                //    //GoalParticle.transform.position = position;
                //}
                //�R�C��
                if (map[y, x] == 4)
                {
                    Instantiate(coin, position, Quaternion.identity);
                }

                //�A�C�e��(��)
                if(map[y, x] == 5)
                {
                    Instantiate(Item,position, Quaternion.identity);
                }
            }
        }

        //�w�i
        /*for(int y = 0;y < lenY; y++)
        {
            for(int x = 0;x < 1280; x++) 
            {
                position.x = x;
                position.y = -y + 5;
                position.z = 3;
                Instantiate(block2, position, Quaternion.identity);
            }
        }*/


        //GoalScript.isGameClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //�R�C���ɓ�����ƃX�R�A�������� �\��
        scoreText.text = "Score" + score;


    }
}
