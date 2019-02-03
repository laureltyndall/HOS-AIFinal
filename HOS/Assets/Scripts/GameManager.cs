using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HOS
{
    public class GameManager : MonoBehaviour 
    {
        public GameState CurrentGameState;
        public ProgressionCheckpoint CurrentGameCheckpoint;
        public SavePoint CurrentGameSavepoint;

        public List<GameObject> MasterGameInventory;
        public List<GameObject> PlayerInventory;
        
        public List<GameObject> AudioLibrary;
        public List<bool> LevelPuzzleCompleted;
    }
}