using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3Stop : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy3")
        {
            enemy3Script.stopflag = true;
            enemy3Script.dropflag = false;
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
