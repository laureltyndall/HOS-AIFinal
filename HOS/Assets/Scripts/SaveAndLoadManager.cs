using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using HOS;

public class SaveAndLoadManager : MonoBehaviour 
{
    string JsonFile = "data.json";
    GameData DataCollection = null;
    GameManager Manager;
	// Use this for initialization
	void Start () 
    {
        Manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
       //SaveJsonFile();
       LoadJsonFile();
        Manager.CurrentGameCheckpoint = DataCollection.CurrentGameCheckpoint;
	}
	
    public void LoadJsonFile()
    {
     // Path.Combine combines strings into a file path
        // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
        string filePath = Application.dataPath + JsonFile;

        if(File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath); 
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            DataCollection = JsonUtility.FromJson<GameData>(dataAsJson);
        }
        else
        {
            Debug.LogError("Cannot load game data! Creating New Dataset");
            DataCollection = new GameData();
        }

    }

    public void SaveJsonFile()
    {
        DataCollection = new GameData();
        string dataAsJson = JsonUtility.ToJson (DataCollection);
        string filePath = Application.dataPath + JsonFile;
        File.WriteAllText (filePath, dataAsJson);
    }
}
