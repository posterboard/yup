using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadoutScript : MonoBehaviour
{
    public GameObject saveObject;
    public Text primaryGunText;
    public Text secondaryGunText;

    public Text dropdownLabelP;
    public Text dropdownLabelS;

    public Dropdown primarySelection;
    public Dropdown secondarySelection;

    private int[] unlockedGuns;
    private string[] unlockedGunsName;
    public List<string> dropDownGunsList;
    private string[] dropDownGunsArray;

    private string labelPText;
    private string labelSText;
    // Start is called before the first frame update                   
    void Start()
    {                       
        saveObject = GameObject.Find("Save");
        unlockedGuns = saveObject.GetComponent<SaveVars>().gunsUnlocked;

        unlockedGunsName = saveObject.GetComponent<SaveVars>().gunNames;
        Debug.Log(unlockedGuns.Length);
        for(int i= 0; i <= unlockedGuns.Length- 1; i++)
        {
            if (unlockedGuns[i] == 1)
            {
                dropDownGunsList.Add(unlockedGunsName[i]);
               
            }

        }
        dropDownGunsArray = dropDownGunsList.ToArray();
        PopulateDropdown(primarySelection,dropDownGunsArray);
        PopulateDropdown(secondarySelection, dropDownGunsArray);
       // secondaryGunText.text = "Secondary: " + saveObject.GetComponent<SaveVars>().currentWeaponSName;
    }

    // Update is called once per frame

    void Update()
    {
        primaryGunText.text = "Primary: " + saveObject.GetComponent<SaveVars>().currentWeaponPName;
        secondaryGunText.text = "Secondary: " + saveObject.GetComponent<SaveVars>().currentWeaponSName;

    }
    public void back()
    {
        SceneManager.LoadScene(0);
    }
    public void play()
    {
    
        SceneManager.LoadScene(2);
    }
    void PopulateDropdown(Dropdown dropdown,string[] optionsArray)
    {
        List<string> OP = new List<string>();
        OP.Add("");
        foreach (var option in optionsArray)
        {
            OP.Add(option);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(OP);
    }
    public void newWeaponSelectedP()
    {
        labelPText = dropdownLabelP.text;
        if (labelPText.Equals("Sniper"))
        {
            saveObject.GetComponent<SaveVars>().currentWeaponP = 0;
            saveObject.GetComponent<SaveVars>().currentWeaponPName = "Sniper";
        }
        if (labelPText.Equals("Pistol"))
        {
            saveObject.GetComponent<SaveVars>().currentWeaponP = 1;
            saveObject.GetComponent<SaveVars>().currentWeaponPName = "Pistol";
        }
        if (labelPText.Equals("M16"))
        {

            saveObject.GetComponent<SaveVars>().currentWeaponP = 2;
            saveObject.GetComponent<SaveVars>().currentWeaponPName = "M16";
        }
    }
    public void newWeaponSelectedS()
    {
        labelSText = dropdownLabelS.text;
        if (labelSText.Equals("Sniper"))
        {
            saveObject.GetComponent<SaveVars>().currentWeaponS = 0;
            saveObject.GetComponent<SaveVars>().currentWeaponSName = "Sniper";
        }
        if (labelSText.Equals("Pistol"))
        {

            saveObject.GetComponent<SaveVars>().currentWeaponS = 1;
            saveObject.GetComponent<SaveVars>().currentWeaponSName = "Pistol";
        }
        if (labelSText.Equals("M16"))
        {

            saveObject.GetComponent<SaveVars>().currentWeaponS = 2;
            saveObject.GetComponent<SaveVars>().currentWeaponSName = "M16";
        }
    }
}
