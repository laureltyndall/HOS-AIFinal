using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HOS
{
    public class IntroDoorController : MonoBehaviour
    {

        public bool Clickable = true;
        public Texture2D NewCursor;
        public Texture2D SecondCursor;
        public PlayerCameraController MovementScript;
        public GameManager ManagerScript;
        public Text TextArea;
        public bool ManagerFound = false;
        public AudioSource DoorOpen;
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

                if(ManagerScript != null)
                {
                    ManagerFound = true;
                }
            }
        }

        void OnMouseOver()
        {
            if (Clickable)
            {
                //If your mouse hovers over the GameObject with the script attached, output this message
                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[0])
                {
                    Cursor.SetCursor(NewCursor, Vector2.zero, CursorMode.Auto);

                }
                else if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[1])
                {
                    Cursor.SetCursor(SecondCursor, Vector2.zero, CursorMode.Auto);
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

                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[0])
                {
                    // If the player has the letter in inventory, leave the house
                    if(ManagerScript.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.SiblingLetter))
                    {
                        DoorOpen.Play();
                        ManagerScript.PlayerCopy = ManagerScript.CurrentPlayer;
                        //ManagerScript.LoadScene("Gate Scene");
                        ManagerScript.CenterFromMaze = true;
                        ManagerScript.LoadScene("HedgeMazeCenter");
                    }
                    // else, dialogue that you don't need to leave right now
                    else
                    {
                        TextArea.text = "I don’t need to go outside right now.";
                    }

                }
                else if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[1])
                {
                    MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[0].transform.position;
                    MovementScript.CurrentWaypoint = MovementScript.WaypointList[0];
                    //     MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 20f, 0f);
                    //     Camera.main.transform.rotation = Quaternion.Euler(25f, 19f, 0f);

                    MovementScript.CanUturn = true;
                    MovementScript.CanOrbit = false;
                    MovementScript.CanLeftTurn = false;
                    MovementScript.CanRightTurn = false;
                    MovementScript.CanForward = true;
                    MovementScript.CanBackup = false;

                    Footstep.Play();
                }
            }
        }
    }

}