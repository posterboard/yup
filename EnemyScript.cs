using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private Vector2 direction;
    public GameObject target;
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject gun;
    public GameObject scriptMisc;
    public GameObject saveObject;

    public GameObject enemyBulletPrefab;

    public Sprite currentSprite;
    private bool dpsController = true;
    public float dpsTimer = 1.0f;
    private float _rangedTimer = 1.0f;
    private int leftoverDamage;
    public bool dead = false;
    private bool _collectedMoney = false;
    private int currentHealth;
    private int selectedWeaponWhenFiring;
    private int bulletDamage;
    private int _damageDelay;
    // Start is called before the first frame update
    public class enemyStats
    {
        public int health;
        public int damage;
        public int rangedDamage = 0;
        public int speed;
        public int moneyDrop;
        public int typeOfEnemy;
    }
    public enemyStats basicEnemy = new enemyStats
    {
        health = 60,
        damage = 6,
        speed = 4,
        moneyDrop = 2,
        typeOfEnemy =0
    };
    public enemyStats fastEnemy = new enemyStats
    {
        health = 30,
        damage = 13,
        speed = 6,
        moneyDrop = 5,
        typeOfEnemy = 1
    };
    public enemyStats strongEnemy = new enemyStats { 
        health = 100,
        damage = 20,
        speed = 2,
        moneyDrop = 12,
        typeOfEnemy = 2
    };
    public enemyStats shooterEnemy = new enemyStats
    {
        health = 70,
        damage = 0,
        rangedDamage = 15,
        speed = 3,
        moneyDrop = 15,
        typeOfEnemy = 3
    };
    public enemyStats currentEnemy = new enemyStats();
    void Start()
    {
        

        target = GameObject.Find("player");
        player = GameObject.Find("player");
        gun = GameObject.Find("gun");
        saveObject = GameObject.Find("Save");

        scriptMisc = GameObject.Find("Script_misc");
        if (scriptMisc.GetComponent<CreateNewEnemy>().enemyType == 0)
        {
            currentEnemy = basicEnemy;
            currentHealth = currentEnemy.health;
            GetComponent<SpriteRenderer>().color =Color.blue;
        }
        if (scriptMisc.GetComponent<CreateNewEnemy>().enemyType == 1)
        {
            currentEnemy = fastEnemy;
            currentHealth = currentEnemy.health;
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        if (scriptMisc.GetComponent<CreateNewEnemy>().enemyType == 2)
        {
            currentEnemy = strongEnemy;
            currentHealth = currentEnemy.health;
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (scriptMisc.GetComponent<CreateNewEnemy>().enemyType == 3) 
            {
            currentEnemy = shooterEnemy;
            currentHealth = currentEnemy.health;
            GetComponent<SpriteRenderer>().color = Color.magenta;
            } 

    }
    // Update is called once per frame
    void Update()
    {
        
        if (player.GetComponent<PlayerStats>().health <= 0)
        {
            dead = true;
        }
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject,0.5f);
            if (_collectedMoney == false)
            {
                saveObject.GetComponent<SaveVars>().currentCoins += currentEnemy.moneyDrop;
                _collectedMoney = true;
            }
            /*                                      if (currentEnemy.typeOfEnemy == 0) {
                scriptMisc.GetComponent<CreateNewEnemy>().numberNormalEnemies--;
            } else if (currentEnemy.typeOfEnemy == 1)
            {
                scriptMisc.GetComponent<CreateNewEnemy>().numberFastEnemies--;
            } else if (currentEnemy.typeOfEnemy == 2)
            {
                scriptMisc.GetComponent<CreateNewEnemy>().numberStrongEnemies--;
            }*/
        }
        else
        {
            shootingEnemy();
            moveTowardsPlayer();
            dpsControl();
            GetComponent<Rigidbody2D>().AddForce(Vector3.up);
            RotateTowards(target.transform.position);
        }
        }
    void moveTowardsPlayer()
    {
        Vector3 playerPosition = target.GetComponent<Transform>().position;
        transform.position = Vector3.MoveTowards(transform.position, target.GetComponent<Transform>().position, currentEnemy.speed * Time.deltaTime);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Character") {

            if (dpsController == true) {
                if (player.GetComponent<PlayerStats>().armor > 0) {
                    if (player.GetComponent<PlayerStats>().armor >= currentEnemy.damage)
                    {
                        player.GetComponent<PlayerStats>().armor -= currentEnemy.damage;
                    }
                    else
                    {
                        leftoverDamage = currentEnemy.damage - player.GetComponent<PlayerStats>().armor;
                        player.GetComponent<PlayerStats>().armor = 0;
                        player.GetComponent<PlayerStats>().health -= leftoverDamage;    
                    }
                }
                else {
                    player.GetComponent<PlayerStats>().health -= currentEnemy.damage;
                }
                dpsController = false;

            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        selectedWeaponWhenFiring = gun.GetComponent<bullet>().currentSelectedGun;
        if (collision.tag == "bullet")
        {
            if (selectedWeaponWhenFiring == 0)
            {
                currentHealth -= gun.GetComponent<bullet>().currentWeaponP.damage;
                //  Debug.Log("Primary Damage " + gun.GetComponent<bullet>().currentWeaponP.damage);
            }
            else
            if (selectedWeaponWhenFiring == 1)
            {
                currentHealth -= gun.GetComponent<bullet>().currentWeaponS.damage;
            }
        }
    }
    void dpsControl()
    {
        if (dpsController == false)
        {
            if (dpsTimer < 0)
            {
                dpsTimer = 1.0f;
                dpsController = true;
            }
            else
            {

                dpsTimer -= Time.deltaTime;
            }
        }
    }
    private void RotateTowards(Vector2 target)
    {
        var offset = 90f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg+180;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
    void shootingEnemy()
    {
        if (GetComponent<EnemyScript>().currentEnemy.rangedDamage != 0)
        {
            if (_rangedTimer <= 0)
            {
                GameObject enemyBullet = Instantiate(enemyBulletPrefab, transform);
                _rangedTimer = 1.0f;
                Rigidbody2D rb = enemyBullet.GetComponent<Rigidbody2D>();
                rb.AddForce(transform.up * 10, ForceMode2D.Impulse);
                Debug.Log("bullet instanted");
            }
            else
            {
                _rangedTimer -= Time.deltaTime;
            }
        }
    }
}
