using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages Idle state behaviour
[System.Serializable]
[CreateAssetMenu(fileName = "State Idle", menuName = "State Machine/States/Idle")]
public class State_Idle : State
{

    public float g_duration;
    private float g_timer;

    public override void Enter()
    {
        //g_duration = Random.Range(1.0f, 6.0f);
        g_duration = 10.0f;
        g_timer = g_duration;
    }

    public override void Update()
    {
        g_timer -= Time.deltaTime;
        if (g_timer <= 0)
        {
            Exit();
        }
        else if (stateMachine.g_gm.g_hordeStarted == true)
        {
            ExitToSecondTransition();
        }
    }

    public override void Exit()
    {
        ExitToFirstTransition();
    }
}
