using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public int scoreValue;
    private ScoreText scoreText;

    private void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<ScoreText>();
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Player")
        {
            scoreText.IncreaseScore(scoreValue);

            Destroy(gameObject);
        }
    }
}
