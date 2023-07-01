using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpShot : MonoBehaviour
{
    public Rigidbody PlayerRigidbody;
    public float Speed;
    public Transform JumpShotTransform;
    public Pistol Pistol;
    private bool _jumpIsReady = false;
    private float _jumpCooldown = 3f;
    private float _timer = 0f;
    public ChargeIcon ChargeIcon;

    
    private void Update()
    {
        if (_jumpIsReady)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                PlayerRigidbody.AddForce(-JumpShotTransform.forward * Speed, ForceMode.VelocityChange);
                Pistol.PistolFire1();
                _timer = 0f;
                _jumpIsReady = false;
                ChargeIcon.StartCharge();
            }
        }
        else
        {
            if (_timer >= _jumpCooldown)
            {
                _jumpIsReady = true;
                ChargeIcon.StopCharge();
            }
            else
            {
                _timer += Time.unscaledDeltaTime;
                ChargeIcon.SetChargeValue(_timer, _jumpCooldown);
            }
        }
        
       
    }
}
