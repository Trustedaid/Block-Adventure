using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public Text scoreText;
    private int currentScores_;

    private void Start()
    {
        currentScores_ = 0;
        UpdateScoreText();
    }

    private void OnEnable()
    {
        GameEvents.AddScores += AddScores;
    }

    private void OnDisable()
    {
        GameEvents.AddScores -= AddScores;
    }
    private void AddScores(int scores)
    {
        currentScores_ += scores;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        scoreText.text = currentScores_.ToString();
    }

}
