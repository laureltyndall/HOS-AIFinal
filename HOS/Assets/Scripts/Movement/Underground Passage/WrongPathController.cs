using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class WrongPathController : MonoBehaviour
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
            if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[14])
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

                MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[15].transform.position;
                MovementScript.CurrentWaypoint = MovementScript.WaypointList[15];
                MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                //    Camera.main.transform.rotation = Quaternion.Euler(45f, -160f, 0f);

                MovementScript.CanUturn = false;
                MovementScript.CanOrbit = false;
                MovementScript.CanLeftTurn = false;
                MovementScript.CanRightTurn = false;
                MovementScript.CanForward = true;
                MovementScript.CanBackup = false;

                UPScript.WrongPath = true;
            }
        }
    }
}