using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Finding State
/// </summary>
public class FindingState : IState
{
    private FSM_Mananger manager;

    public FindingState(FSM_Mananger manager)
    {
        this.manager = manager;
    }

    public void OnEnter()
    {
        manager.animator.SetInteger("stateInt", 1);
    }

    public void OnExit()
    {
        
    }

    public void OnUpdate()
    {
        
    }
}
