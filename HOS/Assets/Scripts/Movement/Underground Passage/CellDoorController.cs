using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class CellDoorController : MonoBehaviour
    {
        private bool Clickable = false;
        private PlayerCameraController MovementScript;
        public MeshCollider MyCollider;
        public PassageManager UPScript;
        public Text TextArea;

        // Use this for initialization
        void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
            MovementScript = go.GetComponent<PlayerCameraController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[2] && !UPScript.FoundTwin)
            {
                // If we are near the cell but haven't talked to our twin yet
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
                Cursor.SetCursor(MovementScript.CursorList[3], Vector2.zero, CursorMode.Auto);
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

                MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[3].transform.position;
                MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                //    Camera.main.transform.rotation = Quaternion.Euler(45f, -160f, 0f);
                MovementScript.CurrentWaypoint = MovementScript.WaypointList[3];
                MovementScript.CanUturn = false;
                MovementScript.CanOrbit = false;
                MovementScript.CanLeftTurn = false;
                MovementScript.CanRightTurn = false;
                MovementScript.CanForward = false;
                MovementScript.CanBackup = false;

                UPScript.FoundTwin = true;
            }
        }
    }
}