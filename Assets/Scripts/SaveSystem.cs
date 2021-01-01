using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem 
{ 
    public static void  SaveNeededData(PlayerStats playerStats)
    {
        BinaryFormatter binary = new BinaryFormatter();
        string path = Application.dataPath + "/EnumeratorsFoxWannaSpamThisBox.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(playerStats);
        binary.Serialize(stream, data);
        stream.Close();
    }
    public static SaveData LoadData()
    {
        string path = Application.dataPath + "/EnumeratorsFoxWannaSpamThisBox.data";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
          

            SaveData saveData = binaryFormatter.Deserialize(stream) as SaveData;

            stream.Close();

            return saveData;
        }
        else
        {
            Debug.LogError("Not Found" + path);
            return null;
        }
    }
}
