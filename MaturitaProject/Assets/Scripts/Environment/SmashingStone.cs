using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashingStone : MonoBehaviour
{

    public float downSpeed;
    public float upSpeed;
    public int damageNumber;

    public Transform hitBoxPoint;
    public Transform detectPlayerPoint;

    public Vector2 damageDistance;
    public Vector2 detectPlyerDistance;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;

    private bool isDetectingPlayer;
    private bool isMovingDown;
    private bool isMovingUp;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        isMovingDown = false;
    }

    public void Update()
    {
        StartMove();
        
    }

    void FixedUpdate()
    {
        Move();
        CheckIsDetectingPlayer();
        CheckStoneHitbox();
    }

    public void StartMove()
    {
        if (isDetectingPlayer && transform.position == startPosition)
        {
            isMovingDown = true;
        }
    }

    public void Move()
    {
        if (isMovingDown)
        {
            transform.Translate(Vector2.down * downSpeed * Time.deltaTime);
        }

        if (isMovingUp && transform.position.y < startPosition.y)
        {
            transform.Translate(Vector2.up * upSpeed * Time.deltaTime);
        }
        else if (isMovingUp && transform.position.y >= startPosition.y)
        {
            isMovingUp = false;
            transform.Translate(Vector2.zero);
            transform.position = startPosition;
        }
    }

    public void CheckStoneHitbox()
    {
        if (isMovingDown)
        {
            Collider2D[] playerObjects = Physics2D.OverlapBoxAll(hitBoxPoint.position, damageDistance, 0, whatIsPlayer);

            AttackDetails attackDetails = new AttackDetails(damageNumber, transform.position, 1);

            foreach (Collider2D collider in playerObjects)
            {
                collider.transform.SendMessage("GetDamage", attackDetails);
            }

            Collider2D[] groundObjects = Physics2D.OverlapBoxAll(hitBoxPoint.position, damageDistance, 0, whatIsGround);

            foreach (Collider2D collider in groundObjects)
            {
                isMovingDown = false;
                isMovingUp = true;
            }
        }
    }

    public void CheckIsDetectingPlayer()
    {
        isDetectingPlayer = Physics2D.OverlapBox(detectPlayerPoint.position, detectPlyerDistance, 0, whatIsPlayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(hitBoxPoint.transform.position, damageDistance);
        Gizmos.DrawWireCube(detectPlayerPoint.position, detectPlyerDistance);
    }
}
