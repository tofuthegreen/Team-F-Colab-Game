using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class ShowDistance : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI coinsText;

    void Start()
    {
        distanceText.text = SaveSystem.LoadData("distance" + "km").ToString();
        coinsText.text = SaveSystem.LoadData("coins").ToString();
    }
}
