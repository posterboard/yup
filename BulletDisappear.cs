using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDisappear : MonoBehaviour

{
    public GameObject explosion;
    public GameObject gun;
    private bool stopCounting = false;
    private void Start()
    {
        gun = GameObject.Find("gun");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       

          if (collision.tag!="Character")
          {
            GameObject explosionClone = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(explosionClone, 0.1f);
            if (stopCounting == false)
            {
                stopCounting = true;
                gun.GetComponent<Gun>().shotsHit++;
            }

          }
    }
}
