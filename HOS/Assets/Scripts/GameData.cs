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

        public Dictionary<string,GameObject> MasterGameInventory;
        public Dictionary<string,GameObject> PlayerInventory;
        
        public List<GameObject> AudioLibrary;
        public Dictionary<string,bool> LevelPuzzleCompleted;
}
