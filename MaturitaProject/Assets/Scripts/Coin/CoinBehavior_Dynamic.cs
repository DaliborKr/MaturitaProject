using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior_Dynamic : MonoBehaviour
{
    public int scoreValue;
    private ScoreText scoreText;
    private Rigidbody2D rb;

    private bool isCollectedByPlayer;

    public float hitBoxRadius;

    public LayerMask isPlayer;

    private void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<ScoreText>();
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(Random.Range(-8, 8), Random.Range(3, 8));
    }

    private void FixedUpdate()
    {
        isCollectedByPlayer = Physics2D.OverlapCircle(transform.position, hitBoxRadius, isPlayer);
    }

    private void Update()
    {
        if (isCollectedByPlayer)
        {
            scoreText.IncreaseScore(scoreValue);

            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, hitBoxRadius);
    }
    /*
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Player")
        {
            scoreText.IncreaseScore(scoreValue);

            Destroy(gameObject);
        }
    }
    */
}
