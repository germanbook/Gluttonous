using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideAttackState : IState
{

    private FSM_Mananger manager;


    public SideAttackState(FSM_Mananger manager)
    {
        this.manager = manager;
    }


    public void OnEnter()
    {
        manager.animator.SetInteger("stateInt", 4);

        // Is side attacking 
        manager.gameObject.GetComponent<PlayerStatus_Temp>().isSideAttacking = true;
    }

    public void OnExit()
    {
        
    }

    public void OnUpdate()
    {
        
    }

}
