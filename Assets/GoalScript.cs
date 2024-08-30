using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{

    //クリアのテキスト
    public GameObject gameClearText;
    public GameObject gameOverText;

    public static bool isGameClear = false;

    private void OnTriggerEnter(Collider other)
    {
        //スコアの合計が40でゴールに当たるとクリアになる
        if(GameManagerScript.score >= 40)
        {
            //コールに当たると文字が表示される
            gameClearText.SetActive(true);

            isGameClear = true;
        }

        //ゲームオーバー表示
        if(GameManagerScript.score < 40)
        {
            gameOverText.SetActive(true);

            TimeScript.isGameOver = true;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //フラグのリセット
        isGameClear = false;
        TimeScript.isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
