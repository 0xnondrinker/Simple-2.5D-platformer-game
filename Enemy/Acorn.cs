using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    public Vector3 Speed;
    public float MaxRotationSpeed;

    private void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Speed, ForceMode.VelocityChange);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(
            Random.Range(-MaxRotationSpeed, MaxRotationSpeed), 
            Random.Range(-MaxRotationSpeed, MaxRotationSpeed), 
            Random.Range(-MaxRotationSpeed, MaxRotationSpeed));

    }
}
