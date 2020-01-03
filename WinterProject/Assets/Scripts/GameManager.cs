using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public bool g_hordeStarted;
    
    /// <summary>
    /// Event used to trigger horde mode
    /// </summary>
    public UnityEvent g_hordeTrigger;

    /// <summary>
    /// Base number of zombies in a wave
    /// </summary>
    private const int HORDESIZE = 10;

    [SerializeField]
    private List<Enemy> enemies = new List<Enemy>();

    [SerializeField]
    private List<Spawner> spawners = new List<Spawner>();

    private void Start()
    {
        if (g_hordeTrigger == null)
        {
            g_hordeTrigger = new UnityEvent();
        }
        g_hordeStarted = false;
        
        enemies.AddRange(FindObjectsOfType<Enemy>());
        spawners.AddRange(FindObjectsOfType<Spawner>());

        foreach (Spawner spawner in spawners)
        {
            //g_hordeTrigger.AddListener(HordeStarted);
            //spawner.g_spawns.AddListener(HordeStarted);
        }
    }

    private void FixedUpdate()
    {
        foreach (Enemy enemy in enemies)
        {
            if (enemy.g_detectedPlayer == true)
            {
                StartHorde();
            }
        }

        //Debug to test event cast
        if (Input.GetKey(KeyCode.A));
        {
            HordeStarted();
        }
    }

    public void StartHorde()
    {
        g_hordeStarted = true;
    }

    public void HordeStarted()
    {
        foreach (Spawner spawner in spawners)
        {
            g_hordeTrigger.Invoke();
        }
        
    }
}
