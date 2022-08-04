using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

/// <summary>
/// Check if the charactor is moving for lift or right
/// </summary>
public class PlayerPosition : MonoBehaviour
{

    private float oldPosition;

    // Timer
    private float timeCount = 0f;


    private void Start()
    {
        oldPosition = this.gameObject.transform.position.x;
    }

    private void Update()
    {
        timeCount += Time.deltaTime;

        // If charactor stucks for 3 seconds
        if (timeCount > 2 && transform.position.x == oldPosition
            && this.gameObject.GetComponent<PlayerStatus_Temp>().isFinding == true)
        {
            Debug.Log("Stuck....");
            // Some reason the collision can not trigger, just manually do it
            this.gameObject.GetComponent<FSM_Mananger>().OnTriggerEnter2D(
                this.gameObject.transform.parent.gameObject.
                GetComponent<AIDestinationSetter>().target.GetComponent<CircleCollider2D>());
            timeCount = 0f;
            
        }

        // Moving of right
        if (transform.position.x > oldPosition)
        {
            if (this.gameObject.tag == "Enemy")
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        // Moving of lift
        if (transform.position.x < oldPosition)
        {
            if (this.gameObject.tag == "Player")
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        // update the old position with the new position
        oldPosition = transform.position.x;
    }

}
