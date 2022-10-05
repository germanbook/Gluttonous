using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    //Saves the data into a file
    //Serializes it into binary so users cant change values manually
   public static void SaveData (PlayerGladiatorsStore data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/GameData";

        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData newdata = new SaveData(data);

        formatter.Serialize(stream, newdata);
        stream.Close();
    }
    //Loads data 
    public static SaveData LoadData()
    {
        
        string path = Application.persistentDataPath + "/GameData";
        if(File.Exists(path))
        {

            
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
}
