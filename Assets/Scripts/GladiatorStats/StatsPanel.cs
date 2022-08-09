using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kryz.CharacterStats;

public class StatsPanel : MonoBehaviour
{
    Canvas statsPanel;
    bool statsPanelDisplayed = false;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && statsPanelDisplayed == false)
        {
            statsPanelDisplayed = true;
            statsPanel.enabled = statsPanelDisplayed;
        }
        else if (Input.GetMouseButtonDown(0) && statsPanelDisplayed == true)
        {
            statsPanelDisplayed = false;
            statsPanel.enabled = statsPanelDisplayed;
        }
    }
    private void Start()
    {
        statsPanel = GameObject.Find("Gladiator").GetComponentInChildren<Canvas>();
        statsPanel.enabled = statsPanelDisplayed;
     
    }
}
