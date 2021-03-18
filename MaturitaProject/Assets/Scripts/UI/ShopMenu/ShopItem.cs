using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    protected PlayerController pc;
    protected PlayerCombatController playerCombatController;
    protected PlayerGetDamage playerGetDamage;
    public ScoreText scoreText;

    public GameObject pricePanel;
    public Image imageItem;
    public Button buttonItem;
    public Text description;

    public Sprite ownedItem;
    public Sprite unavaiableItem;
    public Sprite avaiableItemEnoughMoney;
    public Sprite avaiableItemNoMoney;

    protected SavePlayerManager savePlayerManager;

    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        playerCombatController = GameObject.Find("Player").GetComponent<PlayerCombatController>();
        playerGetDamage = GameObject.Find("Player").GetComponent<PlayerGetDamage>();
        savePlayerManager = GameObject.Find("Player").GetComponent<SavePlayerManager>();

        buttonItem.enabled = false;
        pricePanel.SetActive(false);
        description.enabled = false;
    }

    void Update()
    {
        AdminItem();
    }

    public virtual void AdminItem()
    {

    }

    public void SavePlayerAfterShopping()
    {
        savePlayerManager.SavePlayer();
    }

    public void EnableDestriptionText()
    {
        description.enabled = true;
    }
    public void DisableDestriptionText()
    {
        description.enabled = false;
    }

}
