using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnDokan : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        //��ԉ��̓y�ǂɓ�����ƃX�e�[�W1�ɖ߂�
        if(collision.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene("SampleScene");
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
