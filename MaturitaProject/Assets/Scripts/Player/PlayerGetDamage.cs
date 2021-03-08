﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGetDamage : MonoBehaviour
{
    private int currentHealth;

    private PlayerController pc;

    public Vector2 hitForce;

    public int maxHealth;

    public Image[] lives;

    public Sprite fullHealthSprite;
    public Sprite emptyHealthSprite;
    public Sprite halfFullHealthSprite;

    private void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        currentHealth = maxHealth;
    }

    public void GetDamage(AttackDetails attackDetails)
    { 
        currentHealth -= attackDetails.damageNumber;

        SetHealthImages();


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

    public void SetHealthImages()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        for (int i = 0; i < lives.Length; i++)
        {
            if (i * 2 < currentHealth)
            {
                if (currentHealth % 2 == 1 && i * 2 + 1 == currentHealth)
                {
                    lives[i].sprite = halfFullHealthSprite;
                }
                else
                {
                    lives[i].sprite = fullHealthSprite;
                }

            }
            else
            {
                lives[i].sprite = emptyHealthSprite;
            }


            int oddHelp;

            if (maxHealth % 2 == 1)
            {
                oddHelp = 1;
            }
            else
            {
                oddHelp = 0;
            }


            if (i < maxHealth / 2 + oddHelp)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }
        }
    }
}
