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
                Debug.Log("I'm R attacking S");
                if (opponent.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    opponent.gameObject.GetComponent<SamnitesSkillManager>().ReceiveAttackDamage(this.gameObject.name, skillData.attackDamage);

                }

                break;

            case "Retiarius":
                Debug.Log("I'm R attacking R");
                if (opponent.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    opponent.gameObject.GetComponent<RetiariusSkillManager>().ReceiveAttackDamage(this.gameObject.name, skillData.attackDamage);

                }

                break;

            case "Murmillo":
                Debug.Log("I'm R attacking M");
                if (opponent.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    opponent.gameObject.GetComponent<MurmilloSkillManager>().ReceiveAttackDamage(this.gameObject.name, skillData.attackDamage);

                }

                break;

            case "Threax":
                Debug.Log("I'm R attacking T");
                if (opponent.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    opponent.gameObject.GetComponent<ThraexSkillManager>().ReceiveAttackDamage(this.gameObject.name, skillData.attackDamage);

                }

                break;
        }
    }

    // Throw net
    public void SkillAttack(Transform nearestEnemy)
    {

        // instantialize net object
        Instantiate(ProjectPrefab, LaunchOffset.position, transform.rotation).transform.SetParent(this.transform);
        isThrowNet = false;

        if (nearestEnemy.gameObject.GetComponent<TargetFinder>().nearestEnemy.gameObject.name == this.gameObject.name

            &&

            nearestEnemy.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
        {
            this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Attacking);
        }

    }

    public void ReceiveAttackDamage(string attacker, float damage)
    {
        this.gameObject.GetComponent<PlayerStatus_Temp>().healthValue -= (damage * 1f);
    }
}
