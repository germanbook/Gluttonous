using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetFinder : MonoBehaviour
{

    // nearestEnemy
    Transform nearestEnemy;
    

    private void Awake()
    {
        Time.timeScale = 0;
        
        
    }

    private void Start()
    {
        // Finding target
        Invoke("FindTarget", 0.2f);
    }

    private void Update()
    {
        if (nearestEnemy != null)
        {
            //Change target when it die
            if (nearestEnemy.gameObject.GetComponent<PlayerStatus_Temp>().getHealthValue() <= 0f)
            {
                nearestEnemy = null;
                FindTarget();
            }

        }

    }


    // Find all enemies
    private void FindTarget()
    {
        string targetTag = "";
        // Finding Player for enemy
        // Finding enemy for player
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
            float tempDistance = Vector3.Distance(enemy.transform.position, this.gameObject.transform.position);

            if (tempDistance < minDistance)
            {
                minDistance = tempDistance;
                nearestEnemy = enemy.transform;
            }

        }


        if (enemies.Length != 0)
        {
            SetTarget(nearestEnemy);
            if (this.gameObject.tag == "Player")
            {
                this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Finding);
            }
        }
        if (enemies.Length == 0)
        {
            if (this.gameObject.tag == "Player" && this.gameObject.GetComponent<PlayerStatus_Temp>().getHealthValue() > 0f)
            {
                this.gameObject.GetComponent<FSM_Mananger>().TransitionState(StateType.Idle);
            }
        }

    }

    // Set target's destination
    private void SetTarget(Transform targetTransform)
    {
        // Set target to A* pathfinding
        this.gameObject.transform.parent.gameObject.GetComponent<AIDestinationSetter>().target = targetTransform;
    }
}
