using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public int scoreValue;
    private ScoreText scoreText;

    private bool isCollectedByPlayer;

    public float hitBoxRadius;

    public LayerMask isPlayer;

    public CoinActiveManager coinActiveManager;

    
    private void Awake()
    {
        coinActiveManager.SetActiveC(true);
    }
    

    private void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<ScoreText>();
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
            CoinsCollectedNotSaved.colledButNotSavedCoins.Add(coinActiveManager);
            gameObject.SetActive(false);

            //coinActiveManager.SetActiveC(false);

            //Destroy(gameObject);
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
