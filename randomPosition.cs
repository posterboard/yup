using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPosition : MonoBehaviour
{
    int randomIntX;
    int randomIntY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        System.Random r = new System.Random();
        randomIntX = r.Next(-25, 25);
        randomIntY = r.Next(-25, 25);
        GetComponent<Transform>().position = new Vector3(randomIntX,randomIntY,0);  
    }
}
