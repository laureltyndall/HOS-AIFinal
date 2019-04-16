using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class StickController : MonoBehaviour
    {
        public bool Clickable = false;
        public PlayerCameraController MovementScript;
        public BoxCollider MyCollider;
        public Text TextArea;
        public GameManager ManagerScript;
        public bool ManagerFound = false;
        public AudioSource StickSound;
        public GameObject CloseUpCamera;
        public bool CameraOn = false;

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
                if(CameraOn)
                {
                    CloseUpCamera.SetActive(true);
                }
                else
                {
                    CloseUpCamera.SetActive(false);
                }

                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[9] && CameraOn)
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


                if (!ManagerScript.CurrentPlayer.PlayerInventory.ContainsKey(InventoryItem.Stick))
                {
                    TextArea.text = ("What a cool stick. I'll take it with me just in case.");
                    StickSound.Play();
                    ManagerScript.MasterInventory.AddInventoryItem(InventoryItem.Stick);
                    CameraOn = false;
                }
                
            }
        }
    }
}