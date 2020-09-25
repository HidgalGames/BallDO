using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public GlobalVariables globalVariables;

    private static SaveSystem instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        LoadData();
    }

    public void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.bds";

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(globalVariables);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/data.bds";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            globalVariables.LoadVariables(data);
        }
    }
    
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveData();
        }
    }    

    private void OnApplicationQuit()
    {
        SaveData();
    }
}
