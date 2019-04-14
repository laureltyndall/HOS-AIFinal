using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class ContinuePathController : MonoBehaviour
    {
        private bool Clickable = false;
        private PlayerCameraController MovementScript;
        public MeshCollider MyCollider;
        public PassageManager UPScript;

        // Use this for initialization
        void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
            MovementScript = go.GetComponent<PlayerCameraController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (UPScript.GhostChasing)
            {
                // If we are have freed our twin and seen the ghost begin chasing us
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

                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[5])
                {
                    MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[6].transform.position;
                    MovementScript.CurrentWaypoint = MovementScript.WaypointList[6];
                    MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
                    //    Camera.main.transform.rotation = Quaternion.Euler(45f, -160f, 0f);
                }
                else if(MovementScript.CurrentWaypoint == MovementScript.WaypointList[7])
                {
                    MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[8].transform.position;
                    MovementScript.CurrentWaypoint = MovementScript.WaypointList[8];
                    MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
                }
                else if(MovementScript.CurrentWaypoint == MovementScript.WaypointList[10])
                {
                    MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[11].transform.position;
                    MovementScript.CurrentWaypoint = MovementScript.WaypointList[11];
                    MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 360f, 0f);
                }

                MovementScript.CanUturn = false;
                MovementScript.CanOrbit = false;
                MovementScript.CanLeftTurn = false;
                MovementScript.CanRightTurn = false;
                MovementScript.CanForward = true;
                MovementScript.CanBackup = false;
            }
        }
    }
}