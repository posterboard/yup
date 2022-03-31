using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IncreaseHealthButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text costDisplay;
    public GameObject saveObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        saveObject = GameObject.Find("Save");

    }
public void OnPointerEnter(PointerEventData eventData)
    {
        costDisplay.text = "Cost: " + saveObject.GetComponent<SaveVars>().playerUpgradeCost;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        costDisplay.text = "Cost: ";
    }
}
