using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class CheeseController : MonoBehaviour
    {
        public bool Clickable = false;
        public Texture2D NewCursor;
        public PlayerCameraController MovementScript;
        public BoxCollider MyCollider;
        public Text TextArea;
        public KitchenSceneManager KitchenManager;
        public Animation FridgeAnimation;
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
                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[5] && !KitchenManager.HasCheese)
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

                FridgeAnimation.Play("close");

                // Move back to crossroads waypoint, initial forward movement no longer controlled here
                MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[4].transform.position;
                MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                MovementScript.CurrentWaypoint = MovementScript.WaypointList[4];
                Camera.main.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                //Camera.main.transform.Rotate(0, 0, 0);
                MovementScript.CanUturn = false;
                MovementScript.CanOrbit = true;
                MovementScript.CanLeftTurn = false;
                MovementScript.CanRightTurn = false;
                MovementScript.CanForward = false;
                MovementScript.CanBackup = false;

                MovementScript.UTurnSelected = false;
                // Add cheese to inventory
                ManagerScript.MasterInventory.AddInventoryItem(InventoryItem.Cheese);
                if (KitchenManager.HasBox)
                {
                    TextArea.text = ("That should be everything I need to deal with the mouse.");
                }
                else
                {
                    TextArea.text = ("I still need to find something to trap the mouse in.");
                }

                KitchenManager.HasCheese = true;
            }
        }
    }
}