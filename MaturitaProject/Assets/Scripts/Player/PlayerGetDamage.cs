using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetDamage : MonoBehaviour
{
    private int currentHealth;

    private PlayerController pc;

    public Vector2 hitForce;

    public int health;

    private void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        currentHealth = health;
    }



    public void GetDamage(AttackDetails attackDetails)
    { 
        currentHealth -= attackDetails.damageNumber;

        if (attackDetails.facingDir == 1)
        {
            pc.AddForceWhenHitted(true, hitForce);
            Debug.Log("hop pravo");
        }
        else if(attackDetails.facingDir == -1)
        {
            pc.AddForceWhenHitted(false, hitForce);
            Debug.Log("hop levo");
        }

        if (currentHealth <= 0)
        {
            Debug.Log("Som mrtvy");
            Destroy(gameObject);
        }
    }
}
