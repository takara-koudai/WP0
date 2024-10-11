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
        //�����_��
        timer++;
        if(timer % 400 > 200)
        {
            hitkey.SetActive(false);
        }
        else
        {
            hitkey.SetActive(true);
        }

        //space�������ƃV�[���J��(�I����ʂ�)
        if(Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("SelectScene");

            GoalScript.isGameClear = false;
        }

    }
}
