using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the AI for the prototype gladiator fights
/// </summary>

public class GladiatorAI : MonoBehaviour
{
    //Game Objects for Projectile Throwing
    [SerializeField] GameObject spear;
    [SerializeField] GameObject armLaunchArea;
    [SerializeField] GameObject targetDummy;

    //The Entity Targets position 
    public Vector2 targetPosition;
    
    //Instanciated instance of projectile
    GameObject projectileInstance;

    //Vector for instantciated projectile
    Vector2 projectileVector;

    
    void Update()
    {
            
    }
    
    
    
    
}



