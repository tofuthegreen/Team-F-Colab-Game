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
            SaveDistance(currentDistance);
        }
    }

    public static void AddCoins(int newCoins, int loadedCoins)
    {
        loadedCoins += newCoins;
        SaveCoins(loadedCoins);
    }

    public static void SaveDistance(int distance)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Save.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream,distance);
        stream.Close();
    }
    public static void SaveCoins(int coins)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SaveCoins.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, coins);
        stream.Close();
    }

    public static int LoadDistance()
    {
        string path = Application.persistentDataPath + "/Save.txt";
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
    public static int LoadCoins()//Shouldnt duplicate save and loads find way to make them two functions
    {
        string path = Application.persistentDataPath + "/SaveCoins.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            int coins = (int)formatter.Deserialize(stream);

            stream.Close();
            return coins;
        }
        else
        {
            Debug.LogError("No save file in " + path);
            return 0;
        }
    }
}
