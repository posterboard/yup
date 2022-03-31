using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiedMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void goToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void exitGame (){
        Application.Quit();
    }
    public void shop()
    {
        SceneManager.LoadScene(4);
    }
}        
