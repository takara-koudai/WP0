using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    public Rigidbody rb;

    public void OnCollisionEnter(Collision collision)
    {
        //�y�ǂɓ�����ƒe��������
        if(collision.gameObject.tag == "Dokan")
        {
            Destroy(gameObject);
        }

        //�e�Ɠy�ǂ�������ƓG��������
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

            //�G��|���ƃX�R�A��������
            GameManagerScript.score += 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        float moveSpeed = 5.0f;

        rb.velocity = new Vector3(moveSpeed, 0, 0);

        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
