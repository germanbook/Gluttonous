using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Attacking State
/// </summary>
public class DeathState : IState
{
    private FSM_Mananger manager;

    public DeathState(FSM_Mananger manager)
    {
        this.manager = manager;
    }

    public void OnEnter()
    {
        manager.gameObject.GetComponent<PlayerStatus_Temp>().isAlive = false;
        manager.animator.SetInteger("stateInt", 3);
    }

    public void OnExit()
    {
        
    }

    public void OnUpdate()
    {
        
    }
}
