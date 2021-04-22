using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjetileEnemy : MonoBehaviour
{
    public LayerMask whatIsPlayer;

    protected PlayerController pc;

    protected Vector2 fireDirection;
    protected Vector2 startPos;
    protected Vector2 pcPos;
    protected Rigidbody2D rb;

    [SerializeField]
    protected int damageNumberFireProjectile1;

    [SerializeField]
    protected float radiusFireProjectile;
    [SerializeField]
    protected float projectileSpeed;

    public void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        pcPos = new Vector2(pc.transform.position.x, pc.transform.position.y);
        SetProjectileDirectory();
    }

    public void FixedUpdate()
    {
        transform.Translate(fireDirection * projectileSpeed * Time.deltaTime);

        CheckProjectileHitbox();
    }

    public virtual void SetProjectileDirectory()
    {
        
    }
    public void CheckProjectileHitbox()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radiusFireProjectile, whatIsPlayer);

        AttackDetails attackDetails;

        if (pc != null)
        {
            attackDetails = new AttackDetails(damageNumberFireProjectile1, pc.transform.position, pc.GetFacingDir());
        }
        else
        {
            attackDetails = new AttackDetails(damageNumberFireProjectile1, new Vector2(0,0), 1);
        }

        foreach (Collider2D collider in objects)
        {
            collider.transform.SendMessage("GetDamage", attackDetails);
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radiusFireProjectile);
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Destroy(gameObject);
    }
}
