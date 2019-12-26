using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "State Roam", menuName = "State Machine/States/Roam")]
public class State_Roam : State
{

    public override void Enter()
    {
        Debug.Log("Enterred Roam");
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
    }

    public override void Exit()
    {
        ExitToFirstTransition();
    }
}
