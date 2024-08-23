using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public Rigidbody rb;

    GameManagerScript gameManagerScript;

    float EnemySpeed = 2f;

    //GameManagerScript gameM;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")//Õ“Ë‚µ‚½‚ç“G‚ğÁ‚·
        {

            //©•ª‚ªÁ‚¦‚é
            //Destroy(other.gameObject); 

            //“G‚ªÁ‚¦‚é
            Destroy(this.gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //“G‚ÌˆÚ“®
        Vector3 i = rb.velocity;

        i.x = EnemySpeed;

        rb.velocity = i;

    }
}
