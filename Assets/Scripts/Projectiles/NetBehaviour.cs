using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.SocialPlatforms.Impl;

public class NetBehaviour : MonoBehaviour
{
    //this script is for testing purposes to show the net being launched
    //to do: set the net target as the target of the gladiators, launch the net in that direction 
    public float Speed = 4.5f;
    public Transform target;

    // Net timer
    float netTimer;
    float netEffectTimer;
    bool isNetTimerStart;

    private void Start()
    {

        isNetTimerStart = false;

        if (this.transform.parent.gameObject.GetComponent<TargetFinder>().baitEnemy != null)
        {
            target = this.transform.parent.gameObject.GetComponent<TargetFinder>().baitEnemy.transform;
            this.transform.parent.gameObject.GetComponent<TargetFinder>().baitEnemy = null;
        }
        else
        {
            target = this.transform.parent.gameObject.GetComponent<TargetFinder>().nearestEnemy.transform;
        }

    
        switch (target.gameObject.name)
        {
            case "Samnites":
                netEffectTimer = target.gameObject.GetComponent<SamnitesSkillManager>().skillData.netAttackEffect;
                break;

            case "Retiarius":
                netEffectTimer = target.gameObject.GetComponent<RetiariusSkillManager>().skillData.netAttackEffect;
                break;

            case "Murmillo":
                netEffectTimer = target.gameObject.GetComponent<MurmilloSkillManager>().skillData.netAttackEffect;
                break;

            case "Threax":
                netEffectTimer = target.gameObject.GetComponent<ThraexSkillManager>().skillData.netAttackEffect;
                break;
        }

        Debug.Log("Effect timer: "+netEffectTimer);
    }

    void Update()
    {
        

        this.transform.position = Vector2.MoveTowards(this.transform.position,new Vector2(target.position.x,target.position.y),Time.deltaTime * Speed);

        if (isNetTimerStart)
        {
            netTimer += Time.deltaTime;

        }

        if (netTimer >= (netEffectTimer-1))
        {
            if (target != this.gameObject.transform)
            {
                target.gameObject.GetComponent<PlayerPosition>().isNetted = false;
            }
            
            Destroy(this.gameObject);
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

                    if (collision.gameObject.name == "Threax")
                    {
                        collision.gameObject.GetComponent<ThraexSkillManager>().dodgeNet();
                        if (collision.gameObject.GetComponent<PlayerStatus_Temp>().isDodgeNet == false)
                        {
                            if (GameObject.ReferenceEquals(collision.gameObject, target.gameObject)
                                && GameObject.ReferenceEquals(collision.gameObject.GetComponent<FSM_Mananger>().targetPlayer.gameObject,
                                this.transform.parent.gameObject.GetComponent<FSM_Mananger>().targetPlayer.gameObject))
                            {

                                isNetTimerStart = true;
                                target.gameObject.GetComponent<PlayerPosition>().isNetted = true;
                                this.transform.SetParent(null);
                            }

                        }
                        else
                        {
                            isNetTimerStart = true;
                            netEffectTimer = 2f;
                            target = this.gameObject.transform;
                        }
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