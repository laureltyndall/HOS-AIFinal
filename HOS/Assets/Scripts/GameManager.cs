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
        public Player CurrentPlayer;
        public Dictionary<string,GameObject> MasterGameInventory;
        public List<GameObject> AudioLibrary;
        public Dictionary<string,bool> LevelPuzzleCompleted;

        void Start()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        public void SelectPlayerCharacter(int PlayerChoice)
        {
            if (PlayerChoice == 1)
            {
                // Player is Alex Russell
                CurrentPlayer.PlayerCharacter = Character.Alex;
            }
            else if (PlayerChoice == 2)
            {
                // Player is Anne Russell
                CurrentPlayer.PlayerCharacter = Character.Anne;
            }
        }
    }
}