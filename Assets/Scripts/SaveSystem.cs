using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void CompareDistance(int currentDistance, int loadedDistance)
    {
        if(currentDistance > loadedDistance)
        {
            string savename = "distance";
            SaveData(currentDistance,savename);
        }
    }

    public static void AddCoins(int newCoins, int loadedCoins)
    {
        loadedCoins += newCoins;
        string savename = "coins";
        SaveData(loadedCoins, savename);
    }

    public static void SavePlayer()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Save.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        stream.Close();
    }

    public static void SaveData(int value, string saveType)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/"+ saveType + ".txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream,value);
        stream.Close();
    }

    public static int LoadData(string filename)
    {
        string path = Application.persistentDataPath + "/"+ filename +".txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            int distance = (int)formatter.Deserialize(stream);

            stream.Close();
            return distance;
        }
        else
        {
            Debug.LogError("No save file in " + path);
            return 0;
        }
    }
}
