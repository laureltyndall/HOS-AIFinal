using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HOS
{
    public class IntroTableController : MonoBehaviour
    {

        public bool Clickable = false;
        public Texture2D NewCursor;
        public PlayerCameraController MovementScript;
        public CursorChanger LetterCursorScript;
        public PickupInventoryItem LetterInventoryScript;
        public BoxCollider MyCollider;
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
            if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[1])
            {
                Clickable = true;
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
                Clickable = false;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

                MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[2].transform.position;
                MovementScript.CurrentWaypoint = MovementScript.WaypointList[2];
                MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 20f, 0f);
                Camera.main.transform.rotation = Quaternion.Euler(25f, 19f, 0f);

                MovementScript.CanUturn = false;
                MovementScript.CanOrbit = false;
                MovementScript.CanLeftTurn = false;
                MovementScript.CanRightTurn = false;
                MovementScript.CanForward = false;
                MovementScript.CanBackup = false;

                Footstep.Play();

                MyCollider.enabled = false;
            }
        }
    }
}