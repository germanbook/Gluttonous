using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class ThraexSkillManager : MonoBehaviour
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
            skillTimer += Time.deltaTime;

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
                    opponent.gameObject.GetComponent<SamnitesSkillManager>().ReceiveAttackDamage(this.gameObject, skillData.attackDamage);

                    // if opponent is blocking
                    if (opponent.gameObject.GetComponent<PlayerStatus_Temp>().isBlocking == true)
                    {

                        if (skillTimer > skillData.skillCooldown)
                        {
                            // perform side attack
                            this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.SideAttack);

                            opponent.gameObject.GetComponent<SamnitesSkillManager>().ReceiveSkillDamage(this.gameObject.name, skillData.attackDamage);

                            skillTimer = 0f;
                        }
                        
                    }
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
                    opponent.gameObject.GetComponent<MurmilloSkillManager>().ReceiveAttackDamage(this.gameObject, skillData.attackDamage);

                    // if opponent is blocking
                    if (opponent.gameObject.GetComponent<PlayerStatus_Temp>().isBlocking == true)
                    {

                        if (skillTimer > skillData.skillCooldown)
                        {
                            // perform side attack
                            this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.SideAttack);

                            opponent.gameObject.GetComponent<MurmilloSkillManager>().ReceiveSkillDamage(this.gameObject.name, skillData.attackDamage);

                            skillTimer = 0f;
                        }

                    }

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

    public void ReceiveAttackDamage(string attacker, float damage)
    {
        this.gameObject.GetComponent<PlayerStatus_Temp>().healthValue -= (damage * 0.7f);
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

    // calling by side attack animation
    public void sideAttackFinished()
    {
        Debug.Log("side attack finished");
        
        if (this.gameObject.GetComponent<FSM_Mananger>().targetPlayer.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true
            && this.gameObject.GetComponent<TargetFinder>().nearestEnemy.gameObject.
            GetComponent<TargetFinder>().nearestEnemy.gameObject.name == this.gameObject.name
            ||
            this.gameObject.GetComponent<FSM_Mananger>().targetPlayer.gameObject.GetComponent<PlayerStatus_Temp>().isBlocking == true
            && this.gameObject.GetComponent<TargetFinder>().nearestEnemy.gameObject.
            GetComponent<TargetFinder>().nearestEnemy.gameObject.name == this.gameObject.name)
        {
            Debug.Log("Thraex back to attack");
            this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Attacking);
        }
        this.gameObject.GetComponent<PlayerStatus_Temp>().isSideAttacking = false;
    }

    public void dodgeNet()
    {
        // 50% chace to dodge net
        if (Random.Range(1, 11) > 5)
        {
            // dodged
            Debug.Log(">>>>>>>>>>>>>I'm dodged the net>>>>>>>>>>>>");
            this.gameObject.GetComponent<PlayerStatus_Temp>().isDodgeNet = true;
        }
        else
        {
            // dodge fail
            Debug.Log(">>>>>>>>>>>>>Dodge net failed!>>>>>>>>>>>>");
            this.gameObject.GetComponent<PlayerStatus_Temp>().isDodgeNet = false;
        }
    }
}
