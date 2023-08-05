using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 60f; // Set the time limit for the game
    public TextMeshProUGUI timerText; // The TextMeshProUGUI object that will display the timer

    private bool timerRunning = false; // Used to track whether the timer is running

    void Start()
    {
        timerRunning = true; // Start the timer when the game starts
    }

    void Update()
    {
        if (timerRunning)
        {
            // Reduce the time remaining by the time since the last frame
            timeRemaining -= Time.deltaTime;

            // Check if the time has run out
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                GameManager.Instance.GameOver();
                timerRunning = false; // Stop the timer
            }
            if(timeRemaining <= 20)
            {
                timerText.color = Color.red; timerText.fontSize = 45;
            }

            // Update the timer text with the time remaining
            timerText.text = "Time Remaining: " + Mathf.RoundToInt(timeRemaining).ToString()+"s";
        }
    }
}
