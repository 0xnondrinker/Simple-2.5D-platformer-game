using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float TimeScaleValue = 0.2f;
    private float FixedTimeScale;

    private void Start()
    {
        FixedTimeScale = Time.fixedDeltaTime;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Time.timeScale = TimeScaleValue;
            Time.fixedDeltaTime = FixedTimeScale * TimeScaleValue;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    private void OnDestroy()
    {
        Time.fixedDeltaTime = FixedTimeScale;
    }
}
