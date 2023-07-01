using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitAttack : MonoBehaviour
{
    public GameObject Carrot;
    public Transform Spawn;

    public void Create()
    {
        Instantiate(Carrot, Spawn.position, Quaternion.identity);
    }
}
