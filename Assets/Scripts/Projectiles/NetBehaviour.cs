using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class NetBehaviour : MonoBehaviour
{
    //this script is for testing purposes to show the net being launched
    //to do: set the net target as the target of the gladiators, launch the net in that direction 
    public float Speed = 4.5f;
    public Transform target;

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
        //this.transform.SetParent(null);
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

        if (netTimer > 2f)
        {
            target.gameObject.transform.parent.gameObject.GetComponent<AIPath>().maxSpeed = targetOriginalSpeed;
            target.gameObject.GetComponent<PlayerPosition>().isNetted = false;
            Destroy(this.gameObject);
            Debug.Log("speed back" + targetOriginalSpeed);
        }

        if (target.gameObject.activeSelf == false)
        {
            Destroy(this.gameObject);
        }
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isNetTimerStart == false)
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
            {

                if (GameObject.ReferenceEquals(this.transform.parent.gameObject, collision.gameObject) == false)
                {
                    Debug.Log("collision name: " + collision.gameObject.name);

                    if (GameObject.ReferenceEquals(collision.gameObject, target.gameObject)
                    && GameObject.ReferenceEquals(collision.gameObject.GetComponent<FSM_Mananger>().targetPlayer.gameObject,
                    this.transform.parent.gameObject.GetComponent<FSM_Mananger>().targetPlayer.gameObject))
                    {
                        Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                        isNetTimerStart = true;
                        targetOriginalSpeed = target.gameObject.transform.parent.gameObject.GetComponent<AIPath>().maxSpeed;
                        target.gameObject.transform.parent.gameObject.GetComponent<AIPath>().maxSpeed = 0f;
                        target.gameObject.GetComponent<PlayerPosition>().isNetted = true;
                        this.transform.SetParent(null);
                    }
                }
            }
        }
    }

    public void StartNetTimer()
    {
        isNetTimerStart = true;
    }


}
