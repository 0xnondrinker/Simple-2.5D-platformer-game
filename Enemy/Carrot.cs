using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    private Transform PlayerTransform;
    public Rigidbody Rigidbody;
    public float Speed = 10;

    private void Start()
    {
        transform.rotation = Quaternion.identity;
        PlayerTransform = FindObjectOfType<PlayerHealth>().transform;
        Vector3 toPlayer = (PlayerTransform.position - transform.position).normalized;
        Rigidbody.velocity = toPlayer * Speed;
    }
}
