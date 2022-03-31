using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPrefab : MonoBehaviour
{
    public GameObject player;
    int temp = 0;
    int maxArmor;
    private void Start()
    {
        player = GameObject.Find("player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //setActive = false;
        if (collision.tag == "Character")
        {
            if (player.GetComponent<PlayerStats>().armor <= player.GetComponent<PlayerStats>().maxArmor)
            {
                temp = player.GetComponent<PlayerStats>().armor;
                player.GetComponent<PlayerStats>().armor =temp+20;
                Destroy(this.gameObject);
            }
        }
    }
}
