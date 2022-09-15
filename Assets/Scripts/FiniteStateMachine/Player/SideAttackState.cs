using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideAttackState : IState
{

    private FSM_Mananger manager;
    // skill attacking timer
    float skillTimer;

    public SideAttackState(FSM_Mananger manager)
    {
        this.manager = manager;
    }


    public void OnEnter()
    {
        Debug.Log("Threax Side Attack >>> >>> enter");

        manager.animator.SetInteger("stateInt", 4);

        manager.GetComponent<PlayerStatus_Temp>().playerLifeBarState.sprite
                = manager.GetComponent<PlayerStatus_Temp>().attackStateImage;
        // Is side attacking 
        manager.gameObject.GetComponent<PlayerStatus_Temp>().isSideAttacking = true;
        // Is attacking 
        manager.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking = true;
    }

    public void OnExit()
    {
        // Is side attacking 
        manager.gameObject.GetComponent<PlayerStatus_Temp>().isSideAttacking = false;
        // Is attacking 
        manager.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking = false;
    }

    public void OnUpdate()
    {
       manager.gameObject.GetComponent<ThraexSkillManager>().GetOpponent(manager.targetPlayer);

        // Get skill timer
        skillTimer = manager.gameObject.GetComponent<ThraexSkillManager>().skillTimer;

        if (skillTimer > manager.gameObject.GetComponent<ThraexSkillManager>().skillData.skillCooldown)
        {
            Debug.Log("Threax Side Attack >>> >>>");
            manager.animator.Play("Threax_SideAttack", -1, 0f);
            manager.gameObject.GetComponent<ThraexSkillManager>().skillTimer = 0f;
        }


    }

}
