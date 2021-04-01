using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour
{
    private Button resetButton;
    private Text deathResetText;

    private PauseMenu pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.Find("PauseManager").GetComponent<PauseMenu>();
        resetButton = GameObject.Find("RestartButton").GetComponent<Button>();
        deathResetText = GameObject.Find("DeathResetText").GetComponent<Text>();
    }

    public void setUIActive()
    {
        pauseMenu.canBeActivated = false;
        pauseMenu.DeactivateMenu();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        resetButton.enabled = true;
        deathResetText.enabled = true;
    }
}
