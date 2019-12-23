using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "State Debug", menuName = "State Machine/States/Debug")]
public class State_Debug : State
{
    /// <summary>
    /// The message to be displayed on the console when entered
    /// </summary>
    public string message;

    public override void Enter()
    {
        Debug.Log("State Machine Debug > " + message);
    }

    public override void Update()
    {
        Exit();
    }

    public override void Exit()
    {
        ExitToFirstTransition();
    }
}
