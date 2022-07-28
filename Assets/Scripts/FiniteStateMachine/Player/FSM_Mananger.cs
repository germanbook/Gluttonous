using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base Finite State Machine
/// </summary>
public class FSM_Mananger : MonoBehaviour
{
    // Play character
    public GameObject player;

    // Target player
    public GameObject targetPlayer;

    public Animator animator;

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
        states.Add(StateType.Death, new DeathState(this));

        // Default state: Idle
        TransitionState(StateType.Idle);
        
        

        // TODO: Initialize the state of Play such as health
        // ...
    }

    /// <summary>
    /// State swap trigger here
    /// </summary>
    private void Update()
    {
        // Running current state's OnUpdate()
        currentState.OnUpdate();

        if(player.gameObject.GetComponent<PlayerStatus_Temp>().getHealthValue() <= 0f)
        {
            TransitionState(StateType.Death);
        }

        
    }

    // Swap states
    public void TransitionState(StateType stateType)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        // Testing
        // this : player
        if (collision.gameObject.tag == "Enemy" && this.gameObject.name == "GladOneGFX")
        {
            TransitionState(StateType.Attacking);
            targetPlayer = collision.gameObject;
        }

    }


    public void removeCharactor()
    {
        this.gameObject.SetActive(false);
    }


}
