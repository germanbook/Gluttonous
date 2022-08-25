using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class TargetFinder : MonoBehaviour
{
    // nearestEnemy
    public Transform nearestEnemy;

    public Transform tempTarget;

    public GameObject arenaSceneManager;

    private bool isWon;

    private int originalCurrency;


    // this distance if for throw net
    float distance;

    // For Retiarius use only!
    // Attack and Skill timer
    float skillTimer;
    // ======================


    private void Start()
    {

        originalCurrency = GameObject.FindGameObjectWithTag("CurrencyValue").GetComponent<Currency>().currencyValue;
        isWon = false;
        arenaSceneManager = GameObject.FindGameObjectWithTag("ArenaSceneManager");
        nearestEnemy = this.transform;
        // Finding target
        Invoke("FindTarget", 0.2f);

        if (this.gameObject.name == "Retiarius")
        {
            // Retiarius vs Retiarius
            if (this.gameObject.tag == "Player")
            {
                skillTimer = this.gameObject.GetComponent<RetiariusSkillManager>().skillData.skillCooldown;
            }
            else
            {
                skillTimer = 3f;
            }

        }
        
            
    }

    private void FixedUpdate()
    {
        skillTimer += Time.deltaTime;

        //Change target when it die
        if ((this.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == false
            && this.gameObject.GetComponent<PlayerStatus_Temp>().isAlive == true)
            || (nearestEnemy.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true
                 && nearestEnemy.gameObject.GetComponent<FSM_Mananger>().targetPlayer.gameObject.name != this.gameObject.name)
            )
        {
            //if (this.gameObject.name != "Retiarius")
            //{
            //    nearestEnemy = tempTarget;
            //    FindTarget();
            //}
            //else
            //{
            //    if (this.gameObject.GetComponent<RetiariusSkillManager>().isThrowNet == false)
            //    {
            //        nearestEnemy = tempTarget;
            //        FindTarget();
            //    }
            //}

            // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            if (this.gameObject.name == "Retiarius")
            {
                if (this.gameObject.GetComponent<RetiariusSkillManager>().isThrowNet == false
                    && this.gameObject.GetComponent<PlayerPosition>().isNetted == false)
                {
                    nearestEnemy = tempTarget;
                    FindTarget();
                }
                
            }
            else
            {
                if (this.gameObject.name == "Murmillo" || this.gameObject.name == "Samnites")
                {
                    if (this.gameObject.GetComponent<PlayerStatus_Temp>().isBlocking == false)
                    {
                        nearestEnemy = tempTarget;
                        FindTarget();
                    }
                }
                else
                {
                    nearestEnemy = tempTarget;
                    FindTarget();
                }

                
            }
            // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


        }

        if (isWon)
        {
            increaseGold();
        }


        if (this.gameObject.name == "Retiarius"
            && nearestEnemy.gameObject.activeSelf == true)
        {
            AttackThrowNetAnimationStart();
        }

    }


    // Find all enemies
    private void FindTarget()
    {
        string targetTag = "";

        if (this.gameObject.tag == "Player")
        {
            // Find nearest target
            targetTag = "Enemy";
        }
        else
        if (this.gameObject.tag == "Enemy")
        {
            targetTag = "Player";
        }

        // All enemies in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetTag);

        float minDistance = Mathf.Infinity;


        foreach (var enemy in enemies)
        {
            float tempDistance = Vector2.Distance(enemy.transform.position, this.gameObject.transform.position);

            if (tempDistance < minDistance
                && enemy.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == false
                && enemy.gameObject.GetComponent<PlayerStatus_Temp>().isAlive == true
                && enemy.gameObject.GetComponent<PlayerStatus_Temp>().isBlocking == false
                ||
                tempDistance < minDistance
                && enemy.gameObject.GetComponent<TargetFinder>().nearestEnemy == this.gameObject.transform
                && enemy.gameObject.GetComponent<PlayerStatus_Temp>().isAlive == true
                && enemy.gameObject.GetComponent<PlayerStatus_Temp>().isBlocking == false
                )
            {
                minDistance = tempDistance;
                nearestEnemy = enemy.transform;
            }
        }


        if (enemies.Length != 0)
        {


            if (nearestEnemy != tempTarget)
            {
                if (arenaSceneManager.GetComponent<ArenaSceneManager>().isPause == false)
                {

                    if (this.gameObject.name == "Retiarius")
                    {
                        if (this.gameObject.GetComponent<RetiariusSkillManager>().isThrowNet == false
                            && this.gameObject.GetComponent<PlayerPosition>().isNetted == false)
                        {
                            if (nearestEnemy.gameObject.name == "Retiarius")
                            {
                                if (nearestEnemy.gameObject.GetComponent<RetiariusSkillManager>().isThrowNet == false)
                                {
                                    
                                    this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Finding);
                                    SetTarget(nearestEnemy);
                                }
                            }
                            else
                            {
                                
                                this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Finding);
                                SetTarget(nearestEnemy);
                            }
                            
                        }
                    }

                    if(this.gameObject.name != "Retiarius")
                    {
                        if (nearestEnemy.gameObject.name == "Retiarius")
                        {
                            if (nearestEnemy.gameObject.GetComponent<RetiariusSkillManager>().isThrowNet == false)
                            {
                                this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Finding);
                                SetTarget(nearestEnemy);
                            }
                            else
                            {
                                this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Idle);
                                SetTarget(this.transform);
                            }
                        }
                        else
                        {
                            this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Finding);
                            SetTarget(nearestEnemy);
                        }
                            

                    }


                    
                }
                    
            }
            else
            if (nearestEnemy == tempTarget)
            {
                this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Idle);
                SetTarget(this.transform);
            }
            
        }
        if (enemies.Length == 0)
        {

            if (this.gameObject.GetComponent<PlayerStatus_Temp>().isAlive)
            {
                SetTarget(this.gameObject.transform );
                this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Idle);

                isWon = true;

            }
        }

    }

    // Set target's destination
    public void SetTarget(Transform targetTransform)
    {

        // Set target to A* pathfinding
        this.gameObject.transform.parent.gameObject.GetComponent<AIDestinationSetter>().target = targetTransform;

    }

    void increaseGold()
    {
        if (GameObject.FindGameObjectWithTag("CurrencyValue").GetComponent<Currency>().currencyValue - originalCurrency < 50)
        {
            GameObject.FindGameObjectWithTag("CurrencyValue").GetComponent<Currency>().currencyValue += 50;
        }
        
    }

    // Throw net before they approached
    public void AttackThrowNetAnimationStart()
    {

        if (nearestEnemy != tempTarget && arenaSceneManager.GetComponent<ArenaSceneManager>().isPause == false)
        {


            if (skillTimer >= this.gameObject.GetComponent<RetiariusSkillManager>().skillData.skillCooldown
                && this.gameObject.GetComponent<PlayerPosition>().isNetted == false)
            {
                if (GameObject.ReferenceEquals(nearestEnemy.gameObject.GetComponent<TargetFinder>().nearestEnemy.gameObject, this.gameObject))
                {

                    distance = (nearestEnemy.position - this.gameObject.transform.position).magnitude;

                    if (distance < 10)
                    {

                        this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.ThrowNet);


                        skillTimer = 0f;

                    }
                }


            }
        }


        
    }

    public void AttackThrowNetStart()
    {
        this.gameObject.transform.parent.gameObject.GetComponent<AIPath>().maxSpeed =
            this.gameObject.GetComponent<RetiariusSkillManager>().skillData.speedValue;
        this.gameObject.GetComponent<RetiariusSkillManager>().SkillAttack(nearestEnemy);
    }
}
