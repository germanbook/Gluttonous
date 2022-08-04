using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetFinder : MonoBehaviour
{

    // nearestEnemy
    public Transform nearestEnemy;

    public Transform tempTarget;

    private void Start()
    {
        nearestEnemy = this.transform;
        // Finding target
        Invoke("FindTarget", 0.2f);
    }

    private void FixedUpdate()
    {

        //Change target when it die
        if ( ( this.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == false
            && this.gameObject.GetComponent<PlayerStatus_Temp>().isAlive == true)
            || ( nearestEnemy.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true
                 && nearestEnemy.gameObject.GetComponent<FSM_Mananger>().targetPlayer.gameObject.name != this.gameObject.name)
            )
        {

            nearestEnemy = tempTarget;
            FindTarget();
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
                this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Finding);
                SetTarget(nearestEnemy);
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
                //SetTarget(GameObject.FindGameObjectWithTag("ArenaCenter").transform);
            }
        }

    }

    // Set target's destination
    public void SetTarget(Transform targetTransform)
    {
        // Set target to A* pathfinding
        this.gameObject.transform.parent.gameObject.GetComponent<AIDestinationSetter>().target = targetTransform;
    }
}
