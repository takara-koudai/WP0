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
        if (other.gameObject.tag == "Player")//�Փ˂�����G������
        {

            //������������
            //Destroy(other.gameObject); 

            //�G��������
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
        //�G�̈ړ�
        Vector3 i = rb.velocity;

        i.x = EnemySpeed;

        rb.velocity = i;

    }
}
