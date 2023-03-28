using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI coins,distance;
    public MovePlayer player;

    // Update is called once per frame
    void Update()
    {
        coins.text = player.displayCoins.ToString();
        distance.text = player.distance.ToString() + "km";
    }
}
