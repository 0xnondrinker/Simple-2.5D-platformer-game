using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject BulletEffect; //������ �� ������ ������� ����� ��������� ������ ��� ��� ����������� ����
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
