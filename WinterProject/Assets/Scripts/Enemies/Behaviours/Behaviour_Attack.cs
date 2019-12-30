using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Behaviour_Attack : MonoBehaviour
{

    /// <summary>
    /// The AI agent
    /// </summary>
    NavMeshAgent g_agent;

    /// <summary>
    /// The agent's target i.e. the player
    /// </summary>
    Transform g_target;

    [System.NonSerialized]
    public bool g_completed = false;

    // Start is called before the first frame update
    void OnEnable()
    {
        g_target = FindObjectOfType<Player>().transform;
        g_completed = false;
        g_agent = gameObject.GetComponentInParent<NavMeshAgent>();
        g_agent.SetDestination(g_target.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
