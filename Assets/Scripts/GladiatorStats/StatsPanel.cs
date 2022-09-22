using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kryz.CharacterStats;

public class StatsPanel : MonoBehaviour
{
    public Canvas statsPanel;
    public bool statsPanelDisplayed = false;

    // Panel displayed
    public bool isPanelDisplayed;

    public void OnMouseDown()
    {
        //if (Input.GetMouseButtonDown(0) && statsPanelDisplayed == false)
        //{
        //    statsPanelDisplayed = true;
        //    statsPanel.enabled = statsPanelDisplayed;
        //}
        //else
        //{
        //    statsPanelDisplayed = false;
        //    statsPanel.enabled = statsPanelDisplayed;
        //}

        if (Input.GetMouseButtonDown(0))
        {
            if (statsPanelDisplayed == false)
            {
                statsPanelDisplayed = true;
                statsPanel.enabled = statsPanelDisplayed;
                isPanelDisplayed = true;
            }
            else
            {
                statsPanelDisplayed = false;
                statsPanel.enabled = statsPanelDisplayed;
            }

            
        }

    }
    private void Start()
    {
        statsPanel = this.gameObject.GetComponentInChildren<Canvas>();
        statsPanel.enabled = statsPanelDisplayed;

        isPanelDisplayed = false;

    }
}
