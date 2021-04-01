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

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        savePlayerManager = GameObject.Find("Player").GetComponent<SavePlayerManager>();
        pauseMenu.SetActive(false);
        isActivated = false;
        canBeActivated = true;
}

    // Update is called once per frame
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
        savePlayerManager.LoadPlayerAndLevel();
        DeactivateMenu();
    }

    public void QuitGameButton()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start_Scene");
    }
}
