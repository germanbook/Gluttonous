using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Attacking State
/// </summary>
public class AttackingState : IState
{
    private FSM_Mananger manager;

    public AttackingState(FSM_Mananger manager)
    {
        this.manager = manager;
    }

    public void OnEnter()
    {
        Debug.Log("Enter Attacking State...");
    }

    public void OnExit()
    {
        Debug.Log("Exit Attacking State...");
    }

    public void OnUpdate()
    {
        Debug.Log("Attacking State...");
    }
}