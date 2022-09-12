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
        manager.animator.SetInteger("stateInt", 1);
        manager.GetComponent<PlayerStatus_Temp>().playerLifeBarState.sprite
            = manager.GetComponent<PlayerStatus_Temp>().findStateImage;
        manager.gameObject.GetComponent<PlayerStatus_Temp>().isFinding = true;
    }

    public void OnExit()
    {
        manager.gameObject.GetComponent<PlayerStatus_Temp>().isFinding = false;
    }

    public void OnUpdate()
    {
        switch (manager.gameObject.name)
        {

            case "Samnites":
                

                break;
            case "Retiarius":
                

                break;
            case "Murmillo":

                

                break;
            case "Threax":
                

                break;
        }
    }
}
