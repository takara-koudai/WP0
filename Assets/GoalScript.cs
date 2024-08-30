using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{

    //�N���A�̃e�L�X�g
    public GameObject gameClearText;
    public GameObject gameOverText;

    public static bool isGameClear = false;

    private void OnTriggerEnter(Collider other)
    {
        //�X�R�A�̍��v��40�ŃS�[���ɓ�����ƃN���A�ɂȂ�
        if(GameManagerScript.score >= 40)
        {
            //�R�[���ɓ�����ƕ������\�������
            gameClearText.SetActive(true);

            isGameClear = true;
        }

        //�Q�[���I�[�o�[�\��
        if(GameManagerScript.score < 40)
        {
            gameOverText.SetActive(true);

            TimeScript.isGameOver = true;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //�t���O�̃��Z�b�g
        isGameClear = false;
        TimeScript.isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
