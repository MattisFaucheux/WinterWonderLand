using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public UnityEvent g_spawns;

    public GameObject prefab;

    private void LateUpdate()
    {
        Spawn();
    }

    public void Spawn()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
