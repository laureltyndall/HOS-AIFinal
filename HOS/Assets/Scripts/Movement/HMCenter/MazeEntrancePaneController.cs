﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class MazeEntrancePaneController : MonoBehaviour
    {
        public bool Clickable = false;
        public Texture2D NewCursor;
        public PlayerCameraController MovementScript;
        public HMCenterManager HMCManager;
        public MeshCollider MyCollider;
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

            if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[0] || MovementScript.CurrentWaypoint == MovementScript.WaypointList[1])
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
                Cursor.SetCursor(MovementScript.CursorList[2], Vector2.zero, CursorMode.Auto);
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

                TextArea.text = "I don't need to go back out there right now. I should find " + MovementScript.SiblingName + ".";
            }
        }
    }
}