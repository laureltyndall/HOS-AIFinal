using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HOS
{
    public class GateSceneGateController : MonoBehaviour
    {

        public bool Clickable = true;
        public Texture2D NewCursor;
        public PlayerCameraController MovementScript;
        private MenuManager Controller;
        public GameManager ManagerScript;
        public Text TextArea;
        public bool ManagerFound = false;
        public int ClickCounter = 0;
        private bool GateComment = false;
        public GameObject Snake;
        public GameObject GameOverPanel;
        public GameObject[] G= new GameObject[2];
        public AudioSource Footstep;
        public AudioSource GateLocked;
        public AudioSource GateOpen;
        public AudioSource SnakeHiss;
        public SnakeMiniGameController SnakeScript;

        // Use this for initialization
        void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
            MovementScript = go.GetComponent<PlayerCameraController>();
            G = GameObject.FindGameObjectsWithTag("SnakeMinigame");
            foreach (GameObject g in G)
            {
                g.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (!ManagerFound)
            {
                GameObject gm = GameObject.FindGameObjectWithTag("GameController");
                ManagerScript = gm.gameObject.GetComponent<GameManager>();
                Controller = gm.gameObject.GetComponent<MenuManager>();

                if (ManagerScript != null)
                {
                    ManagerFound = true;
                }
            }

            if(MovementScript.CurrentWaypoint == MovementScript.WaypointList[2])
            {
                if(!GateComment)
                {
                    TextArea.text = "Wow. That is some gate.";
                    GateComment = true;
                }
            }

            if(ClickCounter == 1 && MovementScript.CurrentWaypoint == MovementScript.WaypointList[2])
            {
                TextArea.text = "I need to find some way to get that snake away from the gate latch.";
            }

            if (ManagerScript.SnakeBeaten)
            {
                foreach (GameObject g in G)
                {
                    g.SetActive(false);
                }

                //  MovementScript.MainCamera.transform.Rotate(15, 0, 0);
                MovementScript.gameObject.SetActive(true);
                Clickable = true;

                Snake.SetActive(false);
                TextArea.text = "I should be able to get through the gate safely now.";
            }
            }

        void OnMouseOver()
        {
            if (Clickable)
            {
                //If your mouse hovers over the GameObject with the script attached, output this message
                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[2])
                {
                    Cursor.SetCursor(NewCursor, Vector2.zero, CursorMode.Auto);

                }
            }
        }

        void OnMouseExit()
        {
            if (Clickable)
            {
                //The mouse is no longer hovering over the GameObject so output this message each frame
                //      Debug.Log("Mouse is no longer on " + this.name);
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
        }

        private void OnMouseDown()
        {
            if (Clickable)
            {
                Debug.Log(this.name + " has been clicked");
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[2])
                {
                    if (ManagerScript.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.Trowel))
                    {
                        if (ManagerScript.SnakeBeaten)
                        {
                            GateOpen.Play();
                            Camera.main.transform.rotation = Quaternion.Euler(0f, 180, 0f);

                            ManagerScript.GroundsFromGate = true;
                            ManagerScript.GroundsFromHouse = false;
                            ManagerScript.HouseFromGrounds = false;
                            ManagerScript.HousefromInside = false;
                            ManagerScript.KitchenFromHall = false;
                            ManagerScript.KitchenFromGame = false;
                            ManagerScript.LRFromHall = false;
                            ManagerScript.LRFromGame = false;
                            ManagerScript.LRFromUnderground = false;
                            ManagerScript.CenterFromMaze = false;
                            ManagerScript.CenterFromGame = false;
                            ManagerScript.HallfromOutside = false;
                            ManagerScript.HallFromRoom = false;
                            ManagerScript.LoadScene("HouseGrounds");
                        }
                        else
                        {
                            foreach (GameObject g in G)
                            {
                                g.SetActive(true);
                            }
                            Clickable = false;
                            MovementScript.MainCamera.transform.Rotate(15,0,0);
                            MovementScript.gameObject.SetActive(false);
                            SnakeHiss.Play();
                        }
                    }
                    // else, dialogue that you don't need to leave right now
                    else
                    {
                        if(ClickCounter < 1)
                        {
                            MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[3].transform.position;
                            MovementScript.CurrentWaypoint = MovementScript.WaypointList[3];
                            //     MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 20f, 0f);
                            Camera.main.transform.rotation = Quaternion.Euler(41.62f, 180f, 0f);

                            MovementScript.CanUturn = false;
                            MovementScript.CanOrbit = false;
                            MovementScript.CanLeftTurn = false;
                            MovementScript.CanRightTurn = false;
                            MovementScript.CanForward = false;
                            MovementScript.CanBackup = true;
                            GateLocked.Play();

                            Snake.SetActive(true);
                            TextArea.text = "Whoah! There's a snake!";
                        }
                        else if(ClickCounter < 5 && ClickCounter > 0)
                        {
                            TextArea.text = "Ouch!";
                        }
                        else if (ClickCounter >= 5)
                        {
                            TextArea.text = "Oooh. I don't feel so good.";
                            Controller.ShowGameOver(GameOverPanel);
                            ManagerScript.KilledBySnake = true;

                            ClickCounter = 0;
                        }
                    }

                    ClickCounter++;
                    SnakeHiss.Play();
                }
            }
        }
    }
}