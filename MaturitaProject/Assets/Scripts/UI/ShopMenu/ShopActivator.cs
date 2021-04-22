using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopActivator : MonoBehaviour
{
    public Vector2 shopArea;

    private bool isPlayerInArea;
    private bool wasPlayerInArea;

    public LayerMask whatIsPlayer;

    public GameObject shopMenu;

    private SavePlayerManager savePlayerManager;

    private PauseMenu pauseMenu;

    void Start()
    {
        pauseMenu = GameObject.Find("PauseManager").GetComponent<PauseMenu>();
        savePlayerManager = GameObject.Find("Player").GetComponent<SavePlayerManager>();
        wasPlayerInArea = false;
    }

    private void Update()
    {
        ActivateShop();
    }

    void FixedUpdate()
    {
        CheckPlayerInArea();
    }

    public void CheckPlayerInArea()
    {
        isPlayerInArea = Physics2D.OverlapBox(transform.position, shopArea, 0, whatIsPlayer);
    }

    public void ActivateShop()
    {
        if (!pauseMenu.isActivated)
        {
            if (Input.GetKeyDown(KeyCode.E) && isPlayerInArea && !wasPlayerInArea)
            {
                pauseMenu.canBeActivated = false;
                shopMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                wasPlayerInArea = true;
            }
            else if (wasPlayerInArea && Input.GetKeyDown(KeyCode.E))
            {
                pauseMenu.canBeActivated = true;
                shopMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                wasPlayerInArea = false;
            }
            else if ((!isPlayerInArea && wasPlayerInArea))
            {
                pauseMenu.canBeActivated = true;
                shopMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                wasPlayerInArea = false;
            }
        }
    }


    private void OnDrawGizmos()
    {
        Vector3 vecotorHelpMax = new Vector3(shopArea.x, shopArea.y, 1.0f);
        Gizmos.DrawWireCube(transform.position, vecotorHelpMax);
    }
}
