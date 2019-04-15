using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class FridgeController : MonoBehaviour
    {
        public bool Clickable = false;
        public Texture2D NewCursor;
        public PlayerCameraController MovementScript;
        public BoxCollider MyCollider;
        public Text TextArea;
        public KitchenSceneManager KitchenManager;
        public Animation MyAnimation;
        public AudioSource FridgeClick;

        // Use this for initialization
        void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
            MovementScript = go.GetComponent<PlayerCameraController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[4] && KitchenManager.LookingForCheese && !KitchenManager.HasCheese)
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

                MyAnimation.Play("open");
                FridgeClick.Play();

                // Move back to crossroads waypoint, initial forward movement no longer controlled here
                MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[5].transform.position;
                MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 242.5f, 0f);
                MovementScript.CurrentWaypoint = MovementScript.WaypointList[5];
                //  Camera.main.transform.rotation = Quaternion.Euler(31.22f, 0f, 0f);
                Camera.main.transform.Rotate(31.22f, 0, 0);
                MovementScript.CanUturn = false;
                MovementScript.CanOrbit = false;
                MovementScript.CanLeftTurn = false;
                MovementScript.CanRightTurn = false;
                MovementScript.CanForward = false;
                MovementScript.CanBackup = false;

                MovementScript.UTurnSelected = false;

                TextArea.text = ("I can try to lure the mouse away with this cheese.");
            }
        }
    }
}