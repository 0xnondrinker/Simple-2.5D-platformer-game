using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3 : MonoBehaviour
{
    public Rigidbody PlayerRigidbody;
    public Transform PlayerTransform;
    public float MoveSpeed;
    public float JumpForce;
    public float Friction;
    public float MaxSpeed = 10;
    public bool Grounded;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            if (Grounded)
        {
                Jump();
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            PlayerTransform.localScale = Vector3.Lerp(PlayerTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 8);
        }
        else
        {
            PlayerTransform.localScale = Vector3.Lerp(PlayerTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 8);
        }
    }

    private void FixedUpdate()
    {
        float SpeedMultiplier = 1;

        if (Grounded == false)
        {
            SpeedMultiplier = 0.1f;
        }

        if (Grounded == false && PlayerRigidbody.velocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0)
        {
            SpeedMultiplier = 0f;
        }
        if (Grounded == false && -PlayerRigidbody.velocity.x > MaxSpeed && Input.GetAxis("Horizontal") < 0)
        {
            SpeedMultiplier = 0f;
        }

        PlayerRigidbody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * SpeedMultiplier, 0f, 0f, ForceMode.VelocityChange);


        if (Grounded)
        {
            PlayerRigidbody.AddForce(-PlayerRigidbody.velocity.x * Friction, 0f, 0f, ForceMode.VelocityChange);
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);
        if (angle < 45)
        {
            Grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Grounded = false;
    }

    public void Jump()
    {
        PlayerRigidbody.AddForce(0f, JumpForce, 0f, ForceMode.VelocityChange);
    }

}
