using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public GameObject options;
    public GameObject mainMenu;

    private Animator transitionAnimator;

    private void Start()
    {
        options.SetActive(false);
        transitionAnimator = GameObject.Find("TransitionLevel").GetComponent<Animator>();
    }

    public void StartGameButton()
    {
        StartCoroutine(StartGame());
    }
    public void OptionsButton()
    {
        options.SetActive(true);
        mainMenu.SetActive(false);       
    }

    public void QuitGameButton()
    {
        StartCoroutine(QuitGame());
    }

    public IEnumerator StartGame()
    {
        transitionAnimator.SetTrigger("SceneEnd");

        yield return new WaitForSeconds(0.7f);

        PlayerData playerData = SaveManager.LoadPlayerData();
        SceneManager.LoadScene(playerData.currentLevel);
    }

    public IEnumerator QuitGame()
    {
        transitionAnimator.SetTrigger("SceneEnd");

        yield return new WaitForSeconds(0.7f);

        Application.Quit();
    }

}
