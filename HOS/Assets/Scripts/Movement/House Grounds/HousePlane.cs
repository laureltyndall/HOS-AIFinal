using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class HousePlane : MonoBehaviour
    {
        public bool Clickable = false;
        public Texture2D NewCursor;
        public PlayerCameraController MovementScript;
        public MeshCollider MyCollider;
        public Text TextArea;
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
                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[4] && !MovementScript.UTurnSelected)
                {
                    // If we are right next to the house and we are looking at it
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
                //If your mouse hovers over the GameObject with the script attached, output this message
                Cursor.SetCursor(NewCursor, Vector2.zero, CursorMode.Auto);
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

                ManagerScript.GroundsFromGate = false;
                ManagerScript.GroundsFromHouse = false;
                ManagerScript.HouseFromGrounds = true;
                ManagerScript.HousefromInside = false;
                ManagerScript.KitchenFromHall = false;
                ManagerScript.KitchenFromGame = false;
                ManagerScript.LRFromHall = false;
                ManagerScript.LRFromGame = false;
                ManagerScript.LRFromUnderground = false;
                ManagerScript.CenterFromMaze = false;
                ManagerScript.CenterFromGame = false;
                ManagerScript.HallfromOutside = false;
                ManagerScript.HallFromRoom = false;
                SceneManager.LoadScene("HouseExterior");

           //     TextArea.text = ("I shouldn't leave without finding " + MovementScript.SiblingName);
            }
        }
    }
}