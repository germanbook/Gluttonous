using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{

    // nearestEnemy
    Transform nearestEnemy;
    

    private void Awake()
    {
        
        // Finding target
        FindTarget();
        
    }

    private void Update()
    {

        if (nearestEnemy != null)
        {
            //Change target when it die
            if (nearestEnemy.gameObject.GetComponent<PlayerStatus_Temp>().getHealthValue() == 0f)
            {
                nearestEnemy.gameObject.SetActive(false);
                Debug.Log("This is: " + this.gameObject.name + " Switch target");
                FindTarget();
            }
        }
        

        

        Debug.Log("This is: " + this.gameObject.name + " Current target: + " + nearestEnemy.gameObject.name);
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

        SetTarget(nearestEnemy);

        Debug.Log("Nearest enemy name: " + nearestEnemy.gameObject.name);

    }

    // Set target's destination
    private void SetTarget(Transform targetTransform)
    {
        // Set target to A* pathfinding
        this.gameObject.transform.parent.gameObject.GetComponent<AIDestinationSetter>().target = targetTransform;
    }
}
