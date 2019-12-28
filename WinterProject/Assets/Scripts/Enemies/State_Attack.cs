using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "State Attack", menuName = "State Machine/States/Attack")]
public class State_Attack : State
{
    public override void Enter()
    {
        stateMachine.GetComponent<Behaviour_Attack>().enabled = true;
    }

    public override void Update()
    {
        if (stateMachine.GetComponent<Behaviour_Attack>().g_completed == true)
        {
            stateMachine.GetComponent<Behaviour_Attack>().g_completed = false;
            stateMachine.GetComponent<Behaviour_Attack>().enabled = false;
            Exit();
        }
    }

    public override void Exit()
    {
        ExitToFirstTransition();
    }
}
