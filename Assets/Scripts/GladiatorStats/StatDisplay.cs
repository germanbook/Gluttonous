using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatDisplay : MonoBehaviour
{
    //Textmeshpro components from UI element (Change UI element Value to change Value)
    TextMeshProUGUI GladiatorClassText;
    TextMeshProUGUI HealthText;
    TextMeshProUGUI ArmorTypeText;
    TextMeshProUGUI WeaponTypeText;

    private void OnValidate()
    {
        //Grabs the text values from TMP components puts them in a list
        TextMeshProUGUI[] uiTexts = GetComponentsInChildren<TextMeshProUGUI>();
        GladiatorClassText = uiTexts[0];
        HealthText = uiTexts[1];
        ArmorTypeText = uiTexts[2];
        WeaponTypeText = uiTexts[3];
        

        //to do: use these imported values into the list for future changes to stats.
    }
}

