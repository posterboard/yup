using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class enemyBulletDisappear : MonoBehaviour
{
    //bullet gameObjects
    public GameObject SM;
    public GameObject explosion;
    public GameObject enemyBulletPrefab;
    public GameObject player;

    private Vector2 direction;
    private float _rangedTimer=1.0f;

    // Start is called before the first frame update
    void Start()
    {
        SM = GameObject.Find("Script_misc");
        player = GameObject.Find("player");
        pointTowardsPlayer();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void pointTowardsPlayer()
    {
        Vector3 playerPosition = player.transform.position;
        direction = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y);
        transform.up = direction;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Character")
        {
            GameObject explosionClone = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(explosionClone, 0.1f);

        }

    }
   
}
