using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Pathfinding;
using UnityEngine;

/// <summary>
/// Base Finite State Machine
/// </summary>
public class FSM_Mananger : MonoBehaviour
{

    // Target player
    public GameObject targetPlayer;

    public Animator animator;

    // Current state
    public IState currentState;

    // Throw net
    bool isThrowNet;

    //
    float distance;

    // Gladiator store data
    [SerializeField] PlayerGladiatorsStore gladiatorStore;

    // Dictionary mapping state to key and value
    private Dictionary<StateType, IState> states = new Dictionary<StateType, IState>();

    private void Awake()
    {
        // Adding state object to dictionary
        states.Add(StateType.Idle, new IdleState(this));
        states.Add(StateType.Finding, new FindingState(this));
        states.Add(StateType.Attacking, new AttackingState(this));
        states.Add(StateType.Death, new DeathState(this));
        states.Add(StateType.ThrowNet, new ThrowNetState(this));
        states.Add(StateType.Block, new BlockState(this));
        states.Add(StateType.SideAttack, new SideAttackState(this));
        states.Add(StateType.DodgeNet, new DodgeNetState(this));

        // Default state: Idle
        TransitionState(StateType.Idle);
        
        

        // TODO: Initialize the state of Play such as health
        // ...
    }

    /// <summary>
    /// State swap trigger here
    /// </summary>
    private void FixedUpdate()
    {
        // Running current state's OnUpdate()
        currentState.OnUpdate();
        if(this.gameObject.GetComponent<PlayerStatus_Temp>().getHealthValue() <= 0f)
        {

            TransitionState(StateType.Death);
        }
    }

    // Swap states
    public void TransitionState(StateType stateType)
    {
        // Exit current state if it's not null
        if (currentState != null)
        {
            currentState.OnExit();
        }

        // Get IdleState object from states dictionary
        currentState = states[stateType];

        // Call IdleState object OnEnter() function
        currentState.OnEnter();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (this.gameObject.GetComponent<TargetFinder>().arenaSceneManager.gameObject.GetComponent<ArenaSceneManager>().isPause == false)
        {

            if (collision.gameObject.tag != "Net"
            //&& this.gameObject.GetComponent<PlayerPosition>().isNetted == false
            && this.gameObject.tag != collision.gameObject.tag
            && GameObject.ReferenceEquals(collision.gameObject.GetComponent<TargetFinder>().nearestEnemy.gameObject, this.gameObject)
            && GameObject.ReferenceEquals(this.gameObject.GetComponent<TargetFinder>().nearestEnemy.gameObject, collision.gameObject)
            )
            {
                

                if (collision.gameObject.name == "Retiarius")
                {
                    distance = (collision.gameObject.transform.position - this.gameObject.transform.position).magnitude;
                    if (distance < 2)
                    {
                        TransitionState(StateType.Attacking);
                        targetPlayer = collision.gameObject;
                    }
                }
                else
                {
                    if (this.gameObject.name == "Threax"
                        && collision.gameObject.name == "Murmillo"
                        ||
                        this.gameObject.name == "Threax"
                        && collision.gameObject.name == "Samnites")
                    {
                        TransitionState(StateType.SideAttack);
                        targetPlayer = collision.gameObject;
                    }
                    else
                    {
                        TransitionState(StateType.Attacking);
                        targetPlayer = collision.gameObject;
                    }

                    
                }
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (GameObject.ReferenceEquals(targetPlayer.gameObject, collision.gameObject))
        {
            
            this.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking = false;
        }
    }


    public void removeCharactor()
    {
        if (this.gameObject.tag == "Player")
        {
            GladiatorStoreCounterUpdate();
        }

        this.gameObject.SetActive(false);
        this.transform.parent.gameObject.SetActive(false);
        
        this.gameObject.transform.parent.gameObject.GetComponent<AIDestinationSetter>().target = null;
        
    }

    // When player's gladiator dead, update store data
    public void GladiatorStoreCounterUpdate()
    {
        switch (this.gameObject.name)
        {
            case "Samnites":
                gladiatorStore.counterSamnites -= 1;

                break;
            case "Retiarius":
                gladiatorStore.counterRetiarius -= 1;


                break;
            case "Murmillo":
                gladiatorStore.counterMyrmilo -= 1;


                break;
            case "Threax":
                gladiatorStore.counterThraex -= 1;

                break;
        }
    }



}
