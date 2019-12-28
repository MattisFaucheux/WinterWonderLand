using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines a behaviour routine
/// </summary>
[System.Serializable]
public abstract class State : ScriptableObject
{
    /// <summary>
    /// The reference to the original state
    /// </summary>
    [System.NonSerialized]
    public State initialState;
    /// <summary>
    /// The state machine this instance belongs to
    /// </summary>
    [System.NonSerialized]
    public StateMachine stateMachine;

    /// <summary>
    /// Called when the state machine enters this state. Use it for initialization.
    /// </summary>
    public virtual void Enter() { }

    /// <summary>
    /// Called every frame while the state machine is in this state. This is the routine.
    /// </summary>
    public virtual void Update() { }

    /// <summary>
    /// Called when leaving this state
    /// </summary>
    public virtual void Exit() { }

    /// <summary>
    /// Called when the state machine is disabled
    /// </summary>
    public virtual void OnStateMachineDisable() { }

    public void ExitToTransition(int index)
    {
        StateMachine.Transition transition = GetTransition(index); // Get the transition at index
        stateMachine.g_activeState = null; // Stop the current state machine
        if (transition != null)
            transition.stateMachine.EnterState(transition.state); // the destination state machine enters the destination state
    }

    public void ExitToFirstTransition()
    {
        ExitToTransition(0);
    }

    public void ExitToSecondTransition()
    {
        ExitToTransition(1);
    }

    public StateMachine.Transition GetTransition(int index)
    {
        StateMachine.StatePair pair = stateMachine.GetPairFromState(initialState); // The State/Transitions pair of this state
        if (pair.transitions.Count <= index) return null; // In case there is no transitions, skip
        StateMachine.Transition transition = pair.transitions[index]; // Get the first transition
        return transition;
    }
}
