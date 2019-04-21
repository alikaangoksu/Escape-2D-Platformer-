using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int liveCounter = 1;
    [SerializeField] int score = 0;
    [SerializeField] Text scoreText;
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
    public void PlayerDeath()
    {
        if (liveCounter > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGame();
        }
    }

    private void TakeLife()
    {
        liveCounter = liveCounter - 1;
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);

    }

    private void ResetGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    
}
