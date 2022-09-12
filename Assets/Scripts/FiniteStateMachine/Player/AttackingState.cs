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

    // attacking timer
    float attackTimer;


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

                // Get attack timer
                attackTimer = manager.gameObject.GetComponent<SamnitesSkillManager>().attackTimer;

                if (attackTimer > manager.gameObject.GetComponent<SamnitesSkillManager>().skillData.attackCooldown)
                {
                    Debug.Log("Samnites Attack");
                    manager.animator.Play("Samnite_Attack", -1, 0f);
                    manager.gameObject.GetComponent<SamnitesSkillManager>().attackTimer = 0f;
                }

                break;
            case "Retiarius":
                manager.gameObject.GetComponent<RetiariusSkillManager>().GetOpponent(manager.targetPlayer);

                attackTimer = manager.gameObject.GetComponent<RetiariusSkillManager>().attackTimer;

                if (attackTimer > manager.gameObject.GetComponent<RetiariusSkillManager>().skillData.attackCooldown)
                {
                    Debug.Log("Retiarius Attack");
                    manager.animator.Play("Retiarius_Attack", -1, 0f);
                    manager.gameObject.GetComponent<RetiariusSkillManager>().attackTimer = 0f;
                }

                break;
            case "Murmillo":
                
                manager.gameObject.GetComponent<MurmilloSkillManager>().GetOpponent(manager.targetPlayer);

                attackTimer = manager.gameObject.GetComponent<MurmilloSkillManager>().attackTimer;
                
                if (attackTimer > manager.gameObject.GetComponent<MurmilloSkillManager>().skillData.attackCooldown)
                {
                    Debug.Log("Murmillo Attack");
                    manager.animator.Play("Murmillo_Attack", -1, 0f);

                    manager.gameObject.GetComponent<MurmilloSkillManager>().attackTimer = 0f;
                }

                break;
            case "Threax":
                manager.gameObject.GetComponent<ThraexSkillManager>().GetOpponent(manager.targetPlayer);

                attackTimer = manager.gameObject.GetComponent<ThraexSkillManager>().attackTimer;

                if (attackTimer > manager.gameObject.GetComponent<ThraexSkillManager>().skillData.attackCooldown)
                {
                    Debug.Log("Threax Attack");
                    manager.animator.Play("Threax_Attack", -1, 0f);

                    manager.gameObject.GetComponent<ThraexSkillManager>().attackTimer = 0f;
                }

                break;
        }

    }
}
