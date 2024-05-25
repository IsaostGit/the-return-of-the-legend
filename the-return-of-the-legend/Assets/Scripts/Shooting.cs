using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float shootSpeed;
    
    private float _shootTime;

    public GameObject bullet;
    private GameObject _nuzzle;

    void Start()
    {
        _nuzzle = GameObject.Find("Nuzzle");
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && shootSpeed < _shootTime)
        {
            _shootTime = 0;
            Instantiate(bullet, _nuzzle.transform.position, _nuzzle.transform.rotation);
        }
        _shootTime += Time.deltaTime;
    }
}
