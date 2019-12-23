using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Moves NPC to an adequate position to attack

[System.Serializable]
[CreateAssetMenu(fileName = "State GetIntoPosition", menuName = "State Machine/States/GetIntoPosition")]
public class State_GetIntoPosition : State
{
    private Behaviour_GetIntoPosition behaviour;
    private bool pathfindingFailed;

    public override void Enter()
    {
        behaviour = stateMachine.GetComponent<Behaviour_GetIntoPosition>();
        behaviour.enabled = true;
        pathfindingFailed = false;
    }

    // Update is called once per frame
    public override void Update()
    {
        Exit();
    }

    public override void Exit()
    {
        stateMachine.GetComponent<Behaviour_GetIntoPosition>().enabled = false;
        if (pathfindingFailed)
        {
            ExitToTransition(1);
        }
        else
        {
            ExitToFirstTransition();
        }
        pathfindingFailed = false;
    }

    public override void OnStateMachineDisable()
    {
        stateMachine.GetComponent<Behaviour_GetIntoPosition>().enabled = false;
    }
}