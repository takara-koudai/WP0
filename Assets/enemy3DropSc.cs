using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.MaterialProperty;

public class enemy3DropSc : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "kariPlayer")
        {
            enemy3Script.dropflag = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        enemy3Script.dropflag = false;
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
