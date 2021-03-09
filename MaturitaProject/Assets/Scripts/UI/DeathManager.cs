using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour
{
    private Button resetButton;
    private Text deathResetText;

    // Start is called before the first frame update
    void Start()
    {
        resetButton = GameObject.Find("RestartButton").GetComponent<Button>();
        deathResetText = GameObject.Find("DeathResetText").GetComponent<Text>();
    }

    public void setUIActive()
    {
        resetButton.enabled = true;
        deathResetText.enabled = true;
    }
}
