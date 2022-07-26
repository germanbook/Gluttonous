using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// IState interface
/// </summary>
public interface IState
{
    // Enter state
    void OnEnter();

    // While in the state
    void OnUpdate();

    // Exit state
    void OnExit();
}
