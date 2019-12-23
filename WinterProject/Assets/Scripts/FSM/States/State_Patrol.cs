using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "State Patrol", menuName = "State Machine/States/Patrol")]
public class State_Patrol : State
{
    public override void Enter()
    {
        stateMachine.GetComponent<Behaviour_Patrol>().enabled = true;
    }

    // Update is called once per frame
    public override void Update()
    {
        Exit();
    }

    public override void Exit()
    {
        stateMachine.GetComponent<Behaviour_Patrol>().enabled = false;
        ExitToFirstTransition();
    }

    public override void OnStateMachineDisable()
    {
        stateMachine.GetComponent<Behaviour_Patrol>().enabled = false;
    }
}
