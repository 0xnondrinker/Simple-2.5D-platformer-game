using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed;
    private Transform _playerTransform;
     

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }

    private void Update()
    {
        transform.position += Time.deltaTime * transform.forward * Speed;
        Vector3 ToPlayer = (_playerTransform.position - transform.position).normalized;
        Quaternion RotateToTarget = Quaternion.LookRotation(ToPlayer, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, RotateToTarget, RotationSpeed * Time.deltaTime);
    }
}
