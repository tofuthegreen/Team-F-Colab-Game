using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
   public TextMeshProUGUI coinsText,speedText,CostText,noCoins;
   public bool[] boughtSkin;
   public int[] skinCost;
   public int speedLvl = 1;
   public int speedCost = 100;
   int coins;
   public ChangeSkin skinChanger;
    public DropDown dropDown;
    void Start()
    {
        noCoins.text = "";
        coins = SaveSystem.LoadData("coins");
        coinsText.text = coins.ToString();
        SaveSystem.LoadShop(this);
        dropDown.UpdateList();
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
            speedCost *= speedLvl;
            coinsText.text = coins.ToString();
            speedText.text = "Speed Level: " + speedLvl;
            CostText.text = "Cost: " + speedCost;

        }
        else if (coins < speedCost)
        {
            StartCoroutine(Duration(CostText, "Not enough Coins", "Cost: " + speedCost));
        }
        else if (speedLvl == 5)
        {
            CostText.text = "Maxed out"; 
        }

    }
    public void HandleInputData(int val)
    {
        switch (val)
        {
            case 0:
                VariableTransfer.skinnum = val;
                skinChanger.skinNum = val;
                break;
            case 1:
                BuySkin(val);
                break;
            case 2:
                BuySkin(val);
                break;
            case 3:
                BuySkin(val);
                break;
            case 4:
                BuySkin(val);
                break;
            case 5:
                BuySkin(val);
                break;
        }
        coinsText.text = coins.ToString();
    }
    public void BuySkin(int val)
    {
        if (boughtSkin[val] == false)
        {
            if (coins >= skinCost[val])
            {
                boughtSkin[val] = true;
                coins -= skinCost[val];
                VariableTransfer.skinnum = val;
                skinChanger.skinNum = val;
                dropDown.UpdateList();
            }
            else
            {
                StartCoroutine(Duration(noCoins, "Not enough Coins", ""));
                
            }
        }
        else
        {
            VariableTransfer.skinnum = val;
            skinChanger.skinNum = val;
        }
    }
    public IEnumerator Duration(TextMeshProUGUI text, string str, string strEnd)
    {
        text.text = str;
        yield return new WaitForSeconds(3);
        text.text = strEnd;

    }
    public void OnClose()
    {
        SaveSystem.SavePlayer(VariableTransfer.speed);
        SaveSystem.SaveData(VariableTransfer.skinnum, "skin");
        SaveSystem.SaveData(coins,"coins");
        SaveSystem.SaveShop(speedLvl, speedCost,boughtSkin);
    }

    void costCalculator(float cost, int lvl)
    {
        cost *= lvl;
    }
}
