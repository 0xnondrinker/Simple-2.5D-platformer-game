using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    private Transform _playerTransform;
    public Vector3 RightEuler;
    public Vector3 LeftEuler;
    public float RotationSpeed = 5;
    private Vector3 _targetEuler;

    private void Start()
    {
        //Ищем игрока в сцене
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }
    private void Update()
    {
        //Проверяем справа ли игрок
        if (transform.position.x < _playerTransform.position.x)
        {
            //Повернуться налево
            _targetEuler = LeftEuler;
        }
        else
        {
            //Повернуться направо
            _targetEuler = RightEuler;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * RotationSpeed);
    }
}
