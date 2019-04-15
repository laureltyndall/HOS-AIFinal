using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class FireplacePane : MonoBehaviour
    {
        public bool Clickable = false;
        public Texture2D NewCursor;
        public PlayerCameraController MovementScript;
        public LRManager RoomManager;
        public MeshCollider MyCollider;
        public Text TextArea;
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

        }

        void OnMouseOver()
        {
            if (Clickable)
            {
                // If Inventory does not have flashlight
                Cursor.SetCursor(MovementScript.CursorList[3], Vector2.zero, CursorMode.Auto);
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
                Footstep.Play();
                MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[3].transform.position;
                MovementScript.CurrentWaypoint = MovementScript.WaypointList[3];
                MovementScript.CanUturn = true;
                MovementScript.CanOrbit = false;
                MovementScript.CanLeftTurn = false;
                MovementScript.CanRightTurn = false;
                MovementScript.CanForward = true;
                MovementScript.CanBackup = false;
                MovementScript.UTurnSelected = false;
            }
        }
    }
}