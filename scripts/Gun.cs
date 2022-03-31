using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Vector3 playerPosition;
    public Sprite bigGun;
    public Sprite smallGun;
   public GameObject player;
    public GameObject saveObject;
    public int shotsFired = 0;
    public int shotsHit = 0;
    public int currentGun = 0;// which gun the player is currently holding
    public int equippedGunP;
    public int equippedGunS;
    public bool switchWeapon = false;


    private float timer = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        saveObject = GameObject.Find("Save");
        GameObject player = GameObject.Find("player");
        if (player != null)
        {
            Debug.Log("ok");
        }


        equippedGunP = saveObject.GetComponent<SaveVars>().currentWeaponP;
        equippedGunS = saveObject.GetComponent<SaveVars>().currentWeaponS;
        //Debug.Log(equippedGunP + " " + equippedGunS);


        switch (equippedGunP)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = bigGun;
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = smallGun;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = bigGun;
                break;
            default:
                GetComponent<SpriteRenderer>().sprite = bigGun;
                break;
        }
       

    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(timer+" "+switchWeapon);
        playerPosition = player.transform.position;
        //transform.position = playerPosition;
        transform.position = playerPosition;
        transform.rotation = player.transform.rotation;
        if (shotsFired == shotsHit)
        {
            if (Input.GetKeyDown("1"))
            {
                switchWeapon = true;
                
                    switch (equippedGunP)
                    {
                        case 0:
                            GetComponent<SpriteRenderer>().sprite = bigGun;
                            break;
                        case 1:
                            GetComponent<SpriteRenderer>().sprite = smallGun;
                            break;
                        case 2:
                            GetComponent<SpriteRenderer>().sprite = bigGun;
                            break;
                        default:
                            GetComponent<SpriteRenderer>().sprite = bigGun;
                            break;
                    }

                    currentGun = 0;
                
               
            }
            if (Input.GetKeyDown("2"))
            {
                switchWeapon = true;
                
                    switch (equippedGunS)
                    {
                        case 0:
                            GetComponent<SpriteRenderer>().sprite = bigGun;
                            break;
                        case 1:
                            GetComponent<SpriteRenderer>().sprite = smallGun;
                            break;
                        case 2:
                            GetComponent<SpriteRenderer>().sprite = bigGun;
                            break;
                        default:
                            GetComponent<SpriteRenderer>().sprite = smallGun;
                            break;
                    }
                    currentGun = 1;
                
               
            }
        }
        if (switchWeapon == true)
        {
            if (timer <= 0)
            {
                timer = 0.5f;
                switchWeapon = false;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }
}
