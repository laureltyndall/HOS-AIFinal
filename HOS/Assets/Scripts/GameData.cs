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
        public Dictionary<string,GameObject> MasterGameInventory;
        public List<GameObject> AudioLibrary;
        public Dictionary<string,bool> LevelPuzzleCompleted;
}
