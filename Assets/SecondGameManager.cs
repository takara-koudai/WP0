using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondGameManager : MonoBehaviour
{
    public GameObject block;

    //1ブロック
    //2コイン
    //3ゴール

    //マップ(ステージ)
    int[,] map =
    {
        {1,0,0,1,1,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,2,2,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,2,0,0,0,0,0,0, 2,2,0,0,0,0,2,0,0,0, 0,0,0,0,1,1,0,0,0,1},
        {1,0,0,1,1,0,0,0,0,0, 0,0,1,1,0,0,0,0,0,0, 1,1,0,0,0,0,1,0,0,0, 0,0,0,0,0,0,0,0,3,1},
        {1,0,0,0,0,0,2,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,2,0,0,0,0,0,0,1,1},
        {1,0,0,0,0,0,1,1,0,0, 2,0,0,0,0,0,2,0,0,0, 0,0,0,2,2,0,0,0,0,0, 1,1,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0, 1,0,0,0,0,1,1,0,0,0, 0,0,0,1,1,0,0,0,0,0, 0,0,0,0,2,1,1,0,0,1},
        {1,0,0,0,2,0,0,0,0,0, 0,0,2,0,0,0,0,0,0,0, 0,0,0,0,0,0,1,1,0,0, 0,0,0,0,1,0,0,0,0,1},
        {1,0,0,0,0,0,0,2,0,0, 0,0,1,0,0,2,0,0,0,0, 0,1,0,2,0,0,0,0,0,2, 0,0,0,0,0,0,0,0,0,1},
        {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 0,0,1,1,0,0,1,1,0,1, 0,0,1,0,0,1,1,1,1,1},
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
                //コイン
                //if (map[y, x] == 2)
                //{
                //    Instantiate(coin, position, Quaternion.identity);
                //}
                ////ゴール
                //if (map[y, x] == 3)
                //{
                //    goal.transform.position = position;

                //    GoalParticle.transform.position = position;
                //}
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
