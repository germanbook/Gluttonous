using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

/// <summary>
/// Base Finite State Machine
/// </summary>
public class FSM_Mananger : MonoBehaviour
{

    // Target player
    public GameObject targetPlayer;

    public Animator animator;

    // Current state
    public IState currentState;

    // Throw net
    bool isThrowNet;

    // Dictionary mapping state to key and value
    private Dictionary<StateType, IState> states = new Dictionary<StateType, IState>();

    private void Awake()
    {
        // Adding state object to dictionary
        states.Add(StateType.Idle, new IdleState(this));
        states.Add(StateType.Finding, new FindingState(this));
        states.Add(StateType.Attacking, new AttackingState(this));
        states.Add(StateType.Death, new DeathState(this));
        states.Add(StateType.ThrowNet, new ThrowNetState(this));
        states.Add(StateType.Block, new BlockState(this));

        // Default state: Idle
        TransitionState(StateType.Idle);
        
        

        // TODO: Initialize the state of Play such as health
        // ...
    }

    /// <summary>
    /// State swap trigger here
    /// </summary>
    private void FixedUpdate()
    {
        // Running current state's OnUpdate()
        currentState.OnUpdate();
        if(this.gameObject.GetComponent<PlayerStatus_Temp>().getHealthValue() <= 0f)
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.gameObject.GetComponent<TargetFinder>().arenaSceneManager.gameObject.GetComponent<ArenaSceneManager>().isPause == false)

        if (collision.gameObject.tag != "Net"
            && this.gameObject.tag != collision.gameObject.tag
            && collision.gameObject.GetComponent<TargetFinder>().nearestEnemy.gameObject.name == this.gameObject.name
            && this.gameObject.GetComponent<TargetFinder>().nearestEnemy.gameObject.name ==
            collision.gameObject.name )
        {
            TransitionState(StateType.Attacking);
            targetPlayer = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (GameObject.ReferenceEquals(targetPlayer.gameObject, collision.gameObject))
        {
            
            this.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking = false;
        }
    }


    public void removeCharactor()
    {
        this.gameObject.SetActive(false);
        this.transform.parent.gameObject.SetActive(false);
        
        this.gameObject.transform.parent.gameObject.GetComponent<AIDestinationSetter>().target = null;
        
    }



}
