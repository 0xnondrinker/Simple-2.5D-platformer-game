using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform AimTransform;
    public Camera PlayerCamera;

    private void LateUpdate()
    {
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        float distance;
        plane.Raycast(ray, out distance);
        Vector3 Point = ray.GetPoint(distance);

        AimTransform.position = Point;

        Vector3 toAim = AimTransform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);
    }
    
} 
 