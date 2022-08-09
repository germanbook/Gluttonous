using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLanistaStanding : MonoBehaviour
{

    /// <summary>
    /// Arena Scene:
    /// Disabled the movement of player lanista
    /// </summary>

    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}