using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public static Currency instance;
    public int currencyValue;
    public Text currencyText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currencyValue = 100;
    }

    private void Update()
    {
        currencyText.text = Convert.ToString(currencyValue);
    }

    
}
