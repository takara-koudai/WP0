using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnDokan : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        //一番奥の土管に当たるとステージ1に戻る
        if(collision.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene("SampleScene");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
