using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class enemy3Script : MonoBehaviour
{

    float dropSpeed = 1f;

    public static bool dropflag = false;

    public void OnCollisionEnter(Collision collision)
    {
        if(kariPlayerSc.isChange == true)
        {
            if (collision.gameObject.tag == "kariPlayer")//è’ìÀÇµÇΩÇÁìGÇè¡Ç∑
            {
                kariPlayerSc.isChange = false;
            }
        }
        
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(dropflag == true)
        {
            transform.position -= new Vector3(0, dropSpeed, 0) * Time.deltaTime;
        }

    }
}
