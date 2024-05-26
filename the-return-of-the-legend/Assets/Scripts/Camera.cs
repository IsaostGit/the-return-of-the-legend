using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float xOffset;
    
    private Transform _cameraTransform;
    private GameObject _playerObject;

    void Start()
    {
        _cameraTransform = GetComponent<Transform>();
        _playerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        _cameraTransform.position = new Vector3(_playerObject.transform.position.x + xOffset, _cameraTransform.position.y, _cameraTransform.position.z);
    }
}
