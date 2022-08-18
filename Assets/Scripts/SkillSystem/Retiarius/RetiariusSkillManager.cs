using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class RetiariusSkillManager : MonoBehaviour
{
    [SerializeField] SkillData skillData;
    GameObject opponent;

    // Attack and Skill timer
    float attackTimer;
    float skillTimer;

    /// <summary>
    /// Gladiator's timeline for this round
    /// </summary>
    float roundTimer;

    // throw net
    bool isThrowNet;


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

            // Attack
            if (attackTimer > skillData.attackCooldown && isThrowNet == false)
            {
                Attack();
                attackTimer = 0f;
            }

            // Testing...
            // Throw net three seconds after this round begins
            if (skillTimer > skillData.skillCooldown && roundTimer > 3)
            {
                SkillAttack();
                skillTimer = 0f;
            }

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

            case "Thraex":
                Debug.Log("I'm R attacking T");
                if (opponent.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    opponent.gameObject.GetComponent<ThraexSkillManager>().ReceiveAttackDamage(this.gameObject.name, skillData.attackDamage);

                }

                break;
        }
    }

    // Throw net
    void SkillAttack()
    {
        isThrowNet = true;
    }

    // Call this function when net animation finish
    // Call from animation event
    void SkillAttackFinish()
    {
        isThrowNet = false;
    }

    public void ReceiveAttackDamage(string attacker, float damage)
    {
        this.gameObject.GetComponent<PlayerStatus_Temp>().healthValue -= (damage * 1f);
    }
}
