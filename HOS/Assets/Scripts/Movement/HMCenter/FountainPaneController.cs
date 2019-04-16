using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class FountainPaneController : MonoBehaviour
    {
        public bool Clickable = false;
        public Texture2D NewCursor;
        public PlayerCameraController MovementScript;
        public HMCenterManager HMCManager;
        public MeshCollider MyCollider;
        public Text TextArea;
        public AudioSource Footstep;
        public AudioSource BirdCall;

        // Use this for initialization
        void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
            MovementScript = go.GetComponent<PlayerCameraController>();
        }

        // Update is called once per frame
        void Update()
        {

            if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[1] && !HMCManager.PuzzleFinished)
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
                MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[2].transform.position;
                MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                Camera.main.transform.rotation = Quaternion.Euler(14f, 180f, 0f);
                MovementScript.CurrentWaypoint = MovementScript.WaypointList[2];
                MovementScript.CanUturn = true;
                MovementScript.CanOrbit = false;
                MovementScript.CanLeftTurn = false;
                MovementScript.CanRightTurn = false;
                MovementScript.CanForward = true;
                MovementScript.CanBackup = false;
                MovementScript.UTurnSelected = false;

                if(HMCManager.PuzzleFound)
                {
                    BirdCall.Play();
                    TextArea.text = "That bird has the star!";
                }
            }
        }
    }
}