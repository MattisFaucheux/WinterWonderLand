using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Target
{
    Enemy g_enemy;

    /// <summary>
    /// The player
    /// </summary>
    PlayerMouvement g_player;

    /// <summary>
    /// The player's transform
    /// </summary>
    Transform g_playerTransform;

    public float g_duration;
    private float g_timer;

    private void Start()
    {
        g_enemy = this;
        g_duration = 1.0f;
        g_timer = g_duration;

        //Get the player and his transform
        g_player = FindObjectOfType<PlayerMouvement>();
        g_playerTransform = g_player.transform;
    }

    private void Update()
    {
        g_timer -= Time.deltaTime;
        if (g_timer <= 0)
        {
            PlayerDetect();
            g_timer = g_duration;
        }
    }

    /// <summary>
    /// Used to determine if player is detectable
    /// </summary>
    private void PlayerDetect()
    {
        if (Vector3.Distance(g_enemy.transform.position, g_playerTransform.position) <= 100.0f)
        {
            RaycastHit hit;
            if (Physics.Raycast(g_enemy.transform.position, g_playerTransform.position, out hit, 100.0f))
            {
                Debug.DrawRay(g_enemy.transform.position, g_playerTransform.position * hit.distance, Color.red);
            }
        }
    }
}
