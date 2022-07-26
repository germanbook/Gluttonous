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

        // Do something here
        // ***************************************
        // if sth
        // Testing here
        // **
        // Q for idle
        
        // **
        // Transition state to


        // Find nearest target
        FindTarget("Enemy");
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

    // Find all enemies
    private void FindTarget(string enemyTag)
    {
        // All enemies in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float minDistance = Mathf.Infinity;
        // nearestEnemy
        Transform nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            float tempDistance = Vector3.Distance(enemy.transform.position, player.gameObject.transform.position);

            if (tempDistance < minDistance)
            {
                minDistance = tempDistance;
                nearestEnemy = enemy.transform;
            }

        }

        Debug.Log("Nearest enemy name: " + nearestEnemy.gameObject.name);
        
    }
}