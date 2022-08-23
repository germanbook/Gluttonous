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

    // Net'd
    public bool isNetted;


    private void Start()
    {
        oldPosition = this.gameObject.transform.position.x;
        isNetted = false;
    }

    private void Update()
    {

        // If charactor stucks for 3 seconds
        if (transform.position.x == oldPosition
            && this.gameObject.GetComponent<PlayerStatus_Temp>().isFinding == true
            && isNetted == false)
        {
            
            timeCount += Time.deltaTime;
            if (timeCount > 2)
            {
                Debug.Log("Stuck....");
                // Some reason the collision can not trigger, just manually do it
                this.gameObject.GetComponent<FSM_Mananger>().OnTriggerEnter2D(
                    this.gameObject.transform.parent.gameObject.
                    GetComponent<AIDestinationSetter>().target.GetComponent<CircleCollider2D>());

                this.gameObject.transform.parent.gameObject.
                    GetComponent<AIDestinationSetter>().target.gameObject.
                    GetComponent<FSM_Mananger>().OnTriggerEnter2D(this.gameObject.GetComponent<CircleCollider2D>());
                timeCount = 0f;
            }
            
            
        }

        // Moving of right
        if (transform.position.x > oldPosition)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            //if (this.gameObject.tag == "Enemy")
            //{
            //    this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            //}
            //else
            //{
            //    this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            //}
        }

        // Moving of lift
        if (transform.position.x < oldPosition)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            //if (this.gameObject.tag == "Player")
            //{
            //    this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            //}
            //else
            //{
            //    this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            //}
        }

        // update the old position with the new position
        oldPosition = transform.position.x;
    }

}
