using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopButtonScript : MonoBehaviour
{

    public Text coinsDisplay;
    public Text costDisplay;
    public GameObject saveObject;
    public int coins;
    public int m16Cost=30;



    public Button m16Button;
    private void Update()
    {
        saveObject = GameObject.Find("Save");
        coins = saveObject.GetComponent<SaveVars>().currentCoins;
        coinsDisplay.text = "coins: " + coins.ToString();




        if (saveObject.GetComponent<SaveVars>().gunsUnlocked[2] == 1)
        {
            m16Button.GetComponent<Image>().color = (Color.black);
        }
    }
    
    public void back()
    {
        SceneManager.LoadScene(0);
    }
    public void increaseHealth() {
        if (saveObject.GetComponent<SaveVars>().currentCoins >= saveObject.GetComponent<SaveVars>().playerUpgradeCost)
        {
            saveObject.GetComponent<SaveVars>().currentCoins -= saveObject.GetComponent<SaveVars>().playerUpgradeCost;
            saveObject.GetComponent<SaveVars>().maxHealth += 10;
            saveObject.GetComponent<SaveVars>().health = saveObject.GetComponent<SaveVars>().maxHealth;
            saveObject.GetComponent<SaveVars>().playerUpgradeCost += 10;
        }
        else
        {

        }
    }
    public void increaseArmor()
    {
        if (saveObject.GetComponent<SaveVars>().currentCoins >= saveObject.GetComponent<SaveVars>().playerUpgradeCost)
        {
            saveObject.GetComponent<SaveVars>().currentCoins -= saveObject.GetComponent<SaveVars>().playerUpgradeCost;
            saveObject.GetComponent<SaveVars>().maxArmor += 10;
            saveObject.GetComponent<SaveVars>().playerUpgradeCost += 10;
        }
    }
    public void increaseSpeed()
    {
        if (saveObject.GetComponent<SaveVars>().currentCoins >= saveObject.GetComponent<SaveVars>().playerUpgradeCost)
        {
            saveObject.GetComponent<SaveVars>().currentCoins -= saveObject.GetComponent<SaveVars>().playerUpgradeCost;
            saveObject.GetComponent<SaveVars>().speed += 0.1;
            saveObject.GetComponent<SaveVars>().health = saveObject.GetComponent<SaveVars>().maxHealth;
            saveObject.GetComponent<SaveVars>().playerUpgradeCost += 10;
        }
    }
    public void buyM16()
    {
        if (saveObject.GetComponent<SaveVars>().gunsUnlocked[2]==0)
        {
            if (saveObject.GetComponent<SaveVars>().currentCoins >= m16Cost)
            {
                saveObject.GetComponent<SaveVars>().currentCoins -= m16Cost;
                saveObject.GetComponent<SaveVars>().gunsUnlocked[2] = 1;
                m16Button.GetComponent<Image>().color = (Color.black);
            }
        }
    }


}
