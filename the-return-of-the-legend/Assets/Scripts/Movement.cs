using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey("a"))
        {
            transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
        }
    }
}
