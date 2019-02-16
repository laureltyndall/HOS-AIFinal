using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HOS;

[System.Serializable]
public class GameData
{
    public GameState CurrentGameState;
    public ProgressionCheckpoint CurrentGameCheckpoint;
    public SavePoint CurrentGameSavepoint;
    public Player CurrentPlayer;
    public List<GameObject> AudioLibrary = new List<GameObject>();
    public Dictionary<string,bool> LevelPuzzleCompleted = new Dictionary<string, bool>();
}
