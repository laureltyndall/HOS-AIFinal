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
        public GameManager ManagerScript;
        public Text TextArea;
        public bool ManagerFound = false;
        public int ClickCounter = 0;
        private bool GateComment = false;
        public GameObject Snake;

        // Use this for initialization
        void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
            MovementScript = go.GetComponent<PlayerCameraController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!ManagerFound)
            {
                GameObject gm = GameObject.FindGameObjectWithTag("GameController");
                ManagerScript = gm.gameObject.GetComponent<GameManager>();

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
                    // If the player has the letter in inventory, leave the house
                    if (ManagerScript.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.Trowel))
                    {
                        if (ManagerScript.SnakeBeaten)
                        {
                            ManagerScript.LoadScene("HouseGrounds");
                        }
                        else
                        {
                            ManagerScript.LoadScene("SnakeGameTest");
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

                            Snake.SetActive(true);
                            TextArea.text = "Whoah! There's a snake!";
                        }
                        else if(ClickCounter == 2)
                        {
                            TextArea.text = "Ouch!";
                        }
                        else if (ClickCounter >= 5)
                        {
                            TextArea.text = "Oooh. I don't feel so good.";
                            ManagerScript.KilledBySnake = true;
                        }
                    }

                    ClickCounter++;

                }
            }
        }
    }
}