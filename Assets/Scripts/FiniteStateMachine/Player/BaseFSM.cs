using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base Finite State Machine
/// </summary>
public class BaseFSM : MonoBehaviour
{
    // Current state
    public IState currentState;

    // Dictionary mapping state to key and value
    private Dictionary<StateType, IState> states = new Dictionary<StateType, IState>();

    private void Awake()
    {
        // Adding state object to dictionary
        states.Add(StateType.Idle, new IdleState(this));
        states.Add(StateType.Finding, new FindingState(this));
        states.Add(StateType.Attacking, new AttackingState(this));

        // Default state: Idle
        TransitionState(StateType.Idle);
    }

    /// <summary>
    /// State swap trigger here
    /// </summary>
    private void Update()
    {
        // Running current state's OnUpdate()
        currentState.OnUpdate();

        // Do something here
        // ***************************************
        // if sth
        // Testing here
        // **
        // Q for idle
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TransitionState(StateType.Idle);
        }
        // W for finding
        if (Input.GetKeyDown(KeyCode.W))
        {
            TransitionState(StateType.Finding);
        }
        // E for attacking
        if (Input.GetKeyDown(KeyCode.E))
        {
            TransitionState(StateType.Attacking);
        }
        // **
        // Transition state to
        // ***************************************
    }

    // Swap states
    private void TransitionState(StateType stateType)
    {
        // Exit current state if it's not null
        if (currentState != null)
        {
            currentState.OnExit();
        }

        // Get IdleState object from states dictionary
        currentState = states[stateType];

        // Call IdleState object OnEnter() function
        currentState.OnEnter();
    }
}
