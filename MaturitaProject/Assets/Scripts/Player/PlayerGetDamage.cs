﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGetDamage : MonoBehaviour
{
    public int currentHealth;

    private PlayerController pc;

    public Vector2 hitForce;

    public int maxHealth;

    private GameObject deadFade;
    private Animator deadTrasition;

    public GameObject coin;

    public Image[] lives;

    public Sprite fullHealthSprite;
    public Sprite emptyHealthSprite;
    public Sprite halfFullHealthSprite;

    private CameraShake cameraShake;

    public float delaySpikesDamage;
    private float lastTimeSpikesDamage = Mathf.NegativeInfinity;

    private void Start()
    {
        Time.timeScale = (1f);
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        deadFade = GameObject.Find("DeadFade");
        cameraShake = GameObject.Find("PlayerCamera").GetComponent<CameraShake>();
        deadTrasition = deadFade.GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        SetHealthImages();
    }

    public void GetDamage(AttackDetails attackDetails)
    { 
        currentHealth -= attackDetails.damageNumber;   

        pc.AddForceWhenHitted(true, hitForce);

        if (currentHealth >= 0)
        {
            cameraShake.cameraShaking = true;
        }
        if (currentHealth <= 0)
        {
            SetHealthImages();
            Die();
        }
    }

    public void GetDamageSpikes(AttackDetails attackDetails)
    {
        if (Time.time >= lastTimeSpikesDamage + delaySpikesDamage)
        {
            lastTimeSpikesDamage = Time.time;
            GetDamage(attackDetails);
        }    
    }

    public void Die()
    {
        Destroy(gameObject);

        for (int i = 0; i < 10; i++)
        {
            Instantiate(coin, transform.position, transform.rotation);
        }
        Time.timeScale = (0.5f);
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
        deadTrasition.enabled = true;
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
