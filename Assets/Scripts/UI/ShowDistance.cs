using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ShowDistance : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI coinsText;
    
    public void Update()
    {
        distanceText.text = SaveSystem.LoadDistance().ToString();
        coinsText.text = SaveSystem.LoadCoins().ToString();
    }
}
