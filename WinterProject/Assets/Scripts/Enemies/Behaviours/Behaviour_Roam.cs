using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Behaviour_Roam : MonoBehaviour
{
    /// <summary>
    /// The AI agent
    /// </summary>
    NavMeshAgent g_agent;

    /// <summary>
    /// Referential used to determine roaming sector
    /// </summary>
    Transform g_anchor;

    /// <summary>
    /// The previous destination / position of the agent
    /// </summary>
    Vector3 g_prevPos;

    private float g_distToPoint = 1.5f;

    [System.NonSerialized]
    public bool g_completed = false;
    // Start is called before the first frame update
    void OnEnable()
    {
        g_completed = false;
        g_agent = gameObject.GetComponentInParent<NavMeshAgent>();
        g_prevPos = g_agent.transform.position;
        g_anchor = FindObjectOfType<AnchorClass>().transform;
        g_agent.SetDestination(RandomDest(g_anchor));
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(g_agent.destination, g_agent.transform.position) <= g_distToPoint)
        {
            g_completed = true;
        }
    }

    /// <summary>
    /// Generate random destination
    /// </summary>
    /// <param name="m_anchor"></param>
    /// <returns></returns>
    private Vector3 RandomDest(Transform m_anchor)
    {
        Vector3 m_dest;
        m_dest = new Vector3(m_anchor.position.x + Random.Range(-50, 50), m_anchor.position.y, m_anchor.position.z + Random.Range(-15, 15));

        //Check if path is completable
        NavMeshPath m_path = new NavMeshPath();
        g_agent.CalculatePath(m_dest, m_path);
        if (m_path.status == NavMeshPathStatus.PathPartial)
        {
            Debug.Log("Error, going back to prev pos");
            m_dest = g_prevPos;
        }
        return m_dest;
    }
}
