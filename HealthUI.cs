using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public GameObject HealthIconPrefab;
    public List<GameObject> HealthIconsList = new List<GameObject>();
    public void Setup(int MaxHealth)
    {
        for (int i=0; i <= MaxHealth; i++)
        {
            GameObject newIcon = Instantiate(HealthIconPrefab, transform);
            HealthIconsList.Add(newIcon);
        }
    }
    public void DisplayHealth (int Health)
    {
        for (int i=0; i < HealthIconsList.Count; i++)
        {
            if (i < Health)
            {
                HealthIconsList[i].SetActive(true);
            }
            else
            {
                HealthIconsList[i].SetActive(false);
            }
        }
    }
}
