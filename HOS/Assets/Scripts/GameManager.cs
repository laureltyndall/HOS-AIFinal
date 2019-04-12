using System.Collections;
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
        public bool ExteriorGhostSeen = false;
        public bool InteriorGhostSeen = false;

        public bool GroundsFromGate = false;
        public bool GroundsFromHouse = false;
        public bool HouseFromGrounds = false;
        public bool HousefromInside = false;
        public bool KitchenFromHall = false;
        public bool KitchenFromGame = false;

        public GameObject GameOverScreen;
        public bool GameOver = false;

        void Start()
        {
            if (SceneManager.GetActiveScene().name == "Menu")
            {
                DontDestroyOnLoad(this.gameObject);
            }

            Time.timeScale = 1;
        }

        private void Update()
        {
            if (SceneManager.GetActiveScene().name == "Intro" && CurrentGameState == GameState.None)
            {
                GameObject alex = GameObject.FindGameObjectWithTag("PlayerAlex");
                GameObject anne = GameObject.FindGameObjectWithTag("PlayerAnne");
                CurrentGameState = GameState.GameStarted;
                MasterInventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
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
            else if (SceneManager.GetActiveScene().name == "Gate Scene" && CurrentGameState == GameState.None)
            {
                // TESTING INDIVIDUAL SCENES ONLY
                GameObject alex = GameObject.FindGameObjectWithTag("PlayerAlex");
                GameObject anne = GameObject.FindGameObjectWithTag("PlayerAnne");
                MasterInventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
                alex.SetActive(false);
                CurrentGameState = GameState.GameStarted;
                CurrentPlayer = anne.GetComponent<Player>();
                CurrentPlayer.PlayerCharacter = Character.Anne;
                CurrentPlayer.PlayerHealth = 10;
                MasterInventory.AddInventoryItem(InventoryItem.Basket);
                MasterInventory.AddInventoryItem(InventoryItem.Flashlight);
            }
            else if(SceneManager.GetActiveScene().name == "HouseGrounds" && CurrentGameState == GameState.None)
            {
                // TESTING INDIVIDUAL SCENES ONLY
                GameObject alex = GameObject.FindGameObjectWithTag("PlayerAlex");
                GameObject anne = GameObject.FindGameObjectWithTag("PlayerAnne");
                alex.SetActive(false);
                CurrentGameState = GameState.GameStarted;
                CurrentPlayer = anne.GetComponent<Player>();
                CurrentPlayer.PlayerCharacter = Character.Anne;
                CurrentPlayer.PlayerHealth = 10;

                // Test from gate
                GroundsFromGate = true;
                GroundsFromHouse = false;

                // Test from house
                //GroundsFromGate = false;
                //GroundsFromHouse = true;
            }
            else if (SceneManager.GetActiveScene().name == "HouseExterior" && CurrentGameState == GameState.None)
            {
                // TESTING INDIVIDUAL SCENES ONLY
                GameObject alex = GameObject.FindGameObjectWithTag("PlayerAlex");
                GameObject anne = GameObject.FindGameObjectWithTag("PlayerAnne");
                MasterInventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
                alex.SetActive(false);
                CurrentGameState = GameState.GameStarted;
                CurrentPlayer = anne.GetComponent<Player>();
                CurrentPlayer.PlayerCharacter = Character.Anne;
                CurrentPlayer.PlayerHealth = 10;
                MasterInventory.AddInventoryItem(InventoryItem.Basket);
                MasterInventory.AddInventoryItem(InventoryItem.Flashlight);

                // Test from grounds
                HouseFromGrounds = true;
                HousefromInside = false;

                // Test from house
                //HouseFromGrounds = false;
                //HousefromInside = true;
            }
            else if (SceneManager.GetActiveScene().name == "Kitchen" && CurrentGameState == GameState.None)
            {
                // TESTING INDIVIDUAL SCENES ONLY
                GameObject alex = GameObject.FindGameObjectWithTag("PlayerAlex");
                GameObject anne = GameObject.FindGameObjectWithTag("PlayerAnne");
                MasterInventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
                alex.SetActive(false);
                CurrentGameState = GameState.GameStarted;
                CurrentPlayer = anne.GetComponent<Player>();
                CurrentPlayer.PlayerCharacter = Character.Anne;
                CurrentPlayer.PlayerHealth = 10;
                MasterInventory.AddInventoryItem(InventoryItem.Basket);
                MasterInventory.AddInventoryItem(InventoryItem.Flashlight);

                // Test from Hall
                KitchenFromHall = true;
                KitchenFromGame = false;

                // Test from Mouse MiniGame
                //KitchenFromHall = false;
                //KitchenFromGame = true;
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

    public void ToggleInventoryPanel(GameObject panel)
    {
        // If the pause menu is on, turn it off. If it is off, turn it on
        panel.SetActive(!panel.activeSelf);
        MasterInventory.ActivateMenu();
    }
        public void LoadScene(string SceneName)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}