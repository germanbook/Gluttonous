using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : IState
{

    private FSM_Mananger manager;

    public BlockState(FSM_Mananger manager)
    {
        this.manager = manager;
    }

    public void OnEnter()
    {
        manager.animator.SetInteger("stateInt", 4);
        
        // Is blocking 
        manager.gameObject.GetComponent<PlayerStatus_Temp>().isBlocking = true;
    }

    public void OnExit()
    {
        // Is blocking 
        manager.gameObject.GetComponent<PlayerStatus_Temp>().isBlocking = false;
    }

    public void OnUpdate()
    {
        
    }

}
