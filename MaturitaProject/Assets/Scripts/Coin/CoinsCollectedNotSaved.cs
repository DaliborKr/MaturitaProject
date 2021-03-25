using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollectedNotSaved : MonoBehaviour
{
    public static List<CoinActiveManager> colledButNotSavedCoins = new List<CoinActiveManager>();

    public static void SetCollectedCoinsAfterSave()
    {
        if (colledButNotSavedCoins != null)
        {
            foreach (CoinActiveManager coin in colledButNotSavedCoins)
            {
                coin.SetActiveC(false);
            }
            colledButNotSavedCoins.Clear();
        }   
    }

    public static void ClearCollectedCoins()
    {
        colledButNotSavedCoins.Clear();
    }
}

