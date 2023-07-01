using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    public Image DamagaImage;
    public void StartEffect()
    {
        StartCoroutine(ShowEffect());
    }
    public IEnumerator ShowEffect()
    {
        DamagaImage.enabled = true;
        for (float i = 1; i > 0; i-=Time.deltaTime * 2)
        {
            DamagaImage.color = new Color(1, 0, 0, i);
            yield return null;
        }
        DamagaImage.enabled = false;
    }
   
    //}
}
