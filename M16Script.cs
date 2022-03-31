using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class M16Script : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    int m16cost;
    public GameObject playerUpgrades;
    public Text cost;
    private bool boughtM16;
    private void Start()
    {
        
        m16cost = playerUpgrades.GetComponent<ShopButtonScript>().m16Cost;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        cost.text = "Cost: " + m16cost;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        cost.text = "Cost: ";
    }
}
