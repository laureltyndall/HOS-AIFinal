using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class FlashlightController : MonoBehaviour
    {
        public bool Clickable = false;
        public Texture2D NewCursor;
        public PlayerCameraController MovementScript;
        public CapsuleCollider MyCollider;
        public Text TextArea;
        public LRManager RoomManager;
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
                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[4] && !RoomManager.HaveFlashlight)
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

                // Add flashlight to inventory
                ManagerScript.MasterInventory.AddInventoryItem(InventoryItem.Flashlight);
                TextArea.text = ("A flashlight! Perfect!");
                RoomManager.HaveFlashlight = true;
            }
        }
    }
}