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

    private float g_distToPoint = 1.5f;

    [System.NonSerialized]
    public bool g_completed = false;
    // Start is called before the first frame update
    void OnEnable()
    {
        g_completed = false;
        g_agent = gameObject.GetComponent<NavMeshAgent>();
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

    private Vector3 RandomDest(Transform m_anchor)
    {
        Vector3 m_dest;
        m_dest = new Vector3(m_anchor.position.x + Random.Range(-50, 50), m_anchor.position.y, m_anchor.position.z + Random.Range(-15, 15));
        Debug.Log(m_dest);
        return m_dest;
    }
}
