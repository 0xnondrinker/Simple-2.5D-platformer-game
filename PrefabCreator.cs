using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
    public Transform SpawnTransform;
    public GameObject PrefabToCreate;

    public void Attack()
    {
        Instantiate(PrefabToCreate, SpawnTransform.position, SpawnTransform.rotation);
    }
}
