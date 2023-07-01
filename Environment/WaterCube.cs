using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCube : MonoBehaviour
{
    public float Force = 10;
    private void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<PlayerHealth>())
            {
                other.attachedRigidbody.AddForce(Vector3.up * Force, ForceMode.VelocityChange);
                other.attachedRigidbody.GetComponent<PlayerHealth>().TakeDamage(1);
            }
        }
    }
}
