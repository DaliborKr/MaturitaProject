using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public bool isActivated;

    public bool canBeActivated;

    private SavePlayerManager savePlayerManager;

    private Animator transitionAnimator;

    void Start()
    {
        transitionAnimator = GameObject.Find("TransitionLevel").GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        savePlayerManager = GameObject.Find("Player").GetComponent<SavePlayerManager>();
        pauseMenu.SetActive(false);
        isActivated = false;
        canBeActivated = true;
}

    void Update()
    {
        CheckActivatePuseMenu();
    }

    public void CheckActivatePuseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isActivated)
        {
            if (canBeActivated)
            {
                ActivateMenu();
            }           
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isActivated)
        {
            DeactivateMenu();
        }
    }

    public void ActivateMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isActivated = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void DeactivateMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isActivated = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void ResumeButton()
    {
        DeactivateMenu();
    }
    public void LoadPlayerButton()
    {
        DeactivateMenu();
        Time.timeScale = 1f;
        StartCoroutine(LoadPlayer());
    }

    public void QuitGameButton()
    {
        DeactivateMenu();
        Time.timeScale = 1f;
        StartCoroutine(QuitGame());
    }

    public IEnumerator LoadPlayer()
    {
        transitionAnimator.SetTrigger("SceneEnd");

        yield return new WaitForSeconds(0.7f);

        savePlayerManager.LoadPlayerAndLevel();       
    }

    public IEnumerator QuitGame()
    {
        transitionAnimator.SetTrigger("SceneEnd");

        yield return new WaitForSeconds(0.7f);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Start_Scene");
    }
}
