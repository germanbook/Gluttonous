using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendorDialogue : MonoBehaviour
{

    [SerializeField] GameObject VendorDialogue1;
    [SerializeField] GameObject VendorDialogue2;
    


    // Start is called before the first frame update
    void Start()
    {
      
        VendorDialogue2.SetActive(false);
        
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
            case "Yes":
                // YES
                // VendorDialogue2
                VendorDialogue1.gameObject.SetActive(false);
                VendorDialogue2.SetActive(true);
                break;
            
          
            case "No Thanks":

                VendorDialogue1.gameObject.SetActive(false);
               VendorDialogue2.gameObject.SetActive(false);

                // Set dialogue status to false;
                GameManager.isDialogueShowing = false;
                break;

            case "GoBack":
                // Back from VendorDialogue2
                VendorDialogue2.gameObject.SetActive(false);
                VendorDialogue1.gameObject.SetActive(true);
                break;



        }
    }

}
