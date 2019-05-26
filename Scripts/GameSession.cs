using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] float dieDelay = 0.3f;
    [SerializeField] int liveCounter = 1;
    [SerializeField] int score = 0;
    public static int deathCounter = 0;
    [SerializeField] Text scoreText;
    [SerializeField] Text deathText;
    
    private void Awake()
    {
        
        int GameSessionNum = FindObjectsOfType<GameSession>().Length;
        if (GameSessionNum > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


      void Start()
    {
        
        scoreText.text = score.ToString();
        deathText.text = deathCounter.ToString();
    }

    public void coinScore(int scoreAdd)
    {
        score = score+scoreAdd;
        scoreText.text = score.ToString();
    }
    public int coinCheck()
    {
        return score;

    }
    public void coinReset()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
    public void deathReset()
    {
        deathCounter = 0;
        deathText.text = deathCounter.ToString();
    }
    public  void PlayerDeath()
    {
        if (liveCounter > 1)
        {
            TakeLife();
            
        }
        else
        {
            
            StartCoroutine(ResetGame());
            //ResetGame();


        }
    }
    public void deathCount()
    {
        deathCounter += 1;
        deathText.text = deathCounter.ToString();
    }
    public int deathCheck()
    {
        return deathCounter;
    }
    private void TakeLife()
    {
        deathCount();
        liveCounter = liveCounter - 1;
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        

    }
       

   public IEnumerator ResetGame()
    {
        deathCount();
        DontDestroyOnLoad(this);
        yield return new WaitForSecondsRealtime(dieDelay);
        SceneManager.LoadScene(7);
        Destroy(gameObject);
       

    }
    
}
