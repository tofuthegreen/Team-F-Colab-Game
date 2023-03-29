using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI highscore, currentdistance, bestdistance;
    // Start is called before the first frame update
    void Start()
    {
        if (SaveSystem.highscore == true)
        {
            highscore.gameObject.SetActive(true);
            //currentdistance.text = "Your distance: " + SaveSystem.LoadData("distance") + "km";
        }
        else
        {
            highscore.gameObject.SetActive(false);
            //currentdistance.text = "Your distance: "+ VariableTransfer.distance.ToString() + "km";
        }
    }
}
