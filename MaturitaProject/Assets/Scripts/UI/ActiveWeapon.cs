using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveWeapon : MonoBehaviour
{

    private PlayerCombatController playerCombatController;

    public Sprite Melee;
    public Sprite Fire;

    private Image currentWeaponImage;

    // Start is called before the first frame update
    void Start()
    {
        playerCombatController = GameObject.Find("Player").GetComponent<PlayerCombatController>();
        currentWeaponImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCombatController.isMelee)
        {
            currentWeaponImage.sprite = Melee;
        }
        else
        {
            currentWeaponImage.sprite = Fire;
        }
    }
}
