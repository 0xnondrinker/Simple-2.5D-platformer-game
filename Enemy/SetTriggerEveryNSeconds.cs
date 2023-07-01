using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerEveryNSeconds : MonoBehaviour
{
    public float Period = 5;
    private float _timer;
    public Animator Animator;
    public string TriggerName = "EnemySpotted";

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > Period)
        {
            _timer = 0;
            Animator.SetTrigger(TriggerName);
        }
    }
}
