using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class gunStats 
{
    public string name;
    public int weaponType;
    public int damage;
    public double fireRate;
    public int bulletForce;
    public int maxAmmo;
    public float reloadTime;
}

public class weaponStats : MonoBehaviour
{
    public gunStats Pistol = new gunStats
    {
        name = "Pistol",
        weaponType = 2,
        damage = 15,
        fireRate = 0.3,//as in delay
        bulletForce = 20,
        maxAmmo = 12,
        reloadTime = 1
    };
    public gunStats Sniper = new gunStats
    {
        name = "Sniper",
        weaponType = 1,
        damage = 50,
        fireRate = 2,
        bulletForce = 40,
        maxAmmo = 5,
        reloadTime = 3
    };
    // Start is called before the first frame update

}
