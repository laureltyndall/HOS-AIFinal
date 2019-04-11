using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class ShovelObjectController : MonoBehaviour
    {
        public bool Clickable = true;
        public Texture2D NewCursor;
        public PlayerCameraController MovementScript;
        public GameManager ManagerScript;
        private MenuManager Controller;
        public Text TextArea;
        public bool ManagerFound = false;
        public MeshRenderer Shovel;
        private bool ShovelClicked = false;
        public bool ShovelinInventory = false;
        public GameObject ShovelUIObject;

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
                Controller = gm.gameObject.GetComponent<MenuManager>();

                if (ManagerScript != null)
                {
                    ManagerFound = true;
                }
            }

            if(ShovelClicked && !ShovelUIObject.activeSelf)
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }

            if(ShovelinInventory)
            {
                if (ManagerScript.MasterInventory != null)
                {
                    ManagerScript.MasterInventory.AddInventoryItem(InventoryItem.Trowel);
                }

                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[4])
                {
                    MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[2].transform.position;
                    MovementScript.CurrentWaypoint = MovementScript.WaypointList[2];

                 //   MovementScript.CurrentPlayer.transform.Rotate(new Vector3(0f, 180f, 0f));
                    MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                    
                    Camera.main.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                   // Camera.main.transform.Rotate(new Vector3(0f, 0f, 0f));

                    MovementScript.CanUturn = false;
                    MovementScript.CanOrbit = false;
                    MovementScript.CanLeftTurn = false;
                    MovementScript.CanRightTurn = false;
                    MovementScript.CanForward = false;
                    MovementScript.CanBackup = false;
                }
            }
        }

        void OnMouseOver()
        {
            if (Clickable)
            {
                //If your mouse hovers over the GameObject with the script attached, output this message
                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[4])
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

                if(tag == "Trowel")
                {
                    TextArea.text = "This should help me get that snake out of the way.";
                    ShovelClicked = true;
                    Controller.TogglePanel(ShovelUIObject);
                    Cursor.SetCursor(NewCursor, Vector2.zero, CursorMode.Auto);
                }
            }
        }

        public void ClickUIShovel()
        {
            Controller.TogglePanel(ShovelUIObject);
            ShovelinInventory = true;
        }
    }
}