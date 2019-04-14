using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class HouseExteriorDoorController : MonoBehaviour
    {
        public bool Clickable = false;
        public Texture2D NewCursor;
        public PlayerCameraController MovementScript;
        public BoxCollider MyCollider;
        public Text TextArea;
        public bool Knocked = false;
        public int KnockCount = 0;
        public DoorknobController KnobScript;
        public GameManager ManagerScript;
        public bool ManagerFound = false;

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
                    // If we are right next to the gate and we are looking at it
                    Clickable = true;
                    MyCollider.enabled = true;
                }
                else
                {
                    Clickable = false;
                    MyCollider.enabled = false;
                }

                if (MovementScript.InteriorGhost)
                {
                    Knocked = true;
                }

                if (KnockCount == 1)
                {
                    TextArea.text = (MovementScript.SiblingName + "! It's " + MovementScript.PlayerName + "!");
                }
                else if (KnockCount == 2)
                {
                    TextArea.text = ("Hello?");
                }
                else if (KnockCount == 3)
                {
                    string pronoun = "";

                    if (MovementScript.SiblingName == "Alex")
                    {
                        pronoun = "he";
                    }
                    else if (MovementScript.SiblingName == "Anne")
                    {
                        pronoun = "she";
                    }

                    TextArea.text = ("Maybe " + pronoun + " isn't home");
                }
                else if (KnockCount == 4)
                {
                    TextArea.text = ("I should try the door handle. I don't want to be stuck out here if I can help it.");
                    Knocked = true;
                }
            }
        }

        void OnMouseOver()
        {
            if (Clickable)
            {
                // If Inventory does not have flashlight
                Cursor.SetCursor(MovementScript.CursorList[5], Vector2.zero, CursorMode.Auto);
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
                Debug.Log(this.name + " has been clicked");
                Clickable = false;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

                if(!Knocked)
                {
                    KnockCount++;
                }
                else
{                   if (MovementScript.InteriorGhost)
                    {
                        ManagerScript.HallFromRoom = false;
                        ManagerScript.HallfromOutside = true;
                        SceneManager.LoadScene("HouseHallway");
                    }
                    else
                    {
                        KnobScript.Clickable = true;
                    }
                }
            }
        }
    }
}