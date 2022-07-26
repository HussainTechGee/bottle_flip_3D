using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public int TotalCoin;
    public bool isTesting;
    private void Awake()
    {

        if(isTesting)
        {
            PlayerPrefs.SetInt("totalcoin", TotalCoin);
        }
        instance = this;
        TotalCoin = PlayerPrefs.GetInt("totalcoin");
    }
    public void CoinAdd(int amount)
    {
        TotalCoin = TotalCoin + amount;
        PlayerPrefs.SetInt("totalcoin", TotalCoin);
        UIManager.instance.CoinRefresh();
    }
    public void RemoveCoin(int amount)
    {
        if (TotalCoin >= amount)
        {
            TotalCoin = TotalCoin - amount;
            PlayerPrefs.SetInt("totalcoin", TotalCoin);
            UIManager.instance.CoinRefresh();
        }
        else
        {
            Debug.Log("Not Enough Coin");
        }
    }
    
}
