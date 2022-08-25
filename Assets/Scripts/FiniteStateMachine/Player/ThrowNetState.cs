using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class ThrowNetState : IState
{

    private FSM_Mananger manager;


    public ThrowNetState(FSM_Mananger manager)
    {
        this.manager = manager;
    }


    public void OnEnter()
    {
        manager.gameObject.GetComponent<RetiariusSkillManager>().isThrowNet = true;
        
        manager.animator.SetInteger("stateInt", 4);
        // Freeze location when enter attacking state
        manager.gameObject.transform.parent.gameObject.GetComponent<AIPath>().maxSpeed = 0f;


    }

    public void OnExit()
    {
        
    }

    public void OnUpdate()
    {
        
    }

}
