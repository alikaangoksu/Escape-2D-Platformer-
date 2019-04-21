using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float LevelDelay = 2f;
    [SerializeField] float SlowMotion = 0.5f;
    
    void OnTriggerEnter2D (Collider2D other)
    {
        int coinCounter=FindObjectOfType<GameSession>().coinCheck();
        if (coinCounter%3==0)
        {
            StartCoroutine(goNextLevel());
           
            
        }
        else
        {
            //do nothing
        }
        
    }

    
    IEnumerator goNextLevel()
    {
        Time.timeScale = SlowMotion;
        yield return new WaitForSecondsRealtime(LevelDelay);
        Time.timeScale = 1f;
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
}
