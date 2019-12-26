using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "State Debug", menuName = "State Machine/States/Debug")]
public class State_Debug : State
{

    public float g_duration;
    private float g_timer;
    public string message;

    public override void Enter()
    {
        g_timer = g_duration;
        Debug.Log("State Machine Debug > " + message);
    }

    public override void Update()
    {
        g_timer -= Time.deltaTime;
        if (g_timer <= 0)
        {
            Exit();
        }
    }

    public override void Exit()
    {
        ExitToFirstTransition();
    }
}
