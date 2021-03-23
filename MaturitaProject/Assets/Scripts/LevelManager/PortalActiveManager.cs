using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalActiveManager : MonoBehaviour
{
    public string key;

    public GameObject activatedPortal;
    public GameObject deactivatedPortal;


    private void Awake()
    {
        if (PlayerPrefs.GetInt(key) == 0)
        {
            activatedPortal.SetActive(false);
            deactivatedPortal.SetActive(true);
        }
        else
        {
            activatedPortal.SetActive(true);
            deactivatedPortal.SetActive(false);
        }
    }
}
