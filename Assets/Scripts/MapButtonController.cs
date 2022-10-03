using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapButtonController : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] GameObject panel;

    private void Start()
    {
        panel.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        panel.gameObject.SetActive(true);
    }

    public void OnPointerExit()
    {
        panel.gameObject.SetActive(false);
    }


}
