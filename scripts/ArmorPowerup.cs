using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArmorPowerup : MonoBehaviour
{
   // System.Random r = new System.Random();
    float timeLeft = 3.0f;//note to self f = seconds
    Boolean readyToSpawnArmor;
    public GameObject armorPrefab;
    public GameObject player;
    public Transform RandomArea;
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft =(float)UnityEngine.Random.Range(10,30);
            spawnArmor();
        }
        
    }
    void spawnArmor()
    {
        GameObject Armor = Instantiate(armorPrefab);
        Armor.transform.position = RandomArea.position;
    }
    
}
