using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinActiveManager : MonoBehaviour
{
    private void Awake()
    {
        string key = SceneManager.GetActiveScene().name + gameObject.name;
        if (PlayerPrefs.GetInt(key) == 1)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void SetActiveC(bool isActive)
    {
        string key = SceneManager.GetActiveScene().name + gameObject.name;
        PlayerPrefs.SetInt(key, isActive ? 0 : 1);
        gameObject.SetActive(isActive);
    }
}
