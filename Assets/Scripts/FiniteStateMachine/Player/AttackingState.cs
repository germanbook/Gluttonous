using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
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
        
        switch (manager.gameObject.name)
        {
            
            case "Samnites":
                manager.gameObject.GetComponent<SamnitesSkillManager>().GetOpponent(manager.targetPlayer);
                break;
            case "Retiarius":
                manager.gameObject.GetComponent<RetiariusSkillManager>().GetOpponent(manager.targetPlayer);
                break;
            case "Murmillo":
                manager.gameObject.GetComponent<MurmilloSkillManager>().GetOpponent(manager.targetPlayer);
                break;
            case "Threax":
                manager.gameObject.GetComponent<ThraexSkillManager>().GetOpponent(manager.targetPlayer);
                break;
        }

    }
}
