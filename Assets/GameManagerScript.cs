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

    //1ブロック
    //2敵専用のブロック
    //4コイン
    //5アイテム

    //コインは合計20個

    //マップ(ステージ)
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

        //ブロック描画
        for (int x = 0; x < 40; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                position.x = x;
                position.y = -y + 5;

                //通常ブロック
                if (map[y, x] == 1)
                {
                    Instantiate(block, position, Quaternion.identity);
                }
                //敵専用ブロック
                if (map[y, x] == 2)
                {
                    Instantiate(block, position, Quaternion.identity);
                }
                //ゴール
                //if (map[y, x] == 3)
                //{
                //    goal.transform.position = position;
                //
                //    //GoalParticle.transform.position = position;
                //}
                //コイン
                if (map[y, x] == 4)
                {
                    Instantiate(coin, position, Quaternion.identity);
                }

                //アイテム(青)
                if(map[y, x] == 5)
                {
                    Instantiate(Item,position, Quaternion.identity);
                }
            }
        }

        //背景
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
        
        //コインに当たるとスコアが増える 表示
        scoreText.text = "Score" + score;


    }
}
