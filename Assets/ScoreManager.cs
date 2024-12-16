using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //O

    public static ScoreManager Instance;
    public TextMeshProUGUI scoreText; 
    private int score = 0;

    void Start()
    {
     
        if (Instance == null)
        {
            Instance = this;
        }

        if (scoreText == null)
        {
            Debug.LogError("ScoreText not assigned in the inspector");
        }

        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        //Inkap
        score += points;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}