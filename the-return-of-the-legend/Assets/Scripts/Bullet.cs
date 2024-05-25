using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletDamage;
    public float bulletLifeTime;

    private float _bulletTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
        _bulletTime += Time.deltaTime;
        if(bulletLifeTime < _bulletTime)
        {
            Destroy(gameObject);
        }
    }
}
