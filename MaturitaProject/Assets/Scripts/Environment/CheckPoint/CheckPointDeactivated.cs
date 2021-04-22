using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointDeactivated : MonoBehaviour
{
    public delegate void CheckPointAction();
    public static event CheckPointAction OnCheckPointed;

    public Vector2 checkPointArea;

    private bool isPlayerInArea;

    public LayerMask whatIsPlayer;

    private SavePlayerManager savePlayerManager;

    public PlayerController pc;

    public PlayerGetDamage playerGetDamage;

    public CheckPointActiveManager checkPointActiveManager;

    private PauseMenu pauseMenu;


    void Start()
    {
        savePlayerManager = GameObject.Find("Player").GetComponent<SavePlayerManager>();
        playerGetDamage = GameObject.Find("Player").GetComponent<PlayerGetDamage>();
        pauseMenu = GameObject.Find("PauseManager").GetComponent<PauseMenu>();
    }

    private void Update()
    {
        SaveLevel();
    }

    void FixedUpdate()
    {
        CheckPlayerInArea();
    }

    public void CheckPlayerInArea()
    {
        isPlayerInArea = Physics2D.OverlapBox(transform.position, checkPointArea, 0, whatIsPlayer);
    }

    public void SaveLevel()
    {
        if (!pauseMenu.isActivated)
        {
            if (Input.GetKeyDown(KeyCode.E) && isPlayerInArea)
            {
                OnCheckPointed?.Invoke();
                pc.currentSpawnPos = transform.position;
                savePlayerManager.SavePlayer();
                playerGetDamage.currentHealth = playerGetDamage.maxHealth;
                checkPointActiveManager.SetActiveCheckPoint(true);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 vecotorHelpMax = new Vector3(checkPointArea.x, checkPointArea.y, 1.0f);
        Gizmos.DrawWireCube(transform.position, vecotorHelpMax);
    }
}
