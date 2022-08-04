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
        manager.GetComponent<PlayerStatus_Temp>().playerLifeBarState.sprite
            = manager.GetComponent<PlayerStatus_Temp>().attackStateImage;

        // Freeze location when enter attacking state
        manager.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

        // Is attacking 
        manager.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking = true;
        
    }

    public void OnExit()
    {
        // Is attacking 
        manager.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking = false;
        
    }

    public void OnUpdate()
    {
        if (manager.targetPlayer != null)
        {
            manager.gameObject.GetComponent<GladiatorAttack>().PlayerAttackding(manager.targetPlayer);
        }
    }
}
