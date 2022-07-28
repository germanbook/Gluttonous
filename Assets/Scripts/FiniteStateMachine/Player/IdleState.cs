using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Idle state
/// </summary>
public class IdleState : IState
{
    private FSM_Mananger manager;

    public IdleState(FSM_Mananger manager)
    {
        this.manager = manager;
    }

    public void OnEnter()
    {
        manager.animator.SetInteger("stateInt", 0);
    }

    public void OnExit()
    {
        // TODO: Using manager to get play's state to
        // exit the idle
        // ex. manager.TransitionState();
        Debug.Log("Exit Idle State...");
    }

    public void OnUpdate()
    {
        // Debug.Log("Idle State...");
    }

}
