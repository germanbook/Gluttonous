using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// State type
/// idle, finding enemy, attacking
/// </summary>
public enum StateType
{

    Idle,
    Finding,
    Attacking,
    Death,
    ThrowNet,
    Block

}
