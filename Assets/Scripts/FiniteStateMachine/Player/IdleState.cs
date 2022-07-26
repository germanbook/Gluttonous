using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Idle state
/// </summary>
public class IdleState : IState
{
    private BaseFSM manager;

    public IdleState(BaseFSM manager)
    {
        this.manager = manager;
    }

    public void OnEnter()
    {
        Debug.Log("Enter Idle State...");
    }

    public void OnExit()
    {
        Debug.Log("Exit Idle State...");
    }

    public void OnUpdate()
    {
        Debug.Log("Idle State...");
    }

}
