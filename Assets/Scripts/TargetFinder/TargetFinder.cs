using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pathfinding;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.EventTrigger;
using Random = UnityEngine.Random;

public class TargetFinder : MonoBehaviour
{
    // nearestEnemy
    public Transform nearestEnemy;

    public Transform tempTarget;

    // Throw net bait enemy
    public Transform baitEnemy;

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
            //// Retiarius vs Retiarius
            //if (this.gameObject.tag == "Player")
            //{
            skillTimer = this.gameObject.GetComponent<RetiariusSkillManager>().skillData.skillCooldown;
            //}
            //else
            //{
            //    skillTimer = 3f;
            //}

        }
        
            
    }

    private void FixedUpdate()
    {
        skillTimer += Time.deltaTime;

        if (nearestEnemy != null)
        {
            if (nearestEnemy.gameObject.activeSelf == false)
            {
                nearestEnemy = tempTarget;
                FindTarget();
            }
        }

        if (nearestEnemy != null)
        {
            //Change target when it die
            if ((this.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == false
                && this.gameObject.GetComponent<PlayerStatus_Temp>().isAlive == true)
                || (nearestEnemy.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true
                     && nearestEnemy.gameObject.GetComponent<FSM_Mananger>().targetPlayer.gameObject.name != this.gameObject.name)
                )
            {

                // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                if (this.gameObject.name == "Retiarius")
                {
                    if (this.gameObject.GetComponent<RetiariusSkillManager>().isThrowNet == false)
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
                    if (this.gameObject.name == "Threax")
                    {

                        if (this.gameObject.GetComponent<PlayerStatus_Temp>().isSideAttacking == false
                            && this.gameObject.GetComponent<PlayerStatus_Temp>().isDodgeNet == false)
                        {
                            nearestEnemy = tempTarget;
                            FindTarget();
                        }

                    }


                }
                // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                if (this.gameObject.name == "Retiarius")
                {
                    if (nearestEnemy.gameObject.name == "Retiarius")
                    {
                        this.gameObject.GetComponent<CircleCollider2D>().radius = 0.71f;
                    }

                    if (nearestEnemy.gameObject.name != "Retiarius")
                    {
                        this.gameObject.GetComponent<CircleCollider2D>().radius = 1.5f;
                    }
                }

            }
        }

        if (isWon)
        {
            increaseGold();

            switch (SceneManager.GetActiveScene().name)
            {
                case "The Arena1":
                    GameManager.isArenaTwoUnlock = true;
                    break;
                case "The Arena2":
                    GameManager.isArenaThreeUnlock = true;
                    break;
            }
        }


        if (this.gameObject.name == "Retiarius"
            && nearestEnemy.gameObject.activeSelf == true
            && this.gameObject.GetComponent<PlayerStatus_Temp>().isFinding == true)
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
                && enemy.gameObject.GetComponent<PlayerStatus_Temp>().isSideAttacking == false
                && enemy.gameObject.GetComponent<PlayerPosition>().isNetted == false
                ||
                tempDistance < minDistance
                && GameObject.ReferenceEquals(enemy.gameObject.GetComponent<TargetFinder>().nearestEnemy.gameObject, this.gameObject)
                //&& enemy.gameObject.GetComponent<PlayerStatus_Temp>().isAlive == true
                //&& enemy.gameObject.GetComponent<PlayerStatus_Temp>().isBlocking == false
                //&& enemy.gameObject.GetComponent<PlayerStatus_Temp>().isSideAttacking == false
                )
            {
                if (this.gameObject.name == "Retiarius")
                {

                    if (GameObject.ReferenceEquals(enemy.gameObject.GetComponent<TargetFinder>().nearestEnemy.gameObject, this.gameObject))
                    {
                        minDistance = tempDistance;
                        nearestEnemy = enemy.transform;
                    }
                    else
                    {
                        if (enemy.gameObject.name != "Retiarius")
                        {
                            minDistance = tempDistance;
                            nearestEnemy = enemy.transform;
                        }
                        if (enemy.gameObject.name == "Retiarius"
                            && enemy.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == false
                            && enemy.gameObject.GetComponent<RetiariusSkillManager>().isThrowNet == false)
                        {
                            minDistance = tempDistance;
                            nearestEnemy = enemy.transform;
                        }
                    }

                    //if (enemy.gameObject.name == "Retiarius" && enemy.gameObject.GetComponent<TargetFinder>().nearestEnemy.gameObject == tempTarget)
                    //{
                    //    minDistance = tempDistance;
                    //    nearestEnemy = enemy.transform;
                    //}


                }
                else
                {
                    minDistance = tempDistance;
                    nearestEnemy = enemy.transform;
                }
                
    
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
                        // Enemy Retiarius
                        // Set bait
                        if (this.gameObject.tag == "Enemy")
                        {
                            if (this.gameObject.GetComponent<PlayerStatus_Temp>().isThowedBaitNet == false)
                            {
                                for (int i = 0; i < enemies.Length; i++)
                                {

                                    // find player threax as bait
                                    if (enemies[i].gameObject.name == "Threax"
                                        && enemies[i].gameObject.tag == "Player")
                                    {
                                        if (enemies[i].gameObject.GetComponent<PlayerStatus_Temp>().hasDodgedNet == false)
                                        {
                                            baitEnemy = enemies[i].gameObject.transform;
                                            

                                        }
                                        i = enemies.Length;
                                        this.gameObject.GetComponent<PlayerStatus_Temp>().isThowedBaitNet = true;
                                    }

                                }
                                
                            }

                            if (this.gameObject.GetComponent<PlayerStatus_Temp>().isThowedBaitNet == true)
                            {
                                for (int i = 0; i < enemies.Length; i++)
                                {

                                    if (enemies[i].gameObject.name == "Retiarius"
                                        && enemies[i].gameObject.tag == "Player"
                                        && enemies[i].gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == false)
                                    {
                                        if (enemies[i].gameObject.GetComponent<PlayerStatus_Temp>().hasDodgedNet == false)
                                        {
                                            nearestEnemy = enemies[i].gameObject.transform;


                                        }
                                        i = enemies.Length;
                                    }

                                }
                            }

                            
                            this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Finding);
                            SetTarget(nearestEnemy);

                        }
                        else
                        {
                            if (this.gameObject.GetComponent<RetiariusSkillManager>().isThrowNet == false
                                && this.gameObject.GetComponent<PlayerPosition>().isNetted == false)
                            {
                                for (int i = 0; i < enemies.Length; i++)
                                {
                                    if (enemies[i].gameObject.name == "Murmillo"
                                        && enemies[i].gameObject.tag == "Enemy"
                                        && GameObject.ReferenceEquals(enemies[i].gameObject.GetComponent<TargetFinder>().nearestEnemy.gameObject, this.gameObject))
                                    {
                                        nearestEnemy = enemies[i].gameObject.transform;
                                    }
                                }
                                

                            }
                            this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Finding);
                            SetTarget(nearestEnemy);

                        }
                         

                        //if (nearestEnemy.gameObject.name == "Retiarius")
                        //{
                        //    if (nearestEnemy.gameObject.GetComponent<RetiariusSkillManager>().isThrowNet == false)
                        //    {
                        //        this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Finding);
                        //        SetTarget(nearestEnemy);
                        //    }

                        //}
                        

                        

                        
                    }

                    if (this.gameObject.name == "Samnites")
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
                            if (this.gameObject.tag == "Player")
                            {
                      
                                for (int i = 0; i < enemies.Length; i++)
                                {
                                    if (enemies[i].gameObject.name == "Retiarius"
                                        && enemies[i].gameObject.tag == "Enemy"
                                        && enemies[i].gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == false)
                                    {
                                        nearestEnemy = enemies[i].gameObject.transform;
                                    }
                                }
                            }
                            
                            this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Finding);
                            SetTarget(nearestEnemy);
                        }
                    }

                    if (this.gameObject.name == "Murmillo")
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
                            if (this.gameObject.tag == "Enemy")
                            {

                                for (int i = 0; i < enemies.Length; i++)
                                {
                                    if (enemies[i].gameObject.name == "Retiarius"
                                        && enemies[i].gameObject.tag == "Player")
                                    {
                                        nearestEnemy = enemies[i].gameObject.transform;
                                    }
                                }
                            }

                            this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Finding);
                            SetTarget(nearestEnemy);
                        }

                    }

                    if (this.gameObject.name == "Threax")
                    {
                        if (nearestEnemy.gameObject.name == "Retiarius")
                        {
                            if (this.gameObject.GetComponent<PlayerStatus_Temp>().hasDodgedNet == true)
                            {
                                for (int i=0; i<enemies.Length; i++)
                                {
                                    if (enemies[i].gameObject.name == "Samnites"
                                        && enemies[i].gameObject.tag == "Enemy"
                                        && enemies[i].gameObject.activeSelf == true)
                                    {
                                        nearestEnemy = enemies[i].gameObject.transform;
                                    }
                                }

                            }

                            this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Finding);
                            SetTarget(nearestEnemy);

                        }
                        else
                        {
                            if (this.gameObject.GetComponent<PlayerStatus_Temp>().hasDodgedBaitNet == false)
                            {
                                for (int i = 0; i < enemies.Length; i++)
                                {

                                    if (enemies[i].gameObject.name == "Retiarius"
                                        && enemies[i].gameObject.tag == "Enemy"
                                        && enemies[i].gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == false)
                                    {
                                        if (enemies[i].gameObject.GetComponent<PlayerStatus_Temp>().hasDodgedNet == false)
                                        {
                                            nearestEnemy = enemies[i].gameObject.transform;


                                        }
                                        i = enemies.Length;
                                    }

                                }
                                this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Finding);
                                SetTarget(nearestEnemy);
                            }
                            else
                            {
                                this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Finding);
                                SetTarget(nearestEnemy);
                            }
                            
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

            }

            if (this.gameObject.tag != "Enemy")
            {
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

                    if (distance < 5)
                    {

                        this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.ThrowNet);


                        skillTimer = 0f;

                    }
                }
                else
                {
                    if (baitEnemy != null)
                    {
                        distance = (baitEnemy.position - this.gameObject.transform.position).magnitude;

                        if (distance < 5)
                        {

                            this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.ThrowNet);


                            skillTimer = 0f;

                        }
                    }
                }


            }
        }


        
    }

    public void AttackThrowNetStart()
    {
        //this.gameObject.transform.parent.gameObject.GetComponent<AIPath>().maxSpeed =
        //    this.gameObject.GetComponent<RetiariusSkillManager>().skillData.speedValue;
        

        this.gameObject.GetComponent<RetiariusSkillManager>().SkillAttack(nearestEnemy);
    }
}
