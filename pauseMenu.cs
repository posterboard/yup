using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// for the canvas 
public class pauseMenu : MonoBehaviour
{
    public GameObject[] pauseObjects;
    public GameObject[] otherUI;
    // Start is called before the first frame update
    void Start()
    {
        pauseObjects = GameObject.FindGameObjectsWithTag("pause");
        hidePause();
    }


    public void bye()
    {
        Application.Quit();
    }
    public void hidePause()
    {
        Time.timeScale = 1;
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
            
        }
        foreach (GameObject f in otherUI)
        {
            f.SetActive(true);
        }
    }
}
