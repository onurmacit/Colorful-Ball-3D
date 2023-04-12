using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uıanagerScript;

    public void Start()
    {
        CoinCalculator(0);
        Debug.Log(PlayerPrefs.GetInt("moneyy"));
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("FinishLine"))
        {
            CoinCalculator(100);
            uıanagerScript.CoinTextUpdate();
            uıanagerScript.FinishScreen();

        }
    }


    public void CoinCalculator(int money)
    {
        if (PlayerPrefs.HasKey("moneyy"))
        {
            int oldScore = PlayerPrefs.GetInt("moneyy");
            PlayerPrefs.SetInt("moneyy", oldScore + money);
        }
        else
        {
            PlayerPrefs.SetInt("moneyy", 0);
        }
    }
}
