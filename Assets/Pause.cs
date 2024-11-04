using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    


    // Start is called before the first frame update
    void Start()
    {
        //ŽžŠÔ‚ðŽ~‚ß‚é
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //ŽžŠÔ‚ð“®‚©‚·
        Time.timeScale = 1.0f; ;
    }
}
