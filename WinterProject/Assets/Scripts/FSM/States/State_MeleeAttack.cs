using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "State MeleeAttack", menuName = "State Machine/States/MeleeAttack")]
public class State_MeleeAttack : State
{

    public override void Enter()
    {

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
