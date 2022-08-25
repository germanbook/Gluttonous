using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class SamnitesSkillManager : MonoBehaviour
{

    public SkillData skillData;
    GameObject opponent;

    // Attack and Skill timer
    float attackTimer;
    float skillTimer;

    /// <summary>
    /// Gladiator's timeline for this round
    /// </summary>
    float roundTimer;


    void Start()
    {
        // set timer equals to cooldown time
        // so gladiator can perform attack first
        // then start to counting cooldown time
        attackTimer = skillData.attackCooldown;
        skillTimer = skillData.skillCooldown;

        roundTimer = 0f;

        this.gameObject.transform.parent.gameObject.GetComponent<AIPath>().maxSpeed = skillData.speedValue;
    }

    
    void Update()
    {
        if (this.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking && opponent != null)
        {
            // Timer
            roundTimer += Time.deltaTime;
            attackTimer += Time.deltaTime;

            // Attack
            if (attackTimer > skillData.attackCooldown)
            {
                Attack();
                attackTimer = 0f;
            }

            // 

        }
    }

    public void GetOpponent(GameObject opponent)
    {
        this.opponent = opponent;
    }

    void Attack()
    {

        switch (opponent.gameObject.name)
        {
            case "Samnites":
                
                if (opponent.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    opponent.gameObject.GetComponent<SamnitesSkillManager>().ReceiveAttackDamage(this.gameObject.name,skillData.attackDamage);

                }

                break;

            case "Retiarius":
                
                if (opponent.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    opponent.gameObject.GetComponent<RetiariusSkillManager>().ReceiveAttackDamage(this.gameObject.name, skillData.attackDamage);

                }

                break;

            case "Murmillo":
                
                if (opponent.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    opponent.gameObject.GetComponent<MurmilloSkillManager>().ReceiveAttackDamage(this.gameObject.name, skillData.attackDamage);

                }

                break;

            case "Threax":
                
                if (opponent.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    opponent.gameObject.GetComponent<ThraexSkillManager>().ReceiveAttackDamage(this.gameObject.name, skillData.attackDamage);

                }

                break;
        }
    }

    // parameters: attacker's name and attack damage
    public void ReceiveAttackDamage(string attacker, float damage)
    {
        // 50% chace to block attack
        if (Random.Range(1, 11) > 5)
        {
            this.gameObject.GetComponent<PlayerStatus_Temp>().healthValue -= (damage * 0.7f);
            Debug.Log("I'm S, block failed!");
        }
        else
        {

            if (this.gameObject.GetComponent<PlayerPosition>().isNetted == false)
            {
                Debug.Log("I'm S, Attack blocked!");
                this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Block);
            }
            else
            {
                Debug.Log("I'm netted, cant block");
            }
            
        }
    }

    public void ReceiveSkillDamage(string attacker, float damage)
    {
        // attacker is Retiarius
        // Neting attacking
        if (attacker == "Retiarius")
        {

        }
    }

    // calling by block animation
    public void blockFinished()
    {
        Debug.Log("block finished");
        this.gameObject.GetComponent<PlayerStatus_Temp>().isBlocking = false;

        if (this.gameObject.GetComponent<FSM_Mananger>().targetPlayer.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true
            && this.gameObject.GetComponent<TargetFinder>().nearestEnemy.gameObject.
            GetComponent<TargetFinder>().nearestEnemy.gameObject.name == this.gameObject.name)
        {
            Debug.Log("Back to attack");
            this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Attacking);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Net" &&
            GameObject.ReferenceEquals(collision.gameObject.GetComponent<NetBehaviour>().target.gameObject, this.gameObject))
        {
            this.gameObject.GetComponent<PlayerPosition>().isNetted = true;
            collision.gameObject.GetComponent<NetBehaviour>().OnTriggerEnter2D(this.gameObject.GetComponent<CircleCollider2D>());
            collision.gameObject.GetComponent<NetBehaviour>().StartNetTimer();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Net" &&
            GameObject.ReferenceEquals(collision.gameObject.GetComponent<NetBehaviour>().target.gameObject, this.gameObject))
        {
            this.gameObject.GetComponent<PlayerPosition>().isNetted = false;
        }
    }

}
