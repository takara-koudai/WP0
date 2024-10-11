using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    public GameObject Item;
    public Color Itemcolor;

    private void OnCollisionEnter(Collision collision)
    {
        Item = collision.gameObject;
        Itemcolor = Item.GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Itemcolor;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal") * Time.deltaTime * 3;
        float dy = Input.GetAxis("Vertical") * Time.deltaTime * 3;
        transform.position = new Vector3(transform.position.x + dx, 0, transform.position.z + dy);
    }
}
