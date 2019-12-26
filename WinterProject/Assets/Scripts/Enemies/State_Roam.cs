using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "State Roam", menuName = "State Machine/States/Roam")]
public class State_Roam : State
{

    public override void Enter()
    {
        stateMachine.GetComponent<Behaviour_Roam>().enabled = true;
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public override void Exit()
    {
        ExitToFirstTransition();
    }
}
