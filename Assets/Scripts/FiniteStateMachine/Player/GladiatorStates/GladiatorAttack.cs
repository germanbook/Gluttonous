using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Prototype
    public void PlayerAttackding(GameObject target)
    {

        // Enemy target
        if (target.gameObject.tag == "Enemy")
        {
            target.GetComponent<PlayerStatus_Temp>().healthValue -= Time.deltaTime * 15;
        }
        else
        if (target.gameObject.tag == "Player")
        {
            target.GetComponent<PlayerStatus_Temp>().healthValue -= Time.deltaTime * 10;
        }
        
    }


    // Prototype
    public void BeAttacked()
    {

    }

}
