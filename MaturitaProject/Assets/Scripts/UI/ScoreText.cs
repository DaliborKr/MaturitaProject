﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    public void Start()
    {
        scoreText.text = "SCORE: " + score;
    }

    public void IncreaseScore(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = "SCORE: " + score;
    }
}
