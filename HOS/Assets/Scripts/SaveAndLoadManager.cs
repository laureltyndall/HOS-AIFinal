using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using HOS;

public class SaveAndLoadManager : MonoBehaviour 
{
    string JsonFile = "data.json"; // Name of the data file.
    GameData DataCollection = null; //Holder for save and load file data.
    GameManager Manager; // Reference to the game manager.

	// Use this for initialization
	void Start () 
    {
        //Find the manager in the current scene and set it.
        Manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	
    //Loads the JSON file into the game.
    public void LoadJsonFile()
    {
        //Create the file path name to the location of the data file.
        string filePath = Application.dataPath + JsonFile;

        //If the file is available.
        if(File.Exists(filePath))
        {
            DataCollection = new GameData();
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath); 

            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            DataCollection = JsonUtility.FromJson<GameData>(dataAsJson);
        }
        else
        {
            //If there is no existing file create a blank data set object.
            Debug.LogError("Cannot load game data! Creating New Dataset");
            DataCollection = new GameData();
        }

        //Each piece of data that needs to be loaded must be converted from the DataCollection
        Manager.CurrentGameState = DataCollection.CurrentGameState;
        Manager.CurrentGameCheckpoint = DataCollection.CurrentGameCheckpoint;
        Manager.CurrentGameSavepoint = DataCollection.CurrentGameSavepoint;
        Manager.CurrentPlayer = DataCollection.CurrentPlayer;
        Manager.LevelPuzzleCompleted = DataCollection.LevelPuzzleCompleted;
    }
    
    //Save the game data into a JSON file.
    public void SaveJsonFile()
    {
        //Reset data collection to ensure valid save.
        DataCollection = new GameData();

        //Each piece of data that needs to be saved must be converted from the Manager.
        DataCollection.CurrentGameState = Manager.CurrentGameState;
        DataCollection.CurrentGameCheckpoint = Manager.CurrentGameCheckpoint;
        DataCollection.CurrentGameSavepoint = Manager.CurrentGameSavepoint;
        DataCollection.CurrentPlayer = Manager.CurrentPlayer;
        DataCollection.LevelPuzzleCompleted = Manager.LevelPuzzleCompleted;

        //Serialize data to be encoded by the JSON file.
        string dataAsJson = JsonUtility.ToJson (DataCollection);
        //Create the file path name to the location of the data file.
        string filePath = Application.dataPath + JsonFile;
        //Write data to the file.
        File.WriteAllText (filePath, dataAsJson);
    }
}
