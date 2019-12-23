using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "State Search", menuName = "State Machine/States/Search")]
public class State_Search : State
{
    /// <summary>
    /// How far the player can be detected
    /// </summary>
    public float distance;
    /// <summary>
    /// The angle of the field of view
    /// </summary>
    public float angle = 90;
    /// <summary>
    /// The name of the GameObject containing the sub-state machine.
    /// This GameObject must have the same parent as this stateMachine.
    /// </summary>
    public string subStateMachineName;

    protected StateMachine subStateMachine;
    

    public override void Enter()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        Exit();
    }

    public override void Exit()
    {
        subStateMachine.enabled = false;
        ExitToFirstTransition();
    }
}
