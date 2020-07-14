using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryScript : MonoBehaviour
{
    public bool GetAccess(int number)
    {
        if (PlayerPrefs.GetString("Ship" + number, "false") == "true") return true;
        return false;
    }

    public void OpenAccess(int number)
    {
        PlayerPrefs.SetString("Ship" + number, "true");
    }

    public void CloseAccess(int number)
    {
        PlayerPrefs.SetString("Ship" + number, "false");
    }

    public void SetAccess(int number, bool access)
    {
        string value = "";
        if (access)
            value = "true";
        else
            value = "false";
        PlayerPrefs.SetString("Ship" + number, value);
    }
    public int GetCoins()
    {
        return PlayerPrefs.GetInt("Coins");
    }

    public void SetCoins(int coins)
    {
        PlayerPrefs.SetInt("Coins", coins);
    }

    public void AddCoins(int coins)
    {
        int value = GetCoins();
        SetCoins(value + coins);
    }

    public void TakeAwayCoins(int coins)
    {
        int value = GetCoins();
        SetCoins(value - coins);
    }

    public int GetSelect()
    {
        return PlayerPrefs.GetInt("select", 0);
    }

    public void SetSelect(int number)
    {
        PlayerPrefs.SetInt("select", number);
    }
}
