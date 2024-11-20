using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    public Rigidbody rb;

    public GameObject gameOverText;

    public void OnCollisionEnter(Collision collision)
    {
        //敵の弾が自分に当たるとゲームオーバー
        if (collision.gameObject.tag == "kariPlayer")
        {
            //EnemyScript.isGameOver = true;
            //gameOverText.SetActive(true);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        float moveSpeed = 5.0f;

        
        rb.velocity = new Vector3(moveSpeed, 0, 0);

        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
