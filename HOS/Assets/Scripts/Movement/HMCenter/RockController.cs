﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class RockController : MonoBehaviour
    {
        public bool Clickable = false;
        public Texture2D NewCursor;
        public PlayerCameraController MovementScript;
        public HMCenterManager HMCManager;
        public BoxCollider MyCollider;
        public Text TextArea;
        public GameObject RockSpot1;
        public GameObject RockDisplaced;
        public GameObject Worms;
        public AudioSource RockMoving;

        // Use this for initialization
        void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
            MovementScript = go.GetComponent<PlayerCameraController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[4] && !HMCManager.HasWorms)
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

                TextArea.text = "These earthworms should do the trick.";
                RockMoving.Play();
                RockDisplaced.SetActive(true);
                Worms.SetActive(true);
                RockSpot1.SetActive(false);
            }
        }
    }
}