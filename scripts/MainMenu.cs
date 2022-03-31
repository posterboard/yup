using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void moreInfo()
    {
        SceneManager.LoadScene(1);

    }
    public void back()
    {
        SceneManager.LoadScene(0);
      
    }
    public void play()
    {
        SceneManager.LoadScene(5);
    }
    public void quit()
    {
        Application.Quit();
    }
}
