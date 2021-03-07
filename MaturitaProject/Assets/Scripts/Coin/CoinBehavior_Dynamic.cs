using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior_Dynamic : MonoBehaviour
{
    public int scoreValue;
    private ScoreText scoreText;
    private Rigidbody2D rb;

    private void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<ScoreText>();
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(Random.Range(-8, 8), Random.Range(3, 8));
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
