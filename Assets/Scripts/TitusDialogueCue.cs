using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitusDialogueCue : MonoBehaviour
{

    [SerializeField] GameObject dialogue;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            dialogue.SetActive(true);
        }
    }
}
