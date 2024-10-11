using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public GameObject hitkey;

    private int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //文字点滅
        timer++;
        if(timer % 400 > 200)
        {
            hitkey.SetActive(false);
        }
        else
        {
            hitkey.SetActive(true);
        }

        //spaceを押すとシーン遷移(選択画面へ)
        if(Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("SelectScene");

            GoalScript.isGameClear = false;
        }

    }
}
