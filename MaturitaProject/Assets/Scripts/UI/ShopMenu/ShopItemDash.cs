using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemDash : ShopItem
{
    public int price;

    public override void AdminItem()
    {
        base.AdminItem();

        if (pc.dashAvaiable == true)
        {
            buttonItem.enabled = false;
            imageItem.sprite = ownedItem;
            pricePanel.SetActive(false);
        }
        else if (pc.dashAvaiable == false && scoreText.score < price)
        {
            buttonItem.enabled = false;
            imageItem.sprite = avaiableItemNoMoney;
            pricePanel.SetActive(true);
        }
        else if (pc.dashAvaiable == false && scoreText.score >= price)
        {
            buttonItem.enabled = true;
            imageItem.sprite = avaiableItemEnoughMoney;
            pricePanel.SetActive(true);
        }
    }

    public void ButtonClickedDashUpgrade()
    {
        pc.dashAvaiable = true;
        scoreText.DecreaseScore(price);

        SavePlayerAfterShopping();
    }
}
