using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemMeleeDamage : ShopItem
{
    public int price;
    public int newDamageNumber;
    public int DamageNumberBeforeUpgrade;

    public override void AdminItem()
    {
        base.AdminItem();

        if (playerCombatController.damageNumberAttack1 >= newDamageNumber)
        {
            buttonItem.enabled = false;
            imageItem.sprite = ownedItem;
            pricePanel.SetActive(false);
        }
        else if (playerCombatController.damageNumberAttack1 == DamageNumberBeforeUpgrade && score < price)
        {
            buttonItem.enabled = false;
            imageItem.sprite = avaiableItemNoMoney;
            pricePanel.SetActive(true);
        }
        else if (playerCombatController.damageNumberAttack1 == DamageNumberBeforeUpgrade && score >= price)
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
