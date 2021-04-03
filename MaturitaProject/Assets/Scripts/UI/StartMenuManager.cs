using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public GameObject options;
    public GameObject mainMenu;

    private void Start()
    {
        options.SetActive(false);
    }

    public void StartGameButton()
    {
        PlayerData playerData = SaveManager.LoadPlayerData();
        SceneManager.LoadScene(playerData.currentLevel);
    }
    public void OptionsButton()
    {
        options.SetActive(true);
        mainMenu.SetActive(false);       
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
