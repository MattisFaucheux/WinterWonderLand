using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public UnityEvent g_spawns;

    public GameObject prefab;

    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        //g_spawns.AddListener(gameManager.HordeStarted);
    }

    public void Spawn()
    {
        //Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
