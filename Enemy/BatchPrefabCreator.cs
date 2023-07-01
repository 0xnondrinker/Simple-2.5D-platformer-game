using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatchPrefabCreator : MonoBehaviour
{
    public GameObject AcornPrefab;
    public Transform[] AcornArrow;

    public void Create()
    {
        for (int i = 0; i < AcornArrow.Length; i++)
        {
            Instantiate(AcornPrefab, AcornArrow[i].position, AcornArrow[i].rotation);
        }
    }
}
