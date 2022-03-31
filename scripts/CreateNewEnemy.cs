using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewEnemy : MonoBehaviour
{
    float spawnTime = 5f;
    float spawnCountdown;
    public bool allEnemiesDead=true;
    public GameObject enemyPrefab;
    public Transform randomPlace;

    public int wave = 0;

    public int numberNormalEnemies=0;
    public int numberFastEnemies=0;
    public int numberStrongEnemies = 0;

    public int enemyType;

    public int changeEnemyType = 0;

    System.Random r = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        spawnCountdown = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(spawnCountdown+ " "+timerOff);
        if (spawnCountdown > 0)
        {
            spawnCountdown -= Time.deltaTime;

        }
        else
        {
            spawnCountdown = spawnTime;
            GameObject newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = new Vector3(r.Next(-27, 27), r.Next(-27, 27), 0);
            enemyType = r.Next(0,4);
        }
        {
       /*     {
                spawnCountdown = spawnTime;
                timerOff = true;
            }
            if (allEnemiesDead == true)
            {
                changeEnemyType = 0;
                wave++;
                Debug.Log("wave:" + wave);
                switch (wave)
                {
                    case 1:
                        numberNormalEnemies = 5;
                        numberFastEnemies = 0;
                        numberStrongEnemies = 0;
                        allEnemiesDead = false;
                        newWave = true;
                        break;
                    case 2:
                        numberNormalEnemies = 7;
                        numberFastEnemies = 3;
                        numberStrongEnemies = 0;
                        allEnemiesDead = false;
                        newWave = true;
                        break;
                    case 3:
                        numberNormalEnemies = 10;
                        numberFastEnemies = 5;
                        numberStrongEnemies = 0;
                        allEnemiesDead = false;
                        newWave = true;
                        break;
                    case 4:
                        numberNormalEnemies = 13;
                        numberFastEnemies = 7;
                        numberStrongEnemies = 1;
                        allEnemiesDead = false;
                        newWave = true;
                        break;
                    default:
                        numberNormalEnemies = 0;
                        numberFastEnemies = 0;
                        allEnemiesDead = false;
                        newWave = true;
                        break;
                }


            }
            if (numberNormalEnemies == 0 && numberFastEnemies == 0 && numberStrongEnemies == 0)
            {
                allEnemiesDead = true;
            }
            if (newWave == true)
            {
                //       newWave = false;
                if (timerOff == true)
                {
                    if (changeEnemyType == 0)//notes the problem is that the for loops all take place in one frame
                    {
                        for (int i = 0; i < numberNormalEnemies; i++)
                        {
                            GameObject newEnemy = Instantiate(enemyPrefab);
                            newEnemy.transform.position = new Vector3(r.Next(-27, 27), r.Next(-27, 27), 0);
                            enemyType = 0;

                        }
                        changeEnemyType++;
                    }
                }
                if (timerOff == true)
                {
                    if (changeEnemyType == 1)
                    {
                        for (int i = 0; i < numberFastEnemies; i++)
                        {
                            GameObject newEnemy = Instantiate(enemyPrefab);
                            newEnemy.transform.position = new Vector3(r.Next(-27, 27), r.Next(-27, 27), 0);
                            enemyType = 1;
                        }
                        changeEnemyType++;
                    }
                }
                if (timerOff == true)
                {
                    if (changeEnemyType == 2)
                    {
                        for (int i = 0; i < numberStrongEnemies; i++)
                        {
                            GameObject newEnemy = Instantiate(enemyPrefab);
                            newEnemy.transform.position = new Vector3(r.Next(-27, 27), r.Next(-27, 27), 0);
                            enemyType = 2;
                        }

                    }
                }
            }
        */}//useless?
    }
}
