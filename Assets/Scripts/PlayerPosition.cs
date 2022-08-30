using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
        if (isNetted)
        {
            this.gameObject.transform.parent.gameObject.GetComponent<AIPath>().canMove = false;
        }
        else
        {
            this.gameObject.transform.parent.gameObject.GetComponent<AIPath>().canMove = true;
        }
        


        // If charactor stucks for 0.5 seconds
        if (transform.position.x == oldPosition
            && this.gameObject.GetComponent<PlayerStatus_Temp>().isFinding == true
            && isNetted == false)
        {

            if (this.gameObject.name == "Threax")
            {
                if (this.gameObject.GetComponent<PlayerStatus_Temp>().isSideAttacking == false)
                {
                    timeCount += Time.deltaTime;
                    if (timeCount > 0.5f)
                    {
                        Debug.Log(this.gameObject.name + " Stuck....");

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
            }
            else
            {
                timeCount += Time.deltaTime;
                if (timeCount > 0.5f)
                {
                    Debug.Log(this.gameObject.name + " Stuck....");

                    //switch (this.gameObject.name)
                    //{
                    //    case "Samnites":
                    //        this.gameObject.transform.parent.gameObject.GetComponent<AIPath>().maxSpeed =
                    //            this.gameObject.GetComponent<SamnitesSkillManager>().skillData.speedValue;

                    //        break;

                    //    case "Retiarius":
                    //        this.gameObject.transform.parent.gameObject.GetComponent<AIPath>().maxSpeed =
                    //            this.gameObject.GetComponent<RetiariusSkillManager>().skillData.speedValue;

                    //        break;

                    //    case "Murmillo":
                    //        this.gameObject.transform.parent.gameObject.GetComponent<AIPath>().maxSpeed =
                    //            this.gameObject.GetComponent<MurmilloSkillManager>().skillData.speedValue;

                    //        break;

                    //    case "Threax":
                    //        this.gameObject.transform.parent.gameObject.GetComponent<AIPath>().maxSpeed =
                    //            this.gameObject.GetComponent<ThraexSkillManager>().skillData.speedValue;

                    //        break;
                    //}

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
