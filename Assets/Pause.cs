using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    


    // Start is called before the first frame update
    void Start()
    {
        //���Ԃ��~�߂�
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԃ𓮂���
        Time.timeScale = 1.0f; ;
    }
}
