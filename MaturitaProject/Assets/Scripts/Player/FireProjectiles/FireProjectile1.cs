using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile1 : MonoBehaviour
{
    [SerializeField]
    private LayerMask whatIsDamageable;

    private PlayerController pc;

    private GameObject firePointPlayer;

    private FireLinePlayer fireLinePlayer;

    private Vector2 fireDirection;

    [SerializeField]
    private int damageNumberFireProjectile1;

    [SerializeField]
    private float radiusFireProjectile1;
    [SerializeField]
    private float projectileSpeed;


    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        firePointPlayer = GameObject.Find("firePointPlayer");
        fireLinePlayer = GameObject.Find("fireLinePlayer").GetComponent<FireLinePlayer>();
        SetProjectileDirectory();
    }


    void Update()
    {
        transform.Translate(fireDirection * projectileSpeed * Time.deltaTime);
        CheckProjectileHitbox();
    }

    private void SetProjectileDirectory()
    {
        int facingDir = pc.GetFacingDir();
        fireDirection = fireLinePlayer.getFireDirection();
        if (facingDir == -1)
        {
            fireDirection.x *= -1;
        }
    }

    private void CheckProjectileHitbox()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radiusFireProjectile1, whatIsDamageable);

        AttackDetails attackDetails = new AttackDetails(damageNumberFireProjectile1, pc.transform.position);

        foreach (Collider2D collider in objects)
        {
            Debug.Log("melo by byt au");
            collider.transform.parent.SendMessage("GetDamage", attackDetails);
            Destroy(gameObject);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radiusFireProjectile1);
    }
    

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Destroy(gameObject);
    }
}
