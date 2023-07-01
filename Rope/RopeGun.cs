using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState
{
    Disabled,
    Fly,
    Active
}
public class RopeGun : MonoBehaviour

    
{
    public Hook Hook;
    public Transform SpawnTransform;
    public float Speed = 20f;
    private SpringJoint _SpringJoint;
    public Transform AnchorPointTransform;
    private float _ropeLength;
    public float ClimbSpeed;
    public RopeState CurrentRopeState;
    public RopeRenderer RopeRenderer;
    public PlayerMove3 PlayerMove3;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            HookShot();
        }
        if (CurrentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(AnchorPointTransform.position, Hook.transform.position);
            if (distance > 20)
            {
                Hook.gameObject.SetActive(false);
                CurrentRopeState = RopeState.Disabled;
                RopeRenderer.Hide();
            }
        }
        if (CurrentRopeState == RopeState.Active)
        {
            if (Input.GetKey(KeyCode.W))
            {
                _SpringJoint.maxDistance -= Time.deltaTime * ClimbSpeed;
                _ropeLength -= Time.deltaTime * ClimbSpeed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                float distance = Vector3.Distance(AnchorPointTransform.position, Hook.transform.position);
                if (_ropeLength <= distance)
                {
                    _SpringJoint.maxDistance += Time.deltaTime * ClimbSpeed;
                    _ropeLength += Time.deltaTime * ClimbSpeed;
                }
                
            }

        }
        if (CurrentRopeState == RopeState.Active || CurrentRopeState == RopeState.Fly)
        {
            RopeRenderer.DrawRope(AnchorPointTransform.position, Hook.transform.position, _ropeLength);
        }

        if (CurrentRopeState == RopeState.Active)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DestroySpring();
                Hook.gameObject.SetActive(false);
                if (PlayerMove3.Grounded == false & Input.GetKey(KeyCode.W) == false)
                { 
                    PlayerMove3.Jump();
                }
            }
        }
        
    }
    void HookShot()
    {
        _ropeLength = 0;
        Hook.gameObject.SetActive(true);
        CurrentRopeState = RopeState.Fly;
        if (_SpringJoint)
        {
            DestroySpring();
        }
        Hook.StopFix();
        Hook.transform.position = SpawnTransform.position;
        Hook.transform.rotation = SpawnTransform.rotation;
        Hook.Rigidbody.velocity = SpawnTransform.forward * Speed;
    }

    public void SpringJointCreate()
    {
        if (_SpringJoint == null)
        {
            _SpringJoint = gameObject.AddComponent<SpringJoint>();
            _SpringJoint.autoConfigureConnectedAnchor = false;
            _SpringJoint.connectedBody = Hook.Rigidbody;
            _SpringJoint.anchor = AnchorPointTransform.localPosition;
            _SpringJoint.connectedAnchor = new Vector3(0f, 0f, 0f);
            _SpringJoint.spring = 100;
            _SpringJoint.damper = 20;

            _ropeLength = Vector3.Distance(AnchorPointTransform.position, Hook.transform.position);
            _SpringJoint.maxDistance = _ropeLength;

            CurrentRopeState = RopeState.Active;
        }
    }
    public void DestroySpring()
    {
        if (_SpringJoint)
        {
            CurrentRopeState = RopeState.Disabled;
            Destroy(_SpringJoint);
            RopeRenderer.Hide();
        }
    }
}
