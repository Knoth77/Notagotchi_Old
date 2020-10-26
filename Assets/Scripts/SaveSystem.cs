using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveSystem {

    private static string _filePath = "/player.milk";

    public static void SaveGame(Mood mood)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + _filePath;
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(mood);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadGame()
    {
        string path = Application.persistentDataPath + _filePath;

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }

    }
}
