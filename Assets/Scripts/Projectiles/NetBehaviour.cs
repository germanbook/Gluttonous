using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class NetBehaviour : MonoBehaviour
{
    //this script is for testing purposes to show the net being launched
    //to do: set the net target as the target of the gladiators, launch the net in that direction 
    public float Speed = 4.5f;
    Transform target;

    // Net timer
    float netTimer;
    bool isNetTimerStart;

    // Net'd target original speed
    float targetOriginalSpeed;

    private void Start()
    {
        netTimer = 0f;
        isNetTimerStart = false;

        target = this.transform.parent.gameObject.GetComponent<TargetFinder>().nearestEnemy.transform;
        this.transform.SetParent(null);
    }

    void Update()
    {
        if (isNetTimerStart)
        {
            netTimer += Time.deltaTime;
        }

        this.transform.position = Vector2.MoveTowards(this.transform.position,
            new Vector2(target.position.x,
            target.position.y),
            Time.deltaTime * Speed);

        if (netTimer > 2)
        {
            target.gameObject.transform.parent.gameObject.GetComponent<AIPath>().maxSpeed = targetOriginalSpeed;
            target.gameObject.GetComponent<PlayerPosition>().isNetted = false;
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == target.gameObject.name)
        {
            isNetTimerStart = true;
            targetOriginalSpeed = target.gameObject.transform.parent.gameObject.GetComponent<AIPath>().maxSpeed;
            target.gameObject.transform.parent.gameObject.GetComponent<AIPath>().maxSpeed = 0f;
            target.gameObject.GetComponent<PlayerPosition>().isNetted = true;
        }
    }

}
