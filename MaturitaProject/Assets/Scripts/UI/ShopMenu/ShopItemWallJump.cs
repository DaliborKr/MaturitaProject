using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemWallJump : ShopItem
{
    public int price;

    public override void AdminItem()
    {

        base.AdminItem();

        if (pc.wallJumpAvaiable == true)
        {
            buttonItem.enabled = false;
            imageItem.sprite = ownedItem;
            pricePanel.SetActive(false);
        }
        else if (pc.wallJumpAvaiable == false && scoreText.score < price)
        {
            buttonItem.enabled = false;
            imageItem.sprite = avaiableItemNoMoney;
            pricePanel.SetActive(true);
        }
        else if (pc.wallJumpAvaiable == false && scoreText.score >= price)
        {
            buttonItem.enabled = true;
            imageItem.sprite = avaiableItemEnoughMoney;
            pricePanel.SetActive(true);
        }
    }

    public void ButtonClickedWallJumpUpgrade()
    {
        pc.wallJumpAvaiable = true;
        scoreText.DecreaseScore(price);

        SavePlayerAfterShopping();
    }
}
