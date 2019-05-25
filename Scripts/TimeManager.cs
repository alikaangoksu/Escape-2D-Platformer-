using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    
    int i = 0;
    // [SerializeField] float  startingTime=15;
    IList<float> startingTime = new List<float>() { 15, 25,30, 45, 50, 100,25,30,45,50,25,30,45,50 };
    [SerializeField] float countingTime;

    private Text timeText;


    void Start()
    {

        countingTime = startingTime[i];
        timeText = GetComponent<Text>();


    }
    public void timeReset()
    {

        i++;
        //startingTime += 15;
        countingTime = startingTime[i];


    }
    public void setTime()
    {
        countingTime = 15;
    }
   
    void Update()
    {
        countingTime -= Time.deltaTime;
     
        if (countingTime<=0)
        {
            countingTime = countingTime + 0.5f;
             FindObjectOfType<GameSession>().PlayerDeath();
        }
        timeText.text = "" + Mathf.Round (countingTime);
    }
}
