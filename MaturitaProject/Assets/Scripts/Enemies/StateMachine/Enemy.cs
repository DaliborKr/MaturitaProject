using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public FiniteStateMachine stateMachineEnemy;

    public D_Enemy enemyData;

    public GameObject player;

    public Transform[] firePoints;

    public int facingDir
    {
        get;
        private set;
    }

    public Rigidbody2D rb
    {
        get;
        private set;
    }

    public Animator anim
    {
        get;
        private set;
    }

    public GameObject aliveGameObject
    {
        get;
        private set;
    }

    public AnimationToStates animationToStates
    {
        get;
        private set;
    }

    private int curentHealth;

    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheck;
    [SerializeField]
    private Transform playerMinCheckAgroRange;
    [SerializeField]
    private Transform playerMaxCheckAgroRange;
    [SerializeField]
    protected Transform attackPoint;

    [SerializeField]
    private GameObject coin;

    private Vector2 velocityHolder;

    public virtual void Start()
    {
        aliveGameObject = transform.Find("Alive").gameObject;
        rb = aliveGameObject.GetComponent<Rigidbody2D>();
        anim = aliveGameObject.GetComponent<Animator>();
        animationToStates = aliveGameObject.GetComponent<AnimationToStates>();
        player = GameObject.Find("Player");

        stateMachineEnemy = new FiniteStateMachine();

        curentHealth = enemyData.maxHealth;
        facingDir = 1;
    }

    public virtual void Update()
    {
        stateMachineEnemy.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachineEnemy.currentState.PhysicsUpdate();
    }

    public virtual void GetDamage(AttackDetails attackDetails)
    {
        curentHealth -= attackDetails.damageNumber;
        /*
        Debug.Log("au");

        if (curentHealth <= 0)
        {
            Die();
        }
        */
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void SetVelocity(float velocity)
    {
        velocityHolder.Set(facingDir * velocity, rb.velocity.y);
        rb.velocity = velocityHolder;
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, aliveGameObject.transform.right, enemyData.wallCheckDist, enemyData.whatIsGround);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, enemyData.ledgeCheckDist, enemyData.whatIsGround);
    }

    public virtual bool CheckMinAgroRange()
    {
        return Physics2D.OverlapBox(playerMinCheckAgroRange.position, enemyData.minAgroRangeDist, 0,enemyData.whatIsPlayer);

    }

    public virtual bool CheckMaxAgroRange()
    {
        return Physics2D.OverlapBox(playerMaxCheckAgroRange.position, enemyData.maxAgroRangeDist, 0, enemyData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMeleeAttackRange() 
    {
        return Physics2D.OverlapCircle(attackPoint.position, enemyData.meleeAttackRange, enemyData.whatIsPlayer); 
    }

    public virtual bool CheckPlayerRunOutOfLives()
    {

        if (curentHealth <= 0)
        {
            Debug.Log("umrel");
            return true;
        }
        else
        {
            return false;
        }
    }

    public void InstantiateCoins()
    {
        int numberOfCoins = Random.Range(3, 4);

        for (int i = 0; i < numberOfCoins; i++)
        {
            Instantiate(coin, aliveGameObject.transform.position, aliveGameObject.transform.rotation);
        }
    }

    public void InstantiateProjectiles(GameObject[] projectilePrefab)
    {
        for (int i = 0; i < firePoints.Length; i++)
        {
            Instantiate(projectilePrefab[i], firePoints[i].position, firePoints[i].rotation);
        }
    }

    public int GetMaxHealth()
    {
        return enemyData.maxHealth;
    }

    public int GetCurrentHealth()
    {
        return curentHealth;
    }

    public virtual void Flip()
    {
        facingDir *= -1;
        aliveGameObject.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDir * enemyData.wallCheckDist));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * enemyData.ledgeCheckDist));

        Vector3 vecotorHelpMin = new Vector3(enemyData.minAgroRangeDist.x, enemyData.minAgroRangeDist.y, 1.0f);
        Gizmos.DrawWireCube(playerMinCheckAgroRange.position, vecotorHelpMin);

        Vector3 vecotorHelpMax = new Vector3(enemyData.maxAgroRangeDist.x, enemyData.maxAgroRangeDist.y, 1.0f);
        Gizmos.DrawWireCube(playerMaxCheckAgroRange.position, vecotorHelpMax);

        Gizmos.DrawWireSphere(attackPoint.position, enemyData.meleeAttackRange);

    }
}