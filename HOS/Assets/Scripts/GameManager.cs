﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class GameManager : MonoBehaviour 
    {
        public GameState CurrentGameState;
        public ProgressionCheckpoint CurrentGameCheckpoint;
        public SavePoint CurrentGameSavepoint;
        public Player CurrentPlayer = new Player();
        public Character NewCharacter;
        public List<GameObject> AudioLibrary = new List<GameObject>();
        public Dictionary<string,bool> LevelPuzzleCompleted = new Dictionary<string, bool>();
        public bool PuzzleComplete;
        public Inventory MasterInventory = new Inventory();

        public bool KilledBySnake = false;
        public bool SnakeBeaten = false;

        void Start()
        {
            DontDestroyOnLoad(this.gameObject);
       //     CurrentPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        private void Update()
        {
            if (SceneManager.GetActiveScene().name == "Intro" && CurrentGameState == GameState.None)
            {
                GameObject alex = GameObject.FindGameObjectWithTag("PlayerAlex");
                GameObject anne = GameObject.FindGameObjectWithTag("PlayerAnne");

                CurrentGameState = GameState.GameStarted;

                if (NewCharacter == Character.Anne)
                {
                    alex.SetActive(false);
                    CurrentPlayer = anne.GetComponent<Player>();
                    CurrentPlayer.PlayerCharacter = Character.Anne;
                    CurrentPlayer.PlayerHealth = 10;
                }
                else if (NewCharacter == Character.Alex)
                {
                    anne.SetActive(false);
                    CurrentPlayer = alex.GetComponent<Player>();
                    CurrentPlayer.PlayerCharacter = Character.Alex;
                    CurrentPlayer.PlayerHealth = 10;
                }
            }
            else if (SceneManager.GetActiveScene().name == "Gate Scene")
            {

                CurrentPlayer.PlayerCharacter = Character.Anne;
            }

            if(KilledBySnake)
            {

            }
        }

        public void SelectPlayerCharacter(int PlayerChoice)
        {
            if (PlayerChoice == 1)
            {
                if (CurrentPlayer != null)
                {
                    // Player is Alex Russell
                    CurrentPlayer.PlayerCharacter = Character.Alex;
                }
                else
                {
                    NewCharacter = Character.Alex;
                }
            }
            else if (PlayerChoice == 2)
            {
                if (CurrentPlayer != null)
                {
                    // Player is Anne Russell
                    CurrentPlayer.PlayerCharacter = Character.Anne;
                }
                else
                {
                    NewCharacter = Character.Anne;
                }
            }

            CurrentGameState = GameState.None;
        }

        public void LoadScene(string SceneName)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}