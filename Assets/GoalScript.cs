using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{

    //�N���A�̃e�L�X�g
    public GameObject gameClearText;

    public static bool isGameClear = false;

    private void OnTriggerEnter(Collider other)
    {
        //�R�[���ɓ�����ƕ������\�������
        gameClearText.SetActive(true);


        isGameClear = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
