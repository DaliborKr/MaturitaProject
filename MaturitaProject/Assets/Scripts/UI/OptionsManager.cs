using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    Resolution[] resolutions;

    public Dropdown dropdownRes;

    public Toggle toggleFullscreen;

    public GameObject mainMenu;

    void Start()
    {
        if (Screen.fullScreen)
        {
            toggleFullscreen.isOn = true;
        }
        else
        {
            toggleFullscreen.isOn = false;
        }     
        
        resolutions = Screen.resolutions;

        dropdownRes.ClearOptions();

        List<string> resolutionsString = new List<string>();

        int currentResIndex = 0; 

        for (int i = 0; i < resolutions.Length; i++)
        {
            string resolutionString = resolutions[i].width + " x " + resolutions[i].height;
            resolutionsString.Add(resolutionString);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }

        dropdownRes.AddOptions(resolutionsString);

        dropdownRes.value = currentResIndex;
        dropdownRes.RefreshShownValue();
        SetNewResolution(currentResIndex);
    }

    void Update()
    {
        
    }

    public void SetNewResolution(int resIndex)
    {
        Screen.SetResolution(resolutions[resIndex].width, resolutions[resIndex].height, Screen.fullScreen);
    }

    public void FullscreenButton(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    public void BackButton()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
