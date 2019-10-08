using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(-6.63f, 2.266f, -10f);
    public Vector3 temp;
    public float left;
    public float right;
    public float top;
    public float bottom;

    void Start()
    {
        player = GameObject.Find("witch");
    }

    void Update()
    {
        transform.position = offset;
        if (transform.position.x < left)
        {
            temp = transform.position;
            temp.x = left;
            transform.position = temp;
        }
        else if (transform.position.x > right)
        {
            temp = transform.position;
            temp.x = right;
            transform.position = temp;
        }
        if (transform.position.y < bottom)
        {
            temp = transform.position;
            temp.y = bottom;
            transform.position = temp;
        }
        else if (transform.position.y > top)
        {
            temp = transform.position;
            temp.y = top;
            transform.position = temp;
        }
    }
}
