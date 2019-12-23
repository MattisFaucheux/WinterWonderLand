using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "State SubStateMachine", menuName = "State Machine/States/SubStateMachine")]
public class State_SubStateMachine : State
{
    /// <summary>
    /// The name of the GameObject containing the sub-state machine.
    /// This GameObject must have the same parent as this stateMachine.
    /// </summary>
    public string subStateMachineName;

    protected StateMachine subStateMachine;

    public override void Enter()
    {
        if (subStateMachine == null)
        {
            subStateMachine = stateMachine.transform.parent.gameObject.GetComponentInChildren<StateMachine>();
        }
        subStateMachine.enabled = true;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (subStateMachine.g_activeState == null)
        {
            Exit();
        }
    }

    public override void Exit()
    {
        subStateMachine.enabled = false;
        ExitToFirstTransition();
    }

    public override void OnStateMachineDisable()
    {
        subStateMachine.enabled = false;
    }
}
