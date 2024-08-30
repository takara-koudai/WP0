using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dokanMoveScript : MonoBehaviour
{

    
    //プレイヤーが土管に当たるとシーンが変わる
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "kariPlayer")
        {
            
            SceneManager.LoadScene("DokanScene");
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
