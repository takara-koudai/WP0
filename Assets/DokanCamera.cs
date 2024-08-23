using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DokanCamera : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�X�N���[���ƃv���C���[�ǐՃJ����
        var playerPosition = player.transform.position;
        var position = transform.position;
        position.x = playerPosition.x;
        position.y = playerPosition.y + 1;
        position.z = playerPosition.z - 5;
        transform.position = position;
    }
}
