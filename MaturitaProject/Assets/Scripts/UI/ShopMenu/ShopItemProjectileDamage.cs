using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemProjectileDamage : ShopItem
{
    public int price;
    public int newProjectileTypeIndex;
    public int projectileIndexbeforeUpgrade;

    public override void AdminItem()
    {
        base.AdminItem();

        if (newProjectileTypeIndex == 0)
        {
            if (playerCombatController.projectileType >= newProjectileTypeIndex && playerCombatController.fireAvaiable)
            {
                buttonItem.enabled = false;
                imageItem.sprite = ownedItem;
                pricePanel.SetActive(false);
            }
            else if (!playerCombatController.fireAvaiable && scoreText.score < price)
            {
                buttonItem.enabled = false;
                imageItem.sprite = avaiableItemNoMoney;
                pricePanel.SetActive(true);
            }
            else if (!playerCombatController.fireAvaiable && scoreText.score >= price)
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
        else
        {
            if (playerCombatController.projectileType >= newProjectileTypeIndex && playerCombatController.fireAvaiable)
            {
                buttonItem.enabled = false;
                imageItem.sprite = ownedItem;
                pricePanel.SetActive(false);
            }
            else if (playerCombatController.projectileType == projectileIndexbeforeUpgrade && playerCombatController.fireAvaiable && scoreText.score < price)
            {
                buttonItem.enabled = false;
                imageItem.sprite = avaiableItemNoMoney;
                pricePanel.SetActive(true);
            }
            else if (playerCombatController.projectileType == projectileIndexbeforeUpgrade && playerCombatController.fireAvaiable && scoreText.score >= price)
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

    public void ButtonClickedFireEnableUpgrade()
    {
        playerCombatController.fireAvaiable = true;
        scoreText.DecreaseScore(price);

        SavePlayerAfterShopping();
    }
    public void ButtonClickedPowerFireUpgrade()
    {
        playerCombatController.projectileType = newProjectileTypeIndex;
        scoreText.DecreaseScore(price);

        SavePlayerAfterShopping();
    }
}
