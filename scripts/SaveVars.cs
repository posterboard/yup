using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveVars : MonoBehaviour
{


    public GameObject SM;
    private static GameObject CopyandPasted;
    public int currentCoins=0;
    //private float timer = 0.1f;
    public int health = 100;
    public int maxHealth = 100;
    public int maxArmor = 100;
    public double speed = 1;

    
    public int[] gunsUnlocked = { 1,1,0};
    public string[] gunNames = {"Sniper","Pistol","M16" };
    /*
    0. Sniper
    1. Pistol
    2. m4
    
    */

    public int playerUpgradeCost = 10;
    public int currentWeaponP;
    public string currentWeaponPName;
    public int currentWeaponS;
    public string currentWeaponSName;
    // Start is called before the first frame update
    private void Start()
    {
        Application.targetFrameRate = 240;
        currentWeaponP = 0;
        currentWeaponPName = "Sniper";
        currentWeaponS = 1;
        currentWeaponSName = "Pistol";
       
        DontDestroyOnLoad(this.gameObject);
        if (CopyandPasted == null)
        {
            CopyandPasted = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

public class gunClass : MonoBehaviour
{
    public class gunStats
    {
        public string name;
        public int weaponType;
        public int damage;
        public double fireRate;// in delay
        public int bulletForce;
        public int maxAmmo;
        public float reloadTime;//in fs
        public int firingType;//0 semi 1 
    }

    
}

