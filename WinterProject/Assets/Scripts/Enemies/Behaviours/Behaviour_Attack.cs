using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Behaviour_Attack : MonoBehaviour
{
    #region Variables
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

    private const int DMG = 5;

    [SerializeField]
    private float g_attRange = 2.5f; //The range of the zombie melee attack

    private float g_attRate = 1.0f;
    private float g_nextAttTime = 0.0f;

    public Transform g_attPoint;

    public LayerMask g_playerLayer;
    #endregion

    #region Base Methods
    // Start is called before the first frame update
    void OnEnable()
    {
        g_target = FindObjectOfType<Player>().transform;
        g_completed = false;
        g_agent = gameObject.GetComponentInParent<NavMeshAgent>();
        g_agent.SetDestination(g_target.position);

        if (g_attPoint == null)
        {
            Debug.Log("Please set the Attack point in dedicated variable slot in editor");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(g_agent.destination, g_agent.transform.position) < g_attRange)
        {
            g_agent.isStopped = true; //Stops the agent
            if (Time.time >= g_nextAttTime)
            {
                Attack();
                g_nextAttTime = Time.time + 1f / g_attRate;
            }
        }
    }

    private void LateUpdate()
    {
        g_agent.SetDestination(g_target.position);
    }

    #endregion

    #region Custom Methods

    private void Attack()
    {
        if (g_attPoint == null)
            return;

        //Contain all collisions with player
        Collider[] m_playerCol = Physics.OverlapSphere(g_attPoint.position, g_attRange, g_playerLayer);

        foreach (Collider m_player in m_playerCol)
        {
            FindObjectOfType<Player>().TakeDamage(DMG);
        }
    }

    #endregion
}
