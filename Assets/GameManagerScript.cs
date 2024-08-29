using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManagerScript : MonoBehaviour
{

    public GameObject block;
    public GameObject goal;
    public TextMeshProUGUI scoreText;
    public GameObject coin;

    public static int score = 0;
    
    //1ブロック
    //2コイン
    //3ゴール

    //マップ(ステージ)
    int[,] map =
    {
        {1,0,0,1,1,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,1,1,0,0,0,1},
        {1,0,0,1,1,0,0,0,0,0, 0,0,1,1,0,0,0,0,0,0, 1,1,0,0,0,0,1,0,0,0, 0,0,0,0,0,0,0,0,3,1},
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,2,0,0,0,0,0,0,1,1},
        {1,0,0,0,0,0,1,1,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 1,1,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,4,0, 1,0,0,0,0,1,1,0,0,0, 0,0,0,1,1,0,0,0,0,0, 0,0,0,0,0,1,1,0,0,1},
        {1,0,0,0,0,0,0,0,4,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,1,1,0,0, 0,0,0,0,1,0,0,0,0,1},
        {2,0,0,0,0,0,0,0,0,0, 0,0,2,0,0,0,0,0,0,0, 0,1,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1},
        {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 0,0,1,1,0,0,1,1,0,1, 0,0,1,0,0,1,1,1,1,1},
    };

    //void GatMap()
    //{
    //    map.Initialize();
    //}

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
                if (map[y, x] == 3)
                {
                    goal.transform.position = position;

                    //GoalParticle.transform.position = position;
                }
                //コイン
                if (map[y, x] == 4)
                {
                    Instantiate(coin, position, Quaternion.identity);
                }


            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        //ゴールしてSpaceを押すとタイトルへ戻る
        if (GoalScript.isGameClear == true)
        {
            //スペースを押すとタイトルへ
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("TitleScene");
                //スコアリセット
                score = 0;
            }
        }

        //コインに当たるとスコアが増える
        scoreText.text = "Score" + score;

    }
}
