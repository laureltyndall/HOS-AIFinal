using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class PaperPickup : MonoBehaviour
    {
        public bool Clickable = false;
        public Texture2D NewCursor;
        public PlayerCameraController MovementScript;
        public MeshCollider MyCollider;
        public Text TextArea;
        public KitchenSceneManager KitchenManager;
        public int ClickCount = 0;
        public GameObject NotePanel;
        public GameManager ManagerScript;
        public bool ManagerFound = false;
        public GameObject CloseUpCamera;
        public AudioSource PaperCrinkle;
        public AudioSource MouseSqueak;

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
                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[4] && KitchenManager.InCloseUp && !KitchenManager.RadioOn && !KitchenManager.MouseOn)
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
                if(ClickCount == 0)
                {
                    if (!KitchenManager.MiniGameWon)
                    {
                        TextArea.text = "*Gasp!*";
                        KitchenManager.MouseOn = true;
                        KitchenManager.LookingForCheese = true;
                        MouseSqueak.Play();
                    }
                    else
                    {
                        TextArea.text = "Now let's see what this says, shall we?";
                        // Add note to inventory
                        PaperCrinkle.Play();
                        ManagerScript.MasterInventory.AddInventoryItem(InventoryItem.MysteryChecklist);
                        NotePanel.SetActive(true);

                        CloseUpCamera.SetActive(false);
                        MovementScript.CanOrbit = true;
                        MovementScript.CanBackup = false;
                        MovementScript.TurnOffCloseup = false;
                        KitchenManager.InCloseUp = false;
                    }
                }
                ClickCount++;
            }
        }
    }
}