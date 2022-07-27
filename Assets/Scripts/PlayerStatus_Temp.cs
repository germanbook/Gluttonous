using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus_Temp : MonoBehaviour
{
    /// <summary>
    /// This is a temp script
    /// store palyer or enemy's health value
    /// or some other status
    /// </summary>

    // Health value
    [SerializeField]private float healthValue;



    // Start is called before the first frame update
    void Start()
    {
        healthValue = 100f;
    }

    // Update is called once per frame
    void Update()
    {

    }


    // Get health value of this player/enemy object
    public float getHealthValue()
    {
        return healthValue;
    }
    
}
