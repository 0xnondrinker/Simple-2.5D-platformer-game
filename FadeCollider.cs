using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCollider : MonoBehaviour
{
    public Material Material;
    IEnumerator FadeWall()
    {
        for (float i = 1; i >= 0; i -= 0.03f)
        {
            Color color = Material.color;
            color.a = i;
            Material.color = color;
            yield return new WaitForSeconds(0.02f);
        }
    }
    IEnumerator ReturnAlphaChannel()
    {
        for (float i = 0.00f; i <= 1; i += 0.03f)
        {
            Color color = Material.color;
            color.a = i;
            Material.color = color;
            yield return new WaitForSeconds(0.02f);
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>())
        {
            StartCoroutine("FadeWall");
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>())
        {
            StartCoroutine("ReturnAlphaChannel");
        }
    }
     
     
    
}
