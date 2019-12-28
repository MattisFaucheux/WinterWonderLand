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
        if (stateMachine.GetComponent<Behaviour_Roam>().g_completed == true)
        {
            stateMachine.GetComponent<Behaviour_Roam>().g_completed = false;
            stateMachine.GetComponent<Behaviour_Roam>().enabled = false;
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
