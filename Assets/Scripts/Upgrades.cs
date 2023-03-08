using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    int speedLvl = 1;
    int speedCost = 5;

    public void SpeedUpgrade()
    {



        if (VariableTransfer.coins >= speedCost && speedLvl != 5)
        {
            VariableTransfer.speed += 5;
            VariableTransfer.coins -= speedCost;
            speedLvl++;
            speedCost += 10;
            
        }
        else if (VariableTransfer.coins < speedCost)
        {
            Debug.Log("Cant afford");
        }
        else if (speedLvl == 5)
        {
            Debug.Log("Maxed Out");
        }

    }

    void costCalculator(float cost, int lvl)
    {
        cost *= lvl;
    }
}
