using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private FixedJoint _fixedJoint;
    public Rigidbody Rigidbody;
    public Collider PlayerCollider;
    public Collider HookCollider;

    public RopeGun RopeGun;

    private void Start()
    {
        Physics.IgnoreCollision(PlayerCollider, HookCollider);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_fixedJoint == null)
        {
            _fixedJoint = gameObject.AddComponent<FixedJoint>();
            if (collision.rigidbody)
            {
                _fixedJoint.connectedBody = collision.rigidbody;
            }
        }
        RopeGun.SpringJointCreate();
        RopeGun.CurrentRopeState = RopeState.Active;
    }

    public void StopFix()
    {
        Destroy(_fixedJoint);
    }

}
