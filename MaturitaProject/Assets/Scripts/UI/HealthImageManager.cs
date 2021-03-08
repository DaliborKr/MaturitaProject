using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthImageManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public Image[] lives;
    public Sprite fullHealthSprite;
    public Sprite emptyHealthSprite;
    public Sprite halfFullHealthSprite;


    // Update is called once per frame
    void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        for (int i = 0; i < lives.Length; i++)
        {
            if (i*2 < currentHealth)
            {
                if (currentHealth%2 == 1 && i*2+1 == currentHealth)
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


            if (i < maxHealth/2 + oddHelp)
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
