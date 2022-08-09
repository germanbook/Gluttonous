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
        manager.GetComponent<PlayerStatus_Temp>().playerLifeBarState.sprite
            = manager.GetComponent<PlayerStatus_Temp>().idleStateImage;
    }

    public void OnExit()
    {
        // TODO: Using manager to get play's state to
        // exit the idle
        // ex. manager.TransitionState();
        
    }

    public void OnUpdate()
    {
        // Debug.Log("Idle State...");
    }

}
