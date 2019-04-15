﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class FrontDoorController : MonoBehaviour
    {
        public bool Clickable = false;
        public PlayerCameraController MovementScript;
        public MeshCollider MyCollider;
        public HallwayMananger HallScript;
        public Text TextArea;
        public GameManager ManagerScript;
        public bool ManagerFound = false;
        public AudioSource DoorOpen;
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
            if (!ManagerFound)
            {
                GameObject gm = GameObject.FindGameObjectWithTag("GameController");
                ManagerScript = gm.gameObject.GetComponent<GameManager>();

                if (ManagerScript != null)
                {
                    ManagerFound = true;
                }
            }
            else
            {
                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[0])
                {
                    // If we are right next to the gate and we are looking at it
                    Clickable = true;
                    MyCollider.enabled = true;
                }
                else if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[1])
                {
                    // If we are right next to the gate and we are looking at it
                    Clickable = true;
                    MyCollider.enabled = true;
                }
                else if(MovementScript.CurrentWaypoint == MovementScript.WaypointList[3])
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
        }

        void OnMouseOver()
        {
            if (Clickable)
            {
                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[0] || MovementScript.CurrentWaypoint == MovementScript.WaypointList[1])
                {
                    Cursor.SetCursor(MovementScript.CursorList[2], Vector2.zero, CursorMode.Auto);
                }
                else
                {
                    Cursor.SetCursor(MovementScript.CursorList[3], Vector2.zero, CursorMode.Auto);
                }
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

                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[0] || MovementScript.CurrentWaypoint == MovementScript.WaypointList[1])
                {
                    if (HallScript.GhostSeen && !HallScript.GhostOn)
                    {
                        DoorOpen.Play();
                        ManagerScript.GroundsFromGate = false;
                        ManagerScript.GroundsFromHouse = false;
                        ManagerScript.HouseFromGrounds = false;
                        ManagerScript.HousefromInside = true;
                        ManagerScript.KitchenFromHall = false;
                        ManagerScript.KitchenFromGame = false;
                        ManagerScript.LRFromHall = false;
                        ManagerScript.LRFromGame = false;
                        ManagerScript.LRFromUnderground = false;
                        ManagerScript.CenterFromMaze = false;
                        ManagerScript.CenterFromGame = false;
                        ManagerScript.HallfromOutside = false;
                        ManagerScript.HallFromRoom = false;
                        SceneManager.LoadScene("HouseExterior");
                    }
                    else
                    {
                        TextArea.text = "I don't need to go out there right now.";
                    }
                }
                else
                {
                    if(HallScript.GhostSeen)
                    {
                        
                        MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[1].transform.position;
                        MovementScript.CurrentWaypoint = MovementScript.WaypointList[1];
                        MovementScript.CanUturn = false;
                        MovementScript.CanOrbit = true;
                        MovementScript.CanLeftTurn = false;
                        MovementScript.CanRightTurn = false;
                        MovementScript.CanForward = false;
                        MovementScript.CanBackup = false;
                        Footstep.Play();
                    }
                }
            }
        }
    }
}