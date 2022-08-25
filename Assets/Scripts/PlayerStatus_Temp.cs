using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus_Temp : MonoBehaviour
{
    /// <summary>
    /// This is a temp script
    /// store palyer or enemy's health value
    /// or some other status
    /// </summary>

    // Health value
    public float healthValue;

    // Player life bar lifevalue
    public Image playerLifeBarValue;
    // Player life bar state
    public Image playerLifeBarState;
    // Idle
    public Sprite idleStateImage;
    // Finding
    public Sprite findStateImage;
    // Attack
    public Sprite attackStateImage;

    // If this gladiator dead or live
    public bool isAlive;

    // IF in attacking state
    public bool isAttacking;

    //
    public bool isFinding;

    // block
    public bool isBlocking;




    // Start is called before the first frame update
    void Start()
    {
        healthValue = 100f;
        isAlive = true;
        isAttacking = false;
        isFinding = false;
        isBlocking = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Update life bar value
        LifeBarValue();
        
    }


    // Get health value of this player/enemy object
    public float getHealthValue()
    {
        return healthValue;
    }

    // Player's over head life bar
    public void LifeBarValue()
    {
        if (healthValue > 0)
        {
            playerLifeBarValue.fillAmount = healthValue / 100;
        }
        else
        {
            playerLifeBarValue.fillAmount = 0;
        }
    }
    
}
