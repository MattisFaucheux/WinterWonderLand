using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;

public class Enemy : Target
{
    #region Variables
    Enemy g_enemy;

    public bool g_detectedPlayer;

    /// <summary>
    /// The player
    /// </summary>
    Player g_player;

    /// <summary>
    /// The player's transform
    /// </summary>
    Transform g_playerTransform;

    public float g_detectDelay = 1.0f;
    private float g_detectTimer;
    #endregion

    private void Start()
    {
        g_enemy = GetComponent<Enemy>();
        g_detectDelay = 1.0f;
        g_detectTimer = g_detectDelay;

        //Get the player and his transform
        g_player = FindObjectOfType<Player>();
        g_playerTransform = g_player.transform;
        g_detectedPlayer = false;
    }

    private void FixedUpdate()
    {
        g_detectTimer -= Time.deltaTime;
        if (g_detectTimer < 0)
        {
            PlayerDetect();
            g_detectTimer = g_detectDelay;
        }
    }

    /// <summary>
    /// Used to determine if player is detectable
    /// </summary>
    private void PlayerDetect()
    {
        if (Vector3.Distance(g_enemy.transform.position, g_playerTransform.position) <= 100.0f)
        {
            Ray ray = new Ray();
            RaycastHit hit;

            ray.origin = g_enemy.transform.position;
            ray.direction = g_playerTransform.position - g_enemy.transform.position;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                g_detectedPlayer = true;
            }
        }
    }
}
