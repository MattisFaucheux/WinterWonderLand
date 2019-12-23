using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Define state initialisation and manage state allocation.
/// </summary>
public class StateMachine : MonoBehaviour
{
    [System.Serializable]
    public class Transition
    {
        public StateMachine stateMachine;
        public State state;
    }

    [System.Serializable]
    public class StatePair
    {
        public State state;
        public List<Transition> transitions = new List<Transition>();
    }

    public List<StatePair> allStates;
    public State startingState;
    public State g_activeState;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        EnterState(startingState);
    }

    void Init()
    {
        var StateToCopy = new Dictionary<State, State>();

        foreach (StatePair pair in allStates)
        {
            if (!StateToCopy.ContainsKey(pair.state))
            {
                //Contains instance of state
                var m_temp = Instantiate(pair.state);
                m_temp.initialState = pair.state;
                m_temp.stateMachine = this;

                //created instance of state 
                StateToCopy.Add(pair.state, m_temp);
            }

            pair.state = StateToCopy[pair.state];
        }
    }

    public StatePair GetPairFromState(State state)
    {
        foreach (StatePair pair in allStates)
        {
            if (pair.state.initialState == state)
            {
                return pair;
            }
        }
        return null;
    }

    public void EnterState(State state)
    {
        foreach (StatePair pair in allStates)
        {
            if (pair.state.initialState == state)
            {
                pair.state.Enter();
                g_activeState = pair.state;
                return;
            }
        }
    }

    private void Update()
    {
        if (g_activeState != null)
        {
            g_activeState.Update();
        }
    }

    private void OnDisable()
    {
        if (g_activeState != null) g_activeState.OnStateMachineDisable();
        g_activeState = null;
    }

    private void OnEnable()
    {
        if (g_activeState == null) EnterState(startingState);
    }
}
