﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileDragonsHead : MonoBehaviour
{
    public LayerMask whatIsPlayer;

    protected PlayerController pc;

    [SerializeField]
    protected int damageNumberFireProjectile1;

    [SerializeField]
    protected float radiusFireProjectile;
    [SerializeField]
    protected float projectileSpeed;

    public void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void FixedUpdate()
    {
        transform.Translate(-Vector2.right * projectileSpeed * Time.deltaTime);

        CheckProjectileHitbox();
    }

    public void CheckProjectileHitbox()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radiusFireProjectile, whatIsPlayer);

        AttackDetails attackDetails = new AttackDetails(damageNumberFireProjectile1, pc.transform.position, pc.GetFacingDir());

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