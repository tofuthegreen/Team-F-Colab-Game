using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrades : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    int speedLvl = 1;
    int speedCost = 5;
    int coins;

    void Start()
    {
       coins = SaveSystem.LoadCoins();
       
    }

    public void SpeedUpgrade()
    {
        coinsText.text = SaveSystem.LoadCoins().ToString();
        costCalculator(speedCost, speedLvl);

        if (coins >= speedCost && speedLvl != 5)
        {
            VariableTransfer.speed += 2;
            coins -= speedCost;
            speedLvl++;
            
            
        }
        else if (coins < speedCost)
        {
            Debug.Log("Cant afford");
        }
        else if (speedLvl == 5)
        {
            Debug.Log("Maxed Out");
        }

    }

    public void OnClose()
    {
        SaveSystem.SaveCoins(coins);
    }

    void costCalculator(float cost, int lvl)
    {
        cost *= lvl;
    }
}
