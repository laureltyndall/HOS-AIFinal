using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HOS
{
    public class LeavingHouseController : MonoBehaviour
    {
        public bool Clickable = false;
        public Texture2D NewCursor;
        public PlayerCameraController MovementScript;
        public MeshCollider MyCollider;
        public Text TextArea;
        public int ClickCounter = 0;
        public GameObject GOScreen;
        public MenuManager Controller;
        public GameManager ManagerScript;
        public bool ManagerFound = false;
        public AudioSource Footstep;

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
            else
            {
                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[2])
                {
                    // If we are next to the house door
                    Clickable = true;
                    MyCollider.enabled = true;
                }
                else
                {
                    Clickable = false;
                    MyCollider.enabled = false;
                }
            }
        }

        void OnMouseOver()
        {
            if (Clickable)
            {
                // If Inventory does not have flashlight
                Cursor.SetCursor(MovementScript.CursorList[2], Vector2.zero, CursorMode.Auto);
                // else
                // Cursor.SetCursor(MovementScript.CursorList[3], Vector2.zero, CursorMode.Auto);
            }
        }

        void OnMouseExit()
        {
            //The mouse is no longer hovering over the GameObject so output this message each frame
            //      Debug.Log("Mouse is no longer on " + this.name);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }

        private void OnMouseDown()
        {
            if (Clickable)
            {
                ClickCounter++;
                Debug.Log(this.name + " has been clicked");
                Clickable = false;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

                if (ManagerScript.InteriorGhostSeen)
                {
                    // If inventory does not have flashlight
                    if (!ManagerScript.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.Flashlight))
                    {
                        if (ClickCounter == 1)
                        {
                            TextArea.text = ("I need to find a flashlight.");
                        }
                        else if (ClickCounter == 2)
                        {
                            TextArea.text = ("If I keep wandering around in the dark like this, I'm going to get lost.");
                        }
                        else if (ClickCounter == 3)
                        {
                            TextArea.text = ("I shouldn't keep going without a flashlight.");
                        }
                        else if (ClickCounter == 4)
                        {
                            TextArea.text = ("Ouch!");

                            // Game Over
                            Controller.ShowGameOver(GOScreen);
                        }
                    }
                    else
                    {
                        TextArea.text = ("Now I should be able to find the maze with no problem. I hope " + MovementScript.SiblingName + " is there.");

                        // Move to location 0
                        MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[0].transform.position;
                        MovementScript.CurrentWaypoint = MovementScript.WaypointList[0];
                        //     MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 20f, 0f);
                      //  Camera.main.transform.rotation = Quaternion.Euler(41.62f, 180f, 0f);

                        MovementScript.CanUturn = false;
                        MovementScript.CanOrbit = false;
                        MovementScript.CanLeftTurn = false;
                        MovementScript.CanRightTurn = false;
                        MovementScript.CanForward = false;
                        MovementScript.CanBackup = false;
                    }
                }
                else
                {
                    TextArea.text = "I need to get inside now!";
                }

            }
        }
    }
}