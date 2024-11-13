using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    private GameObject targetObject_ = null;

    // Start is called before the first frame update
    void Start()
    {
        string targetName_ = gameObject.name.Replace("_Btn", "");
        targetObject_ = GameObject.Find(targetName_).gameObject;
    }

    public void OnButton()
    {

        if (Input.GetKey(KeyCode.P))
        {
            GameManagerScript.score += 1;
        }

        if(targetObject_.activeSelf)
        {
            GameManagerScript.score += 1;
        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
