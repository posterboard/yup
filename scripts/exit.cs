using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour
{
    public GameObject[] pauseObjects;
    public GameObject[] otherUI;
    // Start is called before the first frame update
    void Start()
    {
        //pauseObjects = GameObject.FindGameObjectsWithTag("pause");
        Debug.Log("set");
       
    }
    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Time.timeScale = 0;
            foreach (GameObject g in pauseObjects)
            {
                g.SetActive(true);
     
            }
            Debug.Log("good mornign");
           foreach(GameObject f in otherUI)
            {
                f.SetActive(false);
            }
        }
    }

    // Update is called once per frame
   

    public void showPause()
    {
        
    }
}
