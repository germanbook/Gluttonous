using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeNetState : IState
{
    private FSM_Mananger manager;


    public DodgeNetState(FSM_Mananger manager)
    {
        this.manager = manager;
    }


    public void OnEnter()
    {
        Debug.Log("dodge animation");
        manager.animator.SetInteger("stateInt", 5);
        manager.gameObject.GetComponent<PlayerStatus_Temp>().isDodgeNet = true;
    }

    public void OnExit()
    {
        
    }

    public void OnUpdate()
    {
        
    }

}
