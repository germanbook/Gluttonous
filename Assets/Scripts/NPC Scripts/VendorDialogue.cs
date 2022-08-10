using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendorDialogue : MonoBehaviour
{

    public GameObject VendorDialogue1;
    public GameObject VendorDialogue2;

    GameObject vendorNPC;


    // Start is called before the first frame update
    void Start()
    {
      
        VendorDialogue2.SetActive(false);
        vendorNPC = GameObject.FindGameObjectWithTag("VendorNPC");
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Option click, return the option's tag
    public void optionClicked(Button button)
    {
        switch (button.gameObject.tag)
        {
            case "D1_01":
                // No thanks
                VendorDialogue1.SetActive(false);
                // Set dialogue status to false;
                GameManager.isDialogueShowing = false;
                break;
            
          
            case "D1_02":
                // Yes
                VendorDialogue1.gameObject.SetActive(false);
                VendorDialogue2.gameObject.SetActive(true);
                break;

            case "D2_Threax":
                // Threax gladiator
                VendorDialogue2.gameObject.SetActive(false);
                vendorNPC.gameObject.GetComponent<GaladiatorHire>().gladiatorHire(button.gameObject.tag);
                break;

            case "D2_Samnites":
                // Samnites gladiator
                VendorDialogue2.gameObject.SetActive(false);
                vendorNPC.gameObject.GetComponent<GaladiatorHire>().gladiatorHire(button.gameObject.tag);
                break;

            case "D2_Myrmilo":
                // Myrmilo gladiator
                VendorDialogue2.gameObject.SetActive(false);
                vendorNPC.gameObject.GetComponent<GaladiatorHire>().gladiatorHire(button.gameObject.tag);
                break;

            case "D2_Retiarius":
                // Retiarius gladiator
                VendorDialogue2.gameObject.SetActive(false);
                vendorNPC.gameObject.GetComponent<GaladiatorHire>().gladiatorHire(button.gameObject.tag);
                break;

            case "D2_Back":
                // No thanks
                VendorDialogue2.SetActive(false);
                // Set dialogue status to false;
                GameManager.isDialogueShowing = false;
                break;




        }
    }

}
