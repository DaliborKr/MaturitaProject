using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemMultipleJump : ShopItem
{
    public int price;
    public int numberOfJumpsUpgrade;

    public override void AdminItem()
    {
        base.AdminItem();

        if (pc.maxNumberOfJumps == numberOfJumpsUpgrade)
        {
            buttonItem.enabled = false;
            imageItem.sprite = ownedItem;
            pricePanel.SetActive(false);
        }
        else if (pc.maxNumberOfJumps+1 == numberOfJumpsUpgrade && score < price)
        {
            buttonItem.enabled = false;
            imageItem.sprite = avaiableItemNoMoney;
            pricePanel.SetActive(true);
        }
        else if (pc.maxNumberOfJumps + 1 == numberOfJumpsUpgrade && score >= price)
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
