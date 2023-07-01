using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform TargetTransform;
    [SerializeField] float PursuitSpeed;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, TargetTransform.position, PursuitSpeed * Time.deltaTime);
    }
}
