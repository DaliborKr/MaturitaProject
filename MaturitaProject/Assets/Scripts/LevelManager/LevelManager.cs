﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public delegate void TeleportAction();
    public static event TeleportAction OnTeleported;

    public Vector3 nextLevelSpawn;

    public Vector2 portalArea;

    private bool isPlayerInArea;

    public LayerMask whatIsPlayer;

    public string sceneName;

    private SavePlayerManager savePlayerManager;

    public string activatePortalKey = "";

    public PlayerController pc;

    public CheckPointActiveManager[] checkPointsInLevel;

    private PauseMenu pauseMenu;

    private Animator transitionAnimator;

    // Start is called before the first frame update
    void Start()
    {
        savePlayerManager = GameObject.Find("Player").GetComponent<SavePlayerManager>();
        pauseMenu = GameObject.Find("PauseManager").GetComponent<PauseMenu>();
        transitionAnimator = GameObject.Find("TransitionLevel").GetComponent<Animator>();
    }

    private void Update()
    {
        ChangeLevel();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckPlayerInArea();
    }

    public void CheckPlayerInArea()
    {
        isPlayerInArea = Physics2D.OverlapBox(transform.position, portalArea, 0, whatIsPlayer);
    }

    public void ChangeLevel()
    {
        if (!pauseMenu.isActivated)
        {
            if (Input.GetKeyDown(KeyCode.E) && isPlayerInArea)
            {
                OnTeleported?.Invoke();

                if (!activatePortalKey.Equals(""))
                {
                    PlayerPrefs.SetInt(activatePortalKey, 1);
                }
                if (checkPointsInLevel != null)
                {
                    foreach (CheckPointActiveManager checkPoint in checkPointsInLevel)
                    {
                        checkPoint.SetActiveCheckPoint(false);
                    }
                }
                pc.currentSpawnPos = nextLevelSpawn;
                pc.currentLevelName = sceneName;

                StartCoroutine(LoadLevel());
            }
        }
    }

    public IEnumerator LoadLevel()
    {
        transitionAnimator.SetTrigger("SceneEnd");

        yield return new WaitForSeconds(0.7f);

        savePlayerManager.SavePlayer();
        savePlayerManager.LoadPlayerAndLevel();
    }

    /*
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    */

    private void OnDrawGizmos()
    {
        Vector3 vecotorHelpMax = new Vector3(portalArea.x, portalArea.y, 1.0f);
        Gizmos.DrawWireCube(transform.position, vecotorHelpMax);
    }
}
