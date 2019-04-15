using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HOS
{
    public class HousePathRestrictionPlane : MonoBehaviour
    {
        public bool Clickable = false;
        public Texture2D NewCursor;
        public PlayerCameraController MovementScript;
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
            if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[3])
            {
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

                // Move player along house path
                // Move closer to House
                MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[4].transform.position;
                MovementScript.CurrentWaypoint = MovementScript.WaypointList[4];
          //      MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 306.9f, 0f);
                MovementScript.CanUturn = true;
                MovementScript.CanOrbit = false;
                MovementScript.CanLeftTurn = false;
                MovementScript.CanRightTurn = false;
                MovementScript.CanForward = true;
                MovementScript.CanBackup = false;

                Footstep.Play();

                TextArea.text = "I think I see a light over there. This must be the way to the house.";
            }
        }
    }
}