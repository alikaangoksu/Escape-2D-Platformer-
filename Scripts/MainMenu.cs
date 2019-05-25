using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    GameObject[] settingsObjects;

    void Start()
    {
        
        settingsObjects = GameObject.FindGameObjectsWithTag("ShowOnSettings");
        hideSettings();
        
        
    }

    public void StartGame()
    {
        
        SceneManager.LoadScene(1);
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void Winner()
    {
        FindObjectOfType<TimeManager>().setTime();
        FindObjectOfType<GameSession>().coinReset();
        FindObjectOfType<GameSession>().deathReset();
        Time.timeScale = 0;
        SceneManager.LoadScene(0);
        
    }
    public void Settings()
    {
        showSettings();
    }
    public void showSettings()
    {
        foreach (GameObject g in settingsObjects)
        {
            g.SetActive(true);
            
        }
    }

   
    public void hideSettings()
    {
        foreach (GameObject g in settingsObjects)
        {
            g.SetActive(false);
           
        }
    }

    public void apply()
    {
        hideSettings();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
