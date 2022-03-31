using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameObject saveObject;
    public int health = 100;
    public int maxHealth;
    public int armor = 0;
    public int maxArmor;
    public double speed;
    void Start()
    {
        saveObject = GameObject.Find("Save");
        maxHealth = saveObject.GetComponent<SaveVars>().maxHealth;
        health = maxHealth;
        maxArmor = saveObject.GetComponent<SaveVars>().maxArmor;
        speed = saveObject.GetComponent<SaveVars>().speed;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
