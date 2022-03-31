using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IncreaseArmorButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
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
