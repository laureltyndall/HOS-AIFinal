using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class HallLRDoorController : MonoBehaviour
    {
        public bool Clickable = false;
        public PlayerCameraController MovementScript;
        public MeshCollider MyCollider;
        public HallwayMananger HallScript;
        public Text TextArea;
        public GameManager ManagerScript;
        public bool ManagerFound = false;
        public AudioSource DoorOpen;

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
                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[3] && ManagerScript.InteriorGhostSeen && ManagerScript.HallfromOutside)
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
                Debug.Log(this.name + " has been clicked");
                Clickable = false;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                DoorOpen.Play();
                ManagerScript.GroundsFromGate = false;
                ManagerScript.GroundsFromHouse = false;
                ManagerScript.HouseFromGrounds = false;
                ManagerScript.HousefromInside = false;
                ManagerScript.KitchenFromHall = false;
                ManagerScript.KitchenFromGame = false;
                ManagerScript.LRFromHall = true;
                ManagerScript.LRFromGame = false;
                ManagerScript.LRFromUnderground = false;
                ManagerScript.CenterFromMaze = false;
                ManagerScript.CenterFromGame = false;
                ManagerScript.HallfromOutside = false;
                ManagerScript.HallFromRoom = false;
                SceneManager.LoadScene("Living Room");
            }
        }
    }
}