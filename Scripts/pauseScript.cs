using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class pauseScript : MonoBehaviour
{
    GameObject[] pauseObjects;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1) { 

                Time.timeScale = 0;
                showPaused();

            }
            else { 
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }
    public void pauseGame()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
    public void ReturnMenu()
    {
        hidePaused();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
        FindObjectOfType<GameSession>().coinReset();
        FindObjectOfType<TimeManager>().setTime();
    }
}
