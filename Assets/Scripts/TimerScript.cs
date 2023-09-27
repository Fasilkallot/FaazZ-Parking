using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 60f; 
    public TextMeshProUGUI timerText; 
    public bool timerRunning = false; 

    void Start()
    {
        GameManager.Instance.time = this;
        timerRunning = true; 
    }

    void Update()
    {
        if (timerRunning && GameManager.Instance.currentState == GameState.PalayingState)
        {
            
            timeRemaining -= Time.deltaTime;

           
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                GameManager.Instance.GameOver();
                timerRunning = false; 
            }
            if(timeRemaining <= 20)
            {
                timerText.color = Color.red; timerText.fontSize = 45;
            }

           
            timerText.text = "Time Remaining: " + Mathf.RoundToInt(timeRemaining).ToString()+"s";
        }
    }
}
