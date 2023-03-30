using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static bool highscore;

    public static void CompareDistance(int currentDistance, int loadedDistance)
    {
        if (currentDistance > loadedDistance)
        {
            string savename = "distance";
            SaveData(currentDistance, savename);
            highscore = true;
        }
        else
        {
            highscore = false;
        }
    }

    public static void AddCoins(int newCoins, int loadedCoins)
    {
        loadedCoins += newCoins;
        string savename = "coins";
        SaveData(loadedCoins, savename);
    }

    public static void SavePlayer(float speed)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, speed);
        stream.Close();
    }
    public static void LoadPlayer(MovePlayer player)
    {
        string path = Application.persistentDataPath + "/player.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            player.speed = (float)formatter.Deserialize(stream);
            stream.Close();
        }
        else
        {
            Debug.LogError("No save file in " + path);
        }
    }
    public static void SaveData(int value, string saveType)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + saveType + ".txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, value);
        stream.Close();
    }

    public static int LoadData(string filename)
    {
        string path = Application.persistentDataPath + "/" + filename + ".txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            int data = (int)formatter.Deserialize(stream);

            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("No save file in " + path);
            return 0;
        }
    }
    public static void SaveAudio(float main,float sfx,float music)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/audio.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, main);
        formatter.Serialize(stream, sfx);
        formatter.Serialize(stream, music);
        stream.Close();
        Debug.Log("Saved audio main " + main + " sfx " + sfx + " music " + music);
    }

    public static void LoadAudio(AudioManager audio)
    {
        string path = Application.persistentDataPath + "/audio.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            audio.mainVolume = (float)formatter.Deserialize(stream);
            audio.sfxVolume = (float)formatter.Deserialize(stream);
            audio.musicVolume = (float)formatter.Deserialize(stream);

            stream.Close();

        }
        else
        {
            Debug.LogError("No save file in " + path);
        }
    }
    public static void SaveShop(int speedLvl, int speedCost)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/shop.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, speedLvl);
        formatter.Serialize(stream, speedCost);
        stream.Close();
    }
    public static void LoadShop(Upgrades shop)
    {
        string path = Application.persistentDataPath + "/shop.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            shop.speedLvl = (int)formatter.Deserialize(stream);
            shop.speedCost = (int)formatter.Deserialize(stream);

            stream.Close();
        }
        else
        {
            Debug.LogError("No save file in " + path);
        }
    }
}
