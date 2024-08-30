using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{

    //クリアのテキスト
    public GameObject gameClearText;

    public static bool isGameClear = false;

    private void OnTriggerEnter(Collider other)
    {
        //コールに当たると文字が表示される
        gameClearText.SetActive(true);


        isGameClear = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
