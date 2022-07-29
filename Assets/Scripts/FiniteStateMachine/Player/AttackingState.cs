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
        manager.animator.SetInteger("stateInt", 2);
    }

    public void OnExit()
    {
        
    }

    public void OnUpdate()
    {
        if (manager.targetPlayer != null)
        {
            manager.targetPlayer.GetComponent<PlayerStatus_Temp>().healthValue -= Time.deltaTime * 30;
        }
    }
}
