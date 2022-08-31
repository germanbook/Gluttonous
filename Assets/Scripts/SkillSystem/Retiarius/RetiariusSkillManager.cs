using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class RetiariusSkillManager : MonoBehaviour
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

    // throw net
    public bool isThrowNet;
    public GameObject ProjectPrefab;
    public Transform LaunchOffset;


    void Start()
    {
        // set timer equals to cooldown time
        // so gladiator can perform attack first
        // then start to counting cooldown time
        attackTimer = skillData.attackCooldown;
        skillTimer = skillData.skillCooldown;

        roundTimer = 0f;

        isThrowNet = false;

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
            if (attackTimer > skillData.attackCooldown && isThrowNet == false)
            {
                Attack();
                attackTimer = 0f;
            }

            //// Testing...
            //// Throw net three seconds after this round begins
            //if (skillTimer > skillData.skillCooldown && roundTimer > 3)
            //{
            //    SkillAttack();
            //    skillTimer = 0f;
            //}

            

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

                if (opponent.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true
                    || opponent.gameObject.GetComponent<PlayerPosition>().isNetted == true)
                {
                    opponent.gameObject.GetComponent<SamnitesSkillManager>().ReceiveAttackDamage(this.gameObject, skillData.attackDamage);

                }

                break;

            case "Retiarius":
                
                if (opponent.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true
                    || opponent.gameObject.GetComponent<PlayerPosition>().isNetted == true)
                {
                    opponent.gameObject.GetComponent<RetiariusSkillManager>().ReceiveAttackDamage(this.gameObject.name, skillData.attackDamage);

                }

                break;

            case "Murmillo":
                
                if (opponent.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true
                    || opponent.gameObject.GetComponent<PlayerPosition>().isNetted == true)
                {
                    opponent.gameObject.GetComponent<MurmilloSkillManager>().ReceiveAttackDamage(this.gameObject, skillData.attackDamage);

                }

                break;

            case "Threax":
                
                if (opponent.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true
                    || opponent.gameObject.GetComponent<PlayerPosition>().isNetted == true)
                {
                    opponent.gameObject.GetComponent<ThraexSkillManager>().ReceiveAttackDamage(this.gameObject.name, skillData.attackDamage);

                }

                break;
        }
    }

    // Throw net
    public void SkillAttack(Transform nearestEnemy)
    {
        isThrowNet = false;
        if (nearestEnemy.gameObject.activeSelf == true)
        {
            // instantialize net object
            Instantiate(ProjectPrefab, LaunchOffset.position, transform.rotation).transform.SetParent(this.transform);
            

            if ((GameObject.ReferenceEquals(nearestEnemy.gameObject.GetComponent<TargetFinder>().nearestEnemy.gameObject, this.gameObject)
                &&
                nearestEnemy.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                ||
                (GameObject.ReferenceEquals(nearestEnemy.gameObject.GetComponent<TargetFinder>().nearestEnemy.gameObject, this.gameObject)
                && nearestEnemy.gameObject.name == "Retiarius" && (nearestEnemy.gameObject.transform.position - this.gameObject.transform.position).magnitude < 1.5)
                )
            {
                this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Attacking);
            }
        }
        else
        {
            this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Idle);
        }

        

    }

    public void ReceiveAttackDamage(string attacker, float damage)
    {
        this.gameObject.GetComponent<PlayerStatus_Temp>().healthValue -= (damage * 1f);
    }


    // -----
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Net" &&
            GameObject.ReferenceEquals(collision.gameObject.GetComponent<NetBehaviour>().target.gameObject, this.gameObject))
        {
            this.gameObject.GetComponent<PlayerPosition>().isNetted = true;
            collision.gameObject.GetComponent<NetBehaviour>().OnTriggerEnter2D(this.gameObject.GetComponent<CircleCollider2D>());
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
