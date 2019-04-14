using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        public bool LRFromHall = false;
        public bool LRFromGame = false;
        public bool CenterFromMaze = false;
        public bool CenterFromGame = false;
        public bool HallfromOutside = false;
        public bool HallFromRoom = false;

        public GameObject GameOverScreen;
        public bool GameOver = false;
        private string CurrentSceneName = "";
        public Player PlayerCopy = new Player();
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

            if(SceneManager.GetActiveScene().name != CurrentSceneName && CurrentGameState != GameState.None)
            {
                CurrentGameState = GameState.None;
               CurrentSceneName = SceneManager.GetActiveScene().name;
            }

            if (SceneManager.GetActiveScene().name == "Intro" && CurrentGameState == GameState.None)
            {
                GameObject alex = GameObject.FindGameObjectWithTag("PlayerAlex");
                GameObject anne = GameObject.FindGameObjectWithTag("PlayerAnne");
                CurrentGameState = GameState.GameStarted;
                MasterInventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
                Button B = GameObject.FindGameObjectWithTag("InventoryActiveButton").GetComponent<Button>();
                B.onClick.AddListener(MasterInventory.ActivateMenu);
                if (NewCharacter == Character.Anne)
                {
                    alex.SetActive(false);
                    CurrentPlayer = anne.GetComponent<Player>();
                    CurrentPlayer.PlayerCharacter = Character.Anne;
                    CurrentPlayer.PlayerName = "Anne";
                    CurrentPlayer.PlayerHealth = 10;
                }
                else if (NewCharacter == Character.Alex)
                {
                    anne.SetActive(false);
                    CurrentPlayer = alex.GetComponent<Player>();
                    CurrentPlayer.PlayerCharacter = Character.Alex;
                    CurrentPlayer.PlayerName = "Alex";
                    CurrentPlayer.PlayerHealth = 10;
                }
                CurrentSceneName = SceneManager.GetActiveScene().name;
            }
            else if (SceneManager.GetActiveScene().name == "Gate Scene" && CurrentGameState == GameState.None)
            {
                // TESTING INDIVIDUAL SCENES ONLY
                CurrentGameState = GameState.GameStarted;
                CurrentPlayer.transform.position = new Vector3(-949.59f, -365.04f, 649.05f);
                CurrentPlayer.transform.Rotate(0f, 180f, 0f);
                //CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                //Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                CurrentSceneName = SceneManager.GetActiveScene().name;
                Button B = GameObject.FindGameObjectWithTag("InventoryActiveButton").GetComponent<Button>();
                B.onClick.AddListener(MasterInventory.ActivateMenu);
                MasterInventory.FindButtons();
                CurrentSceneName = SceneManager.GetActiveScene().name;
            }
            else if(SceneManager.GetActiveScene().name == "HouseGrounds" && CurrentGameState == GameState.None)
            {
                // TESTING INDIVIDUAL SCENES ONLY
                CurrentGameState = GameState.GameStarted;
                CurrentPlayer.transform.position = new Vector3(2.59f, 3.26f, 78.97f);
                CurrentPlayer.transform.Rotate(0f, 180f, 0f);
                //CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                //Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                CurrentSceneName = SceneManager.GetActiveScene().name;
                Button B = GameObject.FindGameObjectWithTag("InventoryActiveButton").GetComponent<Button>();
                B.onClick.AddListener(MasterInventory.ActivateMenu);
                MasterInventory.FindButtons();
                CurrentSceneName = SceneManager.GetActiveScene().name;
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
                CurrentGameState = GameState.GameStarted;
                CurrentPlayer.transform.position = new Vector3(8.39f, -0.3f, 146.96f);
                CurrentPlayer.transform.Rotate(0f, 180f, 0f);
                //CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                //Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                CurrentSceneName = SceneManager.GetActiveScene().name;
                Button B = GameObject.FindGameObjectWithTag("InventoryActiveButton").GetComponent<Button>();
                B.onClick.AddListener(MasterInventory.ActivateMenu);
                MasterInventory.FindButtons();
                CurrentSceneName = SceneManager.GetActiveScene().name;
                // Test from grounds
                HouseFromGrounds = true;
                HousefromInside = false;

                // Test from house
                //HouseFromGrounds = false;
                //HousefromInside = true;
            }
            else if (SceneManager.GetActiveScene().name == "HouseHallWay" && CurrentGameState == GameState.None)
            {
                CurrentGameState = GameState.GameStarted;
                CurrentPlayer.transform.position = new Vector3(4.64f, 1.02f, -10.95f);
                CurrentPlayer.transform.Rotate(0f, 90f, 0f);
                //CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                //Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                CurrentSceneName = SceneManager.GetActiveScene().name;
                Button B = GameObject.FindGameObjectWithTag("InventoryActiveButton").GetComponent<Button>();
                B.onClick.AddListener(MasterInventory.ActivateMenu);
                MasterInventory.FindButtons();
                CurrentSceneName = SceneManager.GetActiveScene().name;
                // Test from grounds first time entering house
                HallfromOutside = true;
                HallFromRoom = false;

                // Test from house
                //HallfromOutside = false;
                //HallFromRoom = true;

                // Test from grounds second time entering house
                //HallfromOutside = true;
                //HallFromRoom = false;
                //InteriorGhostSeen = true;
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

                // Test from Hall
                KitchenFromHall = true;
                KitchenFromGame = false;

                // Test from Mouse MiniGame
                //KitchenFromHall = false;
                //KitchenFromGame = true;
            }
            else if (SceneManager.GetActiveScene().name == "Living Room" && CurrentGameState == GameState.None)
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

                //Test from hall
                LRFromHall = true;
                LRFromGame = false;
                //Test from mini game
                //LRFromHall = false;
                //LRFromGame = true;
            }
            else if (SceneManager.GetActiveScene().name == "LivingRoomPuzzleGame" && CurrentGameState == GameState.None)
            {
                // TESTING INDIVIDUAL SCENES ONLY
                GameObject alex = GameObject.FindGameObjectWithTag("PlayerAlex");
                GameObject anne = GameObject.FindGameObjectWithTag("PlayerAnne");
           //     MasterInventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
                alex.SetActive(false);
                CurrentGameState = GameState.GameStarted;
                CurrentPlayer = anne.GetComponent<Player>();
                CurrentPlayer.PlayerCharacter = Character.Anne;
                CurrentPlayer.PlayerHealth = 10;
                //        MasterInventory.AddInventoryItem(InventoryItem.Basket);
                //      MasterInventory.AddInventoryItem(InventoryItem.Flashlight);

                LRFromHall = false;
                LRFromGame = true;
            }
            else if (SceneManager.GetActiveScene().name == "HedgeMazeCenter" && CurrentGameState == GameState.None)
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

                //Test from Maze
                CenterFromMaze = true;
                CenterFromGame = false;
                //Test from mini game
                //CenterFromMaze = false;
                //CenterFromGame = true;
            }
            else if (SceneManager.GetActiveScene().name == "FountainMiniGame" && CurrentGameState == GameState.None)
            {
                // TESTING INDIVIDUAL SCENES ONLY
                GameObject alex = GameObject.FindGameObjectWithTag("PlayerAlex");
                GameObject anne = GameObject.FindGameObjectWithTag("PlayerAnne");
                //     MasterInventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
                alex.SetActive(false);
                CurrentGameState = GameState.GameStarted;
                CurrentPlayer = anne.GetComponent<Player>();
                CurrentPlayer.PlayerCharacter = Character.Anne;
                CurrentPlayer.PlayerHealth = 10;
                //        MasterInventory.AddInventoryItem(InventoryItem.Basket);
                //      MasterInventory.AddInventoryItem(InventoryItem.Flashlight);

                CenterFromMaze = false;
                CenterFromGame = true;
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