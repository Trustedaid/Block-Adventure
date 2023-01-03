using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BestScoreData
{
    public int score = 0;
}
public class Scores : MonoBehaviour
{
    public Text scoreText;
    private bool newBestScore_ = false;
    private BestScoreData bestScores_ = new BestScoreData();
    private int currentScores_;

    private string bestScoreKey_ = "bsdat";
    private void Awake()
    {
        if (BinaryDataStream.Exist(bestScoreKey_))
        {
            StartCoroutine(ReadDataFile());
        }
    }
    private IEnumerator ReadDataFile()
    {
        bestScores_ = BinaryDataStream.Read<BestScoreData>(bestScoreKey_);
        yield return new WaitForEndOfFrame();
        GameEvents.UpdateBestScoreBar(currentScores_, bestScores_.score);
    }
    private void Start()
    {
        currentScores_ = 0;
        newBestScore_ = false;
        UpdateScoreText();
    }

    private void OnEnable()
    {
        GameEvents.AddScores += AddScores;
        GameEvents.GameOver += SaveBestScores;
    }

    private void OnDisable()
    {
        GameEvents.AddScores -= AddScores;
        GameEvents.GameOver -= SaveBestScores;
    }

    public void SaveBestScores(bool newBestScores)
    {
        BinaryDataStream.Save<BestScoreData>(bestScores_,bestScoreKey_);
    }

    private void AddScores(int scores)
    {
        currentScores_ += scores;
        if (currentScores_ > bestScores_.score)
        {
            newBestScore_ = true;
            bestScores_.score = currentScores_;
            SaveBestScores(true);
        }

        GameEvents.UpdateBestScoreBar(currentScores_, bestScores_.score);

        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        scoreText.text = currentScores_.ToString();
    }

}
