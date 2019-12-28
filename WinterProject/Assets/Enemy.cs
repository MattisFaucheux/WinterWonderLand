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

    public float g_detectDelay = 1.0f;
    private float g_detectTimer;

    private void Start()
    {
        g_enemy = GetComponent<Enemy>();
        g_detectDelay = 1.0f;
        g_detectTimer = g_detectDelay;

        //Get the player and his transform
        g_player = FindObjectOfType<PlayerMouvement>();
        g_playerTransform = g_player.transform;
    }

    private void Update()
    {
        PlayerDetect();
        /*g_detectTimer -= Time.deltaTime;
        if (g_detectTimer < 0)
        {
            PlayerDetect();
            g_detectTimer = g_detectDelay;
        }*/
    }

    /// <summary>
    /// Used to determine if player is detectable
    /// </summary>
    private void PlayerDetect()
    {
        if (Vector3.Distance(g_enemy.transform.position, g_playerTransform.position) <= 100.0f)
        {
            Debug.Log(gameObject.name + " is in range");
            Ray ray = new Ray();
            RaycastHit hit;

            ray.origin = g_enemy.transform.position;
            ray.direction = g_playerTransform.position - g_enemy.transform.position;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                Debug.Log(gameObject.name + " Detected player");
            }
        }
    }
}
