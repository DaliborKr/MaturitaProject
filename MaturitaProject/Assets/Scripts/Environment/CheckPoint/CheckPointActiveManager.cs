using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointActiveManager : MonoBehaviour
{
    public string key;

    public GameObject activatedCheckPoint;
    public GameObject deactivatedCheckPoint;

    private void Awake()
    {
        if (PlayerPrefs.GetInt(key) == 0)
        {
            activatedCheckPoint.SetActive(false);
            deactivatedCheckPoint.SetActive(true);
        }
        else
        {
            activatedCheckPoint.SetActive(true);
            deactivatedCheckPoint.SetActive(false);
        }
    }

    public void SetActiveCheckPoint(bool isActive)
    {
        PlayerPrefs.SetInt(key, isActive ? 1 : 0);

        if (PlayerPrefs.GetInt(key) == 0)
        {
            activatedCheckPoint.SetActive(false);
            deactivatedCheckPoint.SetActive(true);
        }
        else
        {
            activatedCheckPoint.SetActive(true);
            deactivatedCheckPoint.SetActive(false);
        }
    }
}

