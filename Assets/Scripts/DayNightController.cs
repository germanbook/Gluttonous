using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the timescale of gameworld, day and night cycle & related UI elements
/// </summary>

public class DayNightController : MonoBehaviour
{
    TimeSpan currentTime;

    [Header("Time of day in seconds")]
    [SerializeField] float time;

    [Header("Assigned objects")] //Game objects for UI elements 
    [SerializeField] Transform sunGameObject;
    [SerializeField] Light Sun;
    [SerializeField] Text timeText;
    [SerializeField] Text dayText;
    [SerializeField] GameObject menuPanel;

    [Header("Speed of day & which day")]
    [SerializeField] int dayCount = 1;
    float daySpeed = 144;
    bool isTheMapVisible;

    //UI elements for speed modifiers of gameworld time
    private Button speed1x, speed3x, speed5x;
    void Start()
    {
        speed1x = GameObject.Find("btnSpeed1x").GetComponent<Button>();
        speed1x.onClick.AddListener(X1Speedmodifier);
        speed3x = GameObject.Find("btnSpeed3x").GetComponent<Button>();
        speed3x.onClick.AddListener(X3Speedmodifier);
        speed5x = GameObject.Find("btnSpeed5x").GetComponent<Button>();
        speed5x.onClick.AddListener(X5Speedmodifier);

        menuPanel.SetActive(false);
        isTheMapVisible = false;
    }

    void Update()
    {
        Changetime();
        if(Input.GetKeyDown(KeyCode.M))
        {
            MapOnMapOff();
        }
    }

    public void MapOnMapOff()
    {
        if (isTheMapVisible == false)
        {
            menuPanel.SetActive(true);
            isTheMapVisible = true;
        }
        else if (isTheMapVisible == true)
        {
            menuPanel.SetActive(false);
            isTheMapVisible = false;
        }
    }
    private void X1Speedmodifier()
    {
        daySpeed = 144f; //= 1x Speed (10min per day cycle)  
    }
    private void X3Speedmodifier()
    {
        daySpeed = 436.3636363636364f; // = 3x Speed (3.20min per day cycle)
    }
    private void X5Speedmodifier()
    {
        daySpeed = 691.2f; // = 5x Speed (2min per day cycle)
    }
    private void Changetime()
    {
        time += Time.deltaTime * daySpeed;
        if (time > 86400)
        {
            dayCount += 1;
            time = 0;
        }
        dayText.text = dayCount.ToString();
        currentTime = TimeSpan.FromSeconds(time);
        string[] tempTime = currentTime.ToString().Split(":"[0]);
        timeText.text = tempTime[0] + ":" + tempTime[1];
        sunGameObject.rotation = Quaternion.Euler (new Vector3((time-21600)/86400*360, 0, 0));
    }
}
