using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveGame(int distance)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Save.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream,distance);
        stream.Close();
    }

}
