using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemMaxHealth : ShopItem
{
    public int price;
    public int newMaxHealth;
    public int newMaxHealthBeforeUpgrade;

    public override void AdminItem()
    {
        base.AdminItem();

        if (playerGetDamage.maxHealth >= newMaxHealth)
        {
            buttonItem.enabled = false;
            imageItem.sprite = ownedItem;
            pricePanel.SetActive(false);
        }
        else if (playerGetDamage.maxHealth == newMaxHealthBeforeUpgrade && score < price)
        {
            buttonItem.enabled = false;
            imageItem.sprite = avaiableItemNoMoney;
            pricePanel.SetActive(true);
        }
        else if (playerGetDamage.maxHealth == newMaxHealthBeforeUpgrade && score >= price)
        {
            buttonItem.enabled = true;
            imageItem.sprite = avaiableItemEnoughMoney;
            pricePanel.SetActive(true);
        }
        else
        {
            buttonItem.enabled = false;
            imageItem.sprite = unavaiableItem;
            pricePanel.SetActive(false);
        }
    }
}
