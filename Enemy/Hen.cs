using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    public Rigidbody Rigidbody;
    private Transform _playerTransform;

    public float Speed = 5f;
    public float Time = 1f;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove3>().transform;   
    }

    private void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 Force = Rigidbody.mass * (toPlayer * Speed - Rigidbody.velocity) / Time;
        Rigidbody.AddForce(Force);
    }
}
