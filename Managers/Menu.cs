using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject MenuButton;
    public GameObject MenuWindow;
    public MonoBehaviour[] ScriptsToDisableArrow;
    private float _fixedTimeScale;

    private void Start()
    {
        _fixedTimeScale = Time.fixedDeltaTime;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MenuWindow.activeInHierarchy == false)
            {
                OpenMenu();
            }
            else
            {
                CloseMenu();
            }
            
        }
    }

    public void OpenMenu()
    {
        MenuWindow.SetActive(true);
        MenuButton.SetActive(false);

        for (int i=0; i < ScriptsToDisableArrow.Length; i++)
        {
            ScriptsToDisableArrow[i].enabled = false;
        }
        Time.timeScale = 0.02f;
        Time.fixedDeltaTime = _fixedTimeScale * Time.timeScale;
    }
    public void CloseMenu()
    {
        MenuWindow.SetActive(false);
        MenuButton.SetActive(true);

        for (int i = 0; i < ScriptsToDisableArrow.Length; i++)
        {
            ScriptsToDisableArrow[i].enabled = true;
        }
        Time.timeScale = 1f;
        Time.fixedDeltaTime = _fixedTimeScale;
    }
    
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
