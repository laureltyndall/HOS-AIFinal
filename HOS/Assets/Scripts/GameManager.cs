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
        public Player CurrentPlayer = new Player();
        public List<GameObject> AudioLibrary = new List<GameObject>();
        public Dictionary<string,bool> LevelPuzzleCompleted = new Dictionary<string, bool>();

        void Start()
        {
            DontDestroyOnLoad(this.gameObject);
            CurrentPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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