using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Finding State
/// </summary>
public class FindingState : IState
{
    private FSM_Mananger manager;

    public FindingState(FSM_Mananger manager)
    {
        this.manager = manager;
    }

    public void OnEnter()
    {
        Debug.Log("Enter Finding State...");
    }

    public void OnExit()
    {
        Debug.Log("Exit Finding State...");
    }

    public void OnUpdate()
    {
        Debug.Log("Finding State...");
    }
}