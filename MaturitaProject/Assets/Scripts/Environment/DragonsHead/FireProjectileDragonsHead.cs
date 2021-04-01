using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileDragonsHead : MonoBehaviour
{
    public LayerMask whatIsPlayer;

    [SerializeField]
    protected int damageNumberFireProjectile1;

    [SerializeField]
    protected float radiusFireProjectile;
    [SerializeField]
    protected float projectileSpeed;

    public void Start()
    {
    }

    public void FixedUpdate()
    {
        transform.Translate(-Vector2.right * projectileSpeed * Time.deltaTime);

        CheckProjectileHitbox();
    }

    public void CheckProjectileHitbox()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radiusFireProjectile, whatIsPlayer);

        AttackDetails attackDetails = new AttackDetails(damageNumberFireProjectile1, transform.position, 1);

        foreach (Collider2D collider in objects)
        {
            Debug.Log("melo by byt au");
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
