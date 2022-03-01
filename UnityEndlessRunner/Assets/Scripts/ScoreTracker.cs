using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] double currentScore, topScore;  // Variables used to keep track of the score
    public Text scoreText, topScoreText;  // this is the text that gets updated based on the variables above 

    void Start(){
        currentScore = 0;                               // reset current score to 0
        topScore = PlayerPrefs.GetInt("highscore", 0);   // assign topScore to player's best score
    }
    // Update is called once per frame
    void Update()
    {
        scoreUpdate();     
    }

    void scoreUpdate(){
        currentScore += 5 * Time.deltaTime;                            // increments score by 1 every 1/5th of a second
        string roundedScoreText = Math.Round(currentScore).ToString(); // variable used to round score and convert its type to string
        scoreText.text = roundedScoreText;                             // assigning scoreText to the rounded currentScoure     

        if(currentScore > topScore){
            PlayerPrefs.SetInt("highscore", (int)currentScore);  // using PlayerPrefs to keep track of highscore
            PlayerPrefs.Save();                                  
            topScoreText.text = roundedScoreText;
        }
        else{
            topScoreText.text = topScore.ToString();                 
        }

    }
}