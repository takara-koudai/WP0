using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxCollisionSc : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            EnemyScript.moveRight = false;
            EnemyScript.moveLeft = true;
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
