using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishPointManager : MonoBehaviour
{
    public GameObject MenuButton;
    public GameObject LevelFinishWindow;
    public TimeManager TimeManager;
    private float _fixedTimeScale;

    private void Start()
    {
        _fixedTimeScale = Time.fixedDeltaTime;
    }

    public void Update()
    {
        Debug.Log(Time.timeScale);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<PlayerMove3>())
            {
                OpenLevelFinishWindow();
            }
        }
    }

    private void OpenLevelFinishWindow()
    {
        MenuButton.SetActive(false);
        LevelFinishWindow.SetActive(true);
        TimeManager.gameObject.SetActive(false);
        Time.timeScale = 0.02f;
        Time.fixedDeltaTime = _fixedTimeScale * Time.timeScale;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}
