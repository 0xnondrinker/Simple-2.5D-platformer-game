using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScipt : MonoBehaviour
{
    public Transform HeadPointTransform;
    public Transform AimTransform;


    void Update()
    {
        transform.position = HeadPointTransform.position;
        Vector3 toAim = AimTransform.position - transform.position;
        Vector3 toAimXZ = new Vector3(-toAim.x, 0f, 1f);
        transform.rotation = Quaternion.LookRotation(toAimXZ);
        
    }

}
