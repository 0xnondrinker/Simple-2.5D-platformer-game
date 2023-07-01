using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject BulletEffect; //—сылка на объект который будет создавать каждый раз при уничтожении пули
    private void Start()
    {
        Destroy(gameObject, 4f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Instantiate(BulletEffect, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TakeDamageOnTrigger>())
        {
            Destroy(gameObject);
            Instantiate(BulletEffect, transform.position, Quaternion.identity);
        }

        
    }
}
