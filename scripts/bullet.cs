using System;
using UnityEngine;
public class bullet : MonoBehaviour
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
        public int firingType;//0 semi 1 auto
        
    }
    public gunStats Pistol = new gunStats
    {
        name = "Pistol",
        weaponType = 2,
        damage = 15,
        fireRate = 0.3,
        bulletForce = 20,
        maxAmmo = 12,
        reloadTime = 1,
        firingType = 0
    };
    public gunStats Sniper = new gunStats
    {
        name = "Sniper",
        weaponType = 1,
        damage = 50,
        fireRate = 2,
        bulletForce = 40,
        maxAmmo = 5,
        reloadTime = 3,
        firingType = 0
    };
    public gunStats M16 = new gunStats
    {
        name = "M16",
        weaponType = 1,
        damage = 100,
        fireRate = 0.2,
        bulletForce = 70,
        maxAmmo = 20,
        reloadTime = 3,
        firingType  = 1
    };
    
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject gun;
    public GameObject saveObject;
    public float bulletForce = 2;
    Quaternion currentRotation;
    Vector3 spray;
    
    public int currentSelectedGun;
    public bool finishedReloadP = true;
    public bool finishedReloadS = true;
    private float tempP;
    private float tempS;
    private double fireDelayP;
    private double fireDelayS;
    private double fireTempP;
    private double fireTempS;
    private bool fireCooldownP=false;//false: there is no cooldown true: there is
    private bool fireCooldownS = false;

    public int currentGunWhenFired;
    public gunStats currentWeaponP = new gunStats();
    public gunStats currentWeaponS = new gunStats();
    public int equippedPrimaryGunAmmo;
    public int equippedSecondaryGunAmmo;


    private void Start()
    {
        saveObject = GameObject.Find("Save");
        switch (saveObject.GetComponent<SaveVars>().currentWeaponP) {
            case 0:
                currentWeaponP = Sniper;
                break;
            case 1:
                currentWeaponP = Pistol;
                break;
            case 2:
                currentWeaponP = M16;
                break;
            default:
        currentWeaponP = Sniper;
                break;
    }
        switch (saveObject.GetComponent<SaveVars>().currentWeaponS)
        {
            case 0:
                currentWeaponS = Sniper;
                break;
            case 1:
                currentWeaponS = Pistol;
                break;
            case 2:
                currentWeaponS = M16;
                break;
            default:
                currentWeaponS = Sniper;
                break;
        }
        equippedPrimaryGunAmmo = currentWeaponP.maxAmmo;
        equippedSecondaryGunAmmo = currentWeaponS.maxAmmo;
        fireDelayP = currentWeaponP.fireRate;
        fireDelayS = currentWeaponS.fireRate;
    }

    void Update()
    {
        fireRateCheck();
        reload();
        currentSelectedGun = gun.GetComponent<Gun>().currentGun;
        currentRotation = firePoint.rotation;

        //checks to see if semi/auto for primaries
        if (currentWeaponP.firingType == 1&&currentSelectedGun==0)
        {
            if (Input.GetMouseButton(0))
            {
                if (currentSelectedGun == 0)
                {
                    currentGunWhenFired = 0;
                    bulletForce = currentWeaponP.bulletForce;
                }
                else if (currentSelectedGun == 1)
                {
                    bulletForce = currentWeaponS.bulletForce;
                    currentGunWhenFired = 1;
                }




                if (currentSelectedGun == 0 && equippedPrimaryGunAmmo > 0)
                {
                    if (fireCooldownP == false)
                    {
                        Shoot();
                        equippedPrimaryGunAmmo--;
                        fireCooldownP = true;
                        fireTempP = fireDelayP;
                    }
                }
                else if (currentSelectedGun == 1 && equippedSecondaryGunAmmo > 0)
                {
                    if (fireCooldownS == false)
                    {
                        Shoot();
                        equippedSecondaryGunAmmo--;
                        fireCooldownS = true;
                        fireTempS = fireDelayS;
                    }
                }

            }
        }
        if (currentWeaponP.firingType == 0&&currentSelectedGun==0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentSelectedGun == 0)
                {
                    currentGunWhenFired = 0;
                    bulletForce = currentWeaponP.bulletForce;
                }
                else if (currentSelectedGun == 1)
                {
                    bulletForce = currentWeaponS.bulletForce;
                    currentGunWhenFired = 1;
                }




                if (currentSelectedGun == 0 && equippedPrimaryGunAmmo > 0)
                {
                    if (fireCooldownP == false)
                    {
                        Shoot();
                        equippedPrimaryGunAmmo--;
                        fireCooldownP = true;
                        fireTempP = fireDelayP;
                    }
                }
                else if (currentSelectedGun == 1 && equippedSecondaryGunAmmo > 0)
                {
                    if (fireCooldownS == false)
                    {
                        Shoot();
                        equippedSecondaryGunAmmo--;
                        fireCooldownS = true;
                        fireTempS = fireDelayS;
                    }
                }


            }
        }


        //checks to see if semi/auto for secondaries
        if (currentWeaponS.firingType == 1 && currentSelectedGun == 1)
        {
            if (Input.GetMouseButton(0))
            {
                if (currentSelectedGun == 0)
                {
                    currentGunWhenFired = 0;
                    bulletForce = currentWeaponP.bulletForce;
                }
                else if (currentSelectedGun == 1)
                {
                    bulletForce = currentWeaponS.bulletForce;
                    currentGunWhenFired = 1;
                }




                if (currentSelectedGun == 0 && equippedPrimaryGunAmmo > 0)
                {
                    if (fireCooldownP == false)
                    {
                        Shoot();
                        equippedPrimaryGunAmmo--;
                        fireCooldownP = true;
                        fireTempP = fireDelayP;
                    }
                }
                else if (currentSelectedGun == 1 && equippedSecondaryGunAmmo > 0)
                {
                    if (fireCooldownS == false)
                    {
                        Shoot();
                        equippedSecondaryGunAmmo--;
                        fireCooldownS = true;
                        fireTempS = fireDelayS;
                    }
                }

            }
        }
        if (currentWeaponS.firingType == 0 && currentSelectedGun == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentSelectedGun == 0)
                {
                    currentGunWhenFired = 0;
                    bulletForce = currentWeaponP.bulletForce;
                }
                else if (currentSelectedGun == 1)
                {
                    bulletForce = currentWeaponS.bulletForce;
                    currentGunWhenFired = 1;
                }




                if (currentSelectedGun == 0 && equippedPrimaryGunAmmo > 0)
                {
                    if (fireCooldownP == false)
                    {
                        Shoot();
                        equippedPrimaryGunAmmo--;
                        fireCooldownP = true;
                        fireTempP = fireDelayP;
                    }
                }
                else if (currentSelectedGun == 1 && equippedSecondaryGunAmmo > 0)
                {
                    if (fireCooldownS == false)
                    {
                        Shoot();
                        equippedSecondaryGunAmmo--;
                        fireCooldownS = true;
                        fireTempS = fireDelayS;
                    }
                }


            }
        }
        
    }
    void Shoot()
    {
        System.Random r = new System.Random();
        GetComponent<Gun>().shotsFired++;
        if (currentSelectedGun == 0)
        {

            if (finishedReloadP == true)
            {
                int randomInt = r.Next(-180, 180);
                float randomFloat = Convert.ToSingle(randomInt);
                spray = new Vector3(0, 0, randomFloat);
                // Debug.Log(randomFloat);
                currentRotation.eulerAngles += spray;
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, currentRotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            }
        }
        else if (currentSelectedGun == 1)
        {

            if (finishedReloadS == true)
            {

                int randomInt = r.Next(-180, 180);
                float randomFloat = Convert.ToSingle(randomInt);
                spray = new Vector3(0, 0, randomFloat);
                // Debug.Log(randomFloat);
                currentRotation.eulerAngles += spray;
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, currentRotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            }
        }
    }
    void reload() {
        if (Input.GetKeyDown("r")){


            tempP = Sniper.reloadTime;
            tempS = Pistol.reloadTime;
            if (currentSelectedGun == 0&&equippedPrimaryGunAmmo!=currentWeaponP.maxAmmo)
            {
                finishedReloadP = false;
                if (finishedReloadP == true)
                {
                    
                    tempP = Sniper.reloadTime;
                }
            } else if (currentSelectedGun == 1&&equippedSecondaryGunAmmo!=currentWeaponS.maxAmmo)
            {
                finishedReloadS = false;
                if (finishedReloadS==true)
                {
     
                    tempS = Pistol.reloadTime;

                }
            }
           
        }
        if (finishedReloadP != true)
        {

            tempP -= Time.deltaTime;
            if (tempP < 0)
            {
                equippedPrimaryGunAmmo = currentWeaponP.maxAmmo;
                finishedReloadP = true;
            }
        }
        if (finishedReloadS != true)
        {
            tempS -= Time.deltaTime;
            if (tempS < 0)
            {
                equippedSecondaryGunAmmo = currentWeaponS.maxAmmo;
                finishedReloadS = true;
            }
        }
    }

    void fireRateCheck()
    {
        if (fireCooldownP != false)
        {
            fireTempP -= Time.deltaTime;
            if (fireTempP < 0)
            {
                fireCooldownP = false;
                fireTempP = fireDelayP;

            }
        }else if(fireCooldownS != false)
        {
            fireTempS -= Time.deltaTime;
            if (fireTempS < 0)
            {
                fireCooldownS = false;
                fireTempS = fireDelayS;
            }
        }
    }
}
