using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private int score;
    public Text scoreText;

    public void IncreaseScore(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = "SCORE: " + score;
    }
}
