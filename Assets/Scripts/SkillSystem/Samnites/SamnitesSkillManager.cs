using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class SamnitesSkillManager : MonoBehaviour
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
                Debug.Log("I'm S attacking S");
                if (opponent.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    opponent.gameObject.GetComponent<SamnitesSkillManager>().ReceiveAttackDamage(this.gameObject.name,skillData.attackDamage);

                }

                break;

            case "Retiarius":
                Debug.Log("I'm S attacking R");
                if (opponent.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    opponent.gameObject.GetComponent<RetiariusSkillManager>().ReceiveAttackDamage(this.gameObject.name, skillData.attackDamage);

                }

                break;

            case "Murmillo":
                Debug.Log("I'm S attacking M");
                if (opponent.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    opponent.gameObject.GetComponent<MurmilloSkillManager>().ReceiveAttackDamage(this.gameObject.name, skillData.attackDamage);

                }

                break;

            case "Thraex":
                Debug.Log("I'm S attacking T");
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
            Debug.Log("I'm S, Attack blocked!");
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


}
