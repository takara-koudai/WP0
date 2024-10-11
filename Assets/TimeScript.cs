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

    //制限時間
    [SerializeField] int timeLimit;

    //タイマー用テキスト
    [SerializeField] Text timerText;

    //時間
    float time;

    // Use this for initialization
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //この下でタイマーを減らす
        time += Time.deltaTime;

        int Alltime = timeLimit - (int)time;

        timerText.text = $"のこり：{Alltime.ToString("D3")}";


        //残りタイムが0になったらゲームオーバー
        if(Alltime <= 0)
        {
            gameOverText.SetActive(true);

            isGameOver = true;

            time += 0;
        }

        //spaceを押すとタイトルに戻る(ゲームオーバー版)
        if(isGameOver == true)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("TitleScene");

                //スコアリセット
                //score = 0;
                GameManagerScript.score = 0;
            }
        }
    }
}
