using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorAttack : MonoBehaviour
{

    // Character properties
    string weapon;
    // 1 - 10 low - high
    float armorValue;
    // 1 - 10 low - high
    float speedValue;
    float getOutOfNetTime;
    string shieldSize;

    public float damageValue;

    bool hasNet;

    [SerializeField] float attackDamage = 10;

    void Start()
    {
        switch (this.gameObject.name)
        {
            case "Samnites":
                hasNet = false;
                weapon = "S";
                armorValue = 5f;
                speedValue = 5f;
                getOutOfNetTime = 5f;
                shieldSize = "L";

                break;
            case "Retiarius":

                hasNet = true;

                weapon = "L";
                // none
                armorValue = 0f;
                speedValue = 10f;
                // none
                getOutOfNetTime = 0f;
                // none
                shieldSize = "None";

                break;
            case "Murmillo":
                hasNet = false;
                weapon = "S";
                armorValue = 10f;
                speedValue = 2f;
                shieldSize = "L";
                // get out of net slower
                getOutOfNetTime = 10f;

                break;
            case "Thraex":
                hasNet = false;
                weapon = "C";
                armorValue = 5f;
                speedValue = 7.5f;
                shieldSize = "L";
                // doge net
                getOutOfNetTime = 0f;

                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Prototype
    public void PlayerAttackding(GameObject target)
    {

        switch (this.gameObject.name)
        {
            case "Samnites":
                SamnitesCombat(target);
                break;
            case "Retiarius":
                RetiariusCombat(target);
                break;
            case "Murmillo":
                MurmilloCombat(target);
                break;
            case "Thraex":
                ThraexCombat(target);
                break;
        }


        //// Enemy target
        //if (target.gameObject.tag == "Enemy")
        //{
        //    target.GetComponent<PlayerStatus_Temp>().healthValue -= Time.deltaTime * 15;
        //}
        //else
        //if (target.gameObject.tag == "Player")
        //{
        //    target.GetComponent<PlayerStatus_Temp>().healthValue -= Time.deltaTime * 10;
        //}
        
    }



    void SamnitesCombat(GameObject target)
    {
        switch (target.gameObject.name)
        {

            case "Retiarius":

                if (target.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    // Damage
                    this.damageValue = 0.7f * attackDamage;
                    this.gameObject.GetComponent<PlayerStatus_Temp>().healthValue -= damageValue;

                }


                break;
            case "Murmillo":
                if (target.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    // Damage
                    this.damageValue = 0.7f * attackDamage;
                    this.gameObject.GetComponent<PlayerStatus_Temp>().healthValue -= damageValue;

                }
                break;
            case "Thraex":
                if (target.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    // Damage
                    this.damageValue = 0.7f * attackDamage;
                    this.gameObject.GetComponent<PlayerStatus_Temp>().healthValue -= damageValue;

                }
                break;
        }

    }

    void RetiariusCombat(GameObject target)
    {
        switch (target.gameObject.name)
        {

            case "Samnites":

                if (target.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    // Damage
                    this.damageValue = 1f * attackDamage;
                    this.gameObject.GetComponent<PlayerStatus_Temp>().healthValue -= damageValue;

                }


                break;
            case "Murmillo":
                if (target.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    // Damage
                    this.damageValue = 1f * attackDamage;
                    this.gameObject.GetComponent<PlayerStatus_Temp>().healthValue -= damageValue;

                }
                break;
            case "Thraex":
                if (target.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    // Damage
                    this.damageValue = 1f * attackDamage;
                    this.gameObject.GetComponent<PlayerStatus_Temp>().healthValue -= damageValue;

                }
                break;
        }

    }

    void MurmilloCombat(GameObject target)
    {
        switch (target.gameObject.name)
        {

            case "Samnites":

                if (target.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    // Damage
                    this.damageValue = 0.4f * attackDamage;
                    this.gameObject.GetComponent<PlayerStatus_Temp>().healthValue -= damageValue;

                }


                break;

            case "Retiarius":

                if (target.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    // Damage
                    this.damageValue = 0.4f * attackDamage;
                    this.gameObject.GetComponent<PlayerStatus_Temp>().healthValue -= damageValue;

                }


                break;

            case "Thraex":
                if (target.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    // Damage
                    this.damageValue = 0.4f * attackDamage;
                    this.gameObject.GetComponent<PlayerStatus_Temp>().healthValue -= damageValue;

                }
                break;
        }

    }

    void ThraexCombat(GameObject target)
    {
        switch (target.gameObject.name)
        {

            case "Samnites":

                if (target.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    // Damage
                    this.damageValue = 0.7f * attackDamage;
                    this.gameObject.GetComponent<PlayerStatus_Temp>().healthValue -= damageValue;

                }


                break;
            case "Retiarius":

                if (target.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    // Damage
                    this.damageValue = 0.7f * attackDamage;
                    this.gameObject.GetComponent<PlayerStatus_Temp>().healthValue -= damageValue;

                }


                break;
            case "Murmillo":
                if (target.gameObject.GetComponent<PlayerStatus_Temp>().isAttacking == true)
                {
                    // Damage
                    this.damageValue = 0.7f * attackDamage;
                    this.gameObject.GetComponent<PlayerStatus_Temp>().healthValue -= damageValue;

                }
                break;

        }

    }

}
