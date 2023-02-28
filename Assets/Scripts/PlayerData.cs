using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public float distance;


    public PlayerData(MovePlayer player)
    {
        distance = player.distance;
    }
}
