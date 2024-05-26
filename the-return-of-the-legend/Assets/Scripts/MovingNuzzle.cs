using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingNuzzle : MonoBehaviour
{
    public float standingXOffset;
    public float standingYOffset;
    public float crouchingXOffset;
    public float crouchingYOffset;
    public float straightUpXOffset;
    public float straightUpYOffset;

    private Transform _nuzzleTranform;
    private GameObject _playerGameObject;
    private Transform _playerTransform;
    
    void Start()
    {
        _nuzzleTranform = GetComponent<Transform>();
        _playerGameObject = GameObject.Find("Player");
        _playerTransform = _playerGameObject.GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetKey("s"))
        {
            _nuzzleTranform.position = new Vector3(crouchingXOffset * _playerTransform.localScale.x, crouchingYOffset, _nuzzleTranform.position.z) + _playerTransform.position;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 180 + 90 * _playerTransform.localScale.x);
        }
        else if (Input.GetKey("w"))
        {
            _nuzzleTranform.position = new Vector3(straightUpXOffset * _playerTransform.localScale.x, straightUpYOffset, _nuzzleTranform.position.z) + _playerTransform.position; ;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            _nuzzleTranform.position = new Vector3(standingXOffset * _playerTransform.localScale.x, standingYOffset, _nuzzleTranform.position.z) + _playerTransform.position;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 180 + 90 * _playerTransform.localScale.x);
        }
    }
}
