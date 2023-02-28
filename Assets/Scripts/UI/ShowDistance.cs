using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;


public class ShowDistance : MonoBehaviour
{
    public static int distance;
    public TextMeshProUGUI distanceText;
    public static void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/Save.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            distance = (int)formatter.Deserialize(stream);
            
           stream.Close();

        }
        else
        {
            Debug.LogError("No save file in " + path);
        }
    }
    public void Start()
    {
        LoadPlayer();
        distanceText.text = distance.ToString();
    }
}
