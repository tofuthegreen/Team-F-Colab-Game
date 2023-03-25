using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrades : MonoBehaviour
{
   public TextMeshProUGUI coinsText,speedText,CostText;
   public int speedLvl = 1;
   public int speedCost = 5;
   int coins;

    void Start()
    {
        coins = SaveSystem.LoadData("coins");
        coinsText.text = coins.ToString();
        SaveSystem.LoadShop(this);
        speedText.text = "Speed Level: " + speedLvl;
        CostText.text = "Cost: " + speedCost;
    }
    public void SpeedUpgrade()
    {
        costCalculator(speedCost, speedLvl);

        if (coins >= speedCost && speedLvl != 5)
        {
            VariableTransfer.speed += 2;
            coins -= speedCost;
            speedLvl++;
            speedCost =+ (speedLvl * 2);
            coinsText.text = coins.ToString();
            speedText.text = "Speed Level: " + speedLvl;
            CostText.text = "Cost: " + speedCost;

        }
        else if (coins < speedCost)
        {
            float time = 3f;
            while (time > 0)
            {
                CostText.text = "Low Coins";
                time -= Time.deltaTime;
            }
            speedText.text = "Speed Level: " + speedLvl;
        }
        else if (speedLvl == 5)
        {
            CostText.text = "Maxed out"; 
        }

    }


    public void OnClose()
    {
        SaveSystem.SavePlayer(VariableTransfer.speed);
        SaveSystem.SaveData(coins,"coins");
        SaveSystem.SaveShop(speedLvl, speedCost);
    }

    void costCalculator(float cost, int lvl)
    {
        cost *= lvl;
    }
}
