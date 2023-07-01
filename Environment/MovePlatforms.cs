using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
    public Transform LeftTargetTransform;
    public Transform RightTargetTransform;
    public Vector3 Speed;

    private void Update()
    {
        if (transform.position == LeftTargetTransform.position)
        {

            transform.position = transform.position + Speed;
        }
    }

}
