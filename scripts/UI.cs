using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public int currentHealth;
    public int maxHP;
    public int currentArmor;
    public int maxArmor;
    public int cw;//currentWeapon
    public int currentWeapon;
    public int maxAmmo;
    public int currentAmmo;
    public int currentCoins;
    public string gunName;
    public GameObject player;
    public Text healthDisplay;
    public Text armorDisplay;
    public Text ammoDisplay;
    public Text coinDisplay;
    public GameObject gun;
    public GameObject gunScript;
    public GameObject primaryWeapon;
    public GameObject secondaryWeapon;
    public GameObject saveObject;
    public Sprite bigGunSelected;
    public Sprite bigGunNotSelected;
    public Sprite smallGunSelected;
    public Sprite smallGunNotSelected;
    public Sprite m16Selected;
    public Sprite m16NotSelected;


    public int primaryGun;
    public int secondaryGun;
    public Sprite primarySelected;
    public Sprite primaryNotSelected;
    public Sprite secondarySelected;
    public Sprite secondaryNotSelected;

    private bool reloadingQuestionMarkP;
    private bool reloadingQuestionMarkS;
    // Update is called once per frame
    private void Start()
    {
        saveObject = GameObject.Find("Save");
        primaryGun = saveObject.GetComponent<SaveVars>().currentWeaponP;
        secondaryGun = saveObject.GetComponent<SaveVars>().currentWeaponS;
        switch (primaryGun)
        {
            case 0:
                primarySelected = bigGunSelected;
                primaryNotSelected = bigGunNotSelected;
                break;
            case 1:
                primarySelected = smallGunSelected;
                primaryNotSelected = smallGunNotSelected;
                break;
            case 2:
                primarySelected = m16Selected;
                primaryNotSelected = m16NotSelected;
                break;
            default:
                break;
        }
        switch (secondaryGun)
        {
            case 0:
                secondarySelected = bigGunSelected;
                secondaryNotSelected = bigGunNotSelected;
                break;
            case 1:
                secondarySelected = smallGunSelected;
                secondaryNotSelected = smallGunNotSelected;
                break;
            case 2:
                secondarySelected = m16Selected;
                secondaryNotSelected = m16NotSelected;
                break;
            default:
                break;
        }

    }
    void Update()
    {
        updateHealth();
        updateArmor();
        updateGun();
        updateAmmo();
        updateCoins();
    }
    void updateHealth()
    {
        currentHealth = player.GetComponent<PlayerStats>().health;
        maxHP = player.GetComponent<PlayerStats>().maxHealth;
        healthDisplay.text = "Health: " + currentHealth.ToString() + "/" + maxHP.ToString();
    }
    void updateArmor()
    {
        currentArmor = player.GetComponent<PlayerStats>().armor;
        maxArmor = player.GetComponent<PlayerStats>().maxArmor;
        if (currentArmor != 0)
        {
            armorDisplay.text = "Armor: " + currentArmor.ToString() + "/" + maxArmor.ToString();
        }
        else
        {
            armorDisplay.text = "";
        }

    }
    void updateGun()
    {
        cw = gunScript.GetComponent<Gun>().currentGun;
        if (cw == 0)//primary selected
        {
            primaryWeapon.GetComponent<Image>().sprite = primarySelected;
            secondaryWeapon.GetComponent<Image>().sprite = secondaryNotSelected;
        }
        if (cw == 1){//secondary selected
            primaryWeapon.GetComponent<Image>().sprite = primaryNotSelected;
        secondaryWeapon.GetComponent<Image>().sprite = secondarySelected;
        
    
    }
    }

    void updateAmmo()
    {
        reloadingQuestionMarkP = gun.GetComponent<bullet>().finishedReloadP;
        reloadingQuestionMarkS = gun.GetComponent<bullet>().finishedReloadS;
        currentWeapon = gun.GetComponent<bullet>().currentSelectedGun;
        if (currentWeapon ==0) {
            gunName = gun.GetComponent<bullet>().currentWeaponP.name;
            currentAmmo = gun.GetComponent<bullet>().equippedPrimaryGunAmmo;
            maxAmmo = gun.GetComponent<bullet>().currentWeaponP.maxAmmo;
            if (reloadingQuestionMarkP == true)
            {
                ammoDisplay.text = gunName + ": " + currentAmmo + "/" + maxAmmo;
            }
            else
            {
                ammoDisplay.text = gunName+": reloading";
            }
        }
        else if (currentWeapon == 1)
        {
            gunName = gun.GetComponent<bullet>().currentWeaponS.name;
            currentAmmo = gun.GetComponent<bullet>().equippedSecondaryGunAmmo;
            maxAmmo = gun.GetComponent<bullet>().currentWeaponS.maxAmmo;
            if (reloadingQuestionMarkS == true)
            {
                ammoDisplay.text = gunName + ": " + currentAmmo + "/" + maxAmmo;
            }
            else {
                ammoDisplay.text = gunName + ": reloading";
            }
        }
    }
    void updateCoins()
    {
        currentCoins = saveObject.GetComponent<SaveVars>().currentCoins;
        coinDisplay.text = "coins: "+currentCoins;
    }
    }
