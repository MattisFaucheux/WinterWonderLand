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

    private void Start()
    {
        if (g_hordeTrigger == null)
        {
            g_hordeTrigger = new UnityEvent();
        }
        g_hordeStarted = false;
    }

    public void StartHorde()
    {
        g_hordeStarted = true;
    }
}
