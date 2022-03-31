using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 0.1f;
   // Vector3Int moveX = (0, 0, 0);
    public float speed = 1;
    private Vector2 direction;
    Vector2 movement;
    int subtractHealth;
    public int currentHealth;
    Vector3 currentPosition;//not currently used
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        move();

    }
    void Update()
    {
        subtractHealth = GetComponent<PlayerStats>().health;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        faceMouse();
        //Debug.Log(Time.deltaTime.ToString());
    }
    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        direction = new Vector2(mousePosition.x-transform.position.x,mousePosition.y-transform.position.y);
        transform.up = direction;
    }
    void move()
    {
        currentPosition = transform.position;//no currently used
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);  
    }
    
}
