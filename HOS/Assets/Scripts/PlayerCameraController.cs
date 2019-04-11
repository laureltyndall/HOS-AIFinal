﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class PlayerCameraController : MonoBehaviour
    {
        public GameObject CurrentPlayer;
        public GameManager ManagerScript;
        public float RotateTime = 0.2f;
        public List<GameObject> WaypointList = new List<GameObject>();
        public GameObject CurrentWaypoint;
        public List<Texture2D> CursorList;
        public Camera MainCamera;
        public CursorType CurrentCursor = CursorType.Default;
        public Scene CurrentScene;
        public bool PlayerFound = false;
        public bool UTurnSelected = false;

        public string PlayerName;
        public string SiblingName;

        public bool CanUturn = false;
        public bool CanOrbit = false;
        public bool CanLeftTurn = false;
        public bool CanRightTurn = false;
        public bool CanForward = false;
        public bool CanBackup = false;

        // Use this for initialization
        void Start()
        {
            FindWaypointList();
            CurrentScene = SceneManager.GetActiveScene();
            GameObject GO = GameObject.FindGameObjectWithTag("GameController");
            ManagerScript = GO.GetComponent<GameManager>();

            FindCharacter();
        }

        void Update()
        {
            if (CurrentPlayer == null)
            {
                FindCharacter();

                if (CurrentPlayer != null)
                {
                    if(CurrentPlayer.tag == "PlayerAlex")

                    {
                        PlayerName = "Alex";
                        SiblingName = "Anne";
                    }
                    else if (CurrentPlayer.tag == "PlayerAnne")
                    {
                        PlayerName = "Anne";
                        SiblingName = "Alex";
                    }

                    if (CurrentScene.name == "Intro")
                    {
                        MainCamera = Camera.main;
                        CurrentPlayer.transform.position = WaypointList[0].transform.position;
                        CurrentWaypoint = WaypointList[0];
                        CanUturn = true;
                        CanForward = true;
                    }
                    if (CurrentScene.name == "Gate Scene")
                    {
                        MainCamera = Camera.main;
                        CurrentPlayer.transform.position = WaypointList[0].transform.position;
                        CurrentWaypoint = WaypointList[0];
                        CanUturn = true;
                        CanForward = true;
                    }
                    if (CurrentScene.name == "HouseGrounds")
                    {
                        if (ManagerScript.GroundsFromGate)
                        {
                            MainCamera = Camera.main;
                            CurrentPlayer.transform.position = WaypointList[0].transform.position;
                            CurrentWaypoint = WaypointList[0];
                            CanUturn = true;
                            CanForward = true;
                        }
                        else if (ManagerScript.GroundsFromHouse)
                        {
                            MainCamera = Camera.main;
                            CurrentPlayer.transform.position = WaypointList[0].transform.position;
                            CurrentWaypoint = WaypointList[4];
                            // Turn the player around
                            CanUturn = true;
                            CanForward = true;
                        }
                    }
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                MovePlayer();
            }

            if (CurrentScene.name == "Gate Scene")
            {
                if (CurrentWaypoint == WaypointList[3])     // Gate closeup
                {
                    CanUturn = false;
                    CanOrbit = false;
                    CanLeftTurn = false;
                    CanRightTurn = false;
                    CanForward = false;
                    CanBackup = true;
                }
                else if (CurrentWaypoint == WaypointList[4])    // Shovel closeup
                {
                    CanUturn = false;
                    CanOrbit = false;
                    CanLeftTurn = false;
                    CanRightTurn = false;
                    CanForward = false;
                    CanBackup = true;
                }
            }

            if (CurrentScene.name == "HouseGrounds")
            {
                if (CurrentWaypoint == WaypointList[0])     // Near Gate
                {
                    if (UTurnSelected)      // Looking at gate
                    {
                        CanUturn = true;
                        CanOrbit = false;
                        CanLeftTurn = false;
                        CanRightTurn = false;
                        CanForward = false;
                        CanBackup = false;
                    }
                    else    // Looking at crossroads
                    {
                        CanUturn = true;
                        CanOrbit = false;
                        CanLeftTurn = false;
                        CanRightTurn = false;
                        CanForward = true;
                        CanBackup = false;
                    }
                }
            }

        }

        public void FindWaypointList()
        {
            GameObject TempObj = GameObject.FindGameObjectWithTag("WaypointList");
            WaypointList = new List<GameObject>();
            foreach (Transform t in TempObj.transform)
            {
                WaypointList.Add(t.gameObject);
            }
        }

        #region Testing Code Only
        //public void OnPointerClick(PointerEventData data)
        //{
        //    if (CurrentScene.name == "Intro")
        //    {
        //        if (CurrentCursor == CursorType.Forward)
        //        {
        //            if (CanForward)
        //            {
        //                if (CurrentWaypoint == WaypointList[0])
        //                {
        //                    CurrentPlayer.transform.position = WaypointList[1].transform.position;
        //                    CurrentWaypoint = WaypointList[1];
        //                }
        //                else if (CurrentWaypoint == WaypointList[2])
        //                {
        //                    CurrentPlayer.transform.position = WaypointList[0].transform.position;
        //                    CurrentWaypoint = WaypointList[0];
        //                }
        //            }
        //        }

        //        if (CurrentCursor == CursorType.TurnAround)
        //        {
        //            MovePlayerUturn();

        //        }
        //        if (CurrentCursor == CursorType.Backup)
        //        {
        //            if (CurrentScene.name == "Intro")
        //            {
        //                if (CurrentWaypoint == WaypointList[2])
        //                {
        //                    CurrentPlayer.transform.position = WaypointList[1].transform.position;
        //                    CurrentWaypoint = WaypointList[1];

        //                }
        //            }

        //        }
        //    }
        //    else if (CurrentScene.name == "Gate Scene")
        //    {
        //        if (CurrentCursor == CursorType.Forward)
        //        {
        //            if (CanForward)
        //            {
        //                if (CurrentWaypoint == WaypointList[0])
        //                {
        //                    CurrentPlayer.transform.position = WaypointList[1].transform.position;
        //                    CurrentWaypoint = WaypointList[1];
        //                    CanUturn = false;
        //                    CanOrbit = false;
        //                    CanLeftTurn = false;
        //                    CanRightTurn = false;
        //                    CanForward = true;
        //                    CanBackup = false;
        //                }
        //                else if (CurrentWaypoint == WaypointList[2])
        //                {
        //                    CurrentPlayer.transform.position = WaypointList[3].transform.position;
        //                    CurrentWaypoint = WaypointList[3];
        //                    CanUturn = false;
        //                    CanOrbit = false;
        //                    CanLeftTurn = false;
        //                    CanRightTurn = false;
        //                    CanForward = false;
        //                    CanBackup = false;


        //                }
        //            }
        //        }

        //        if (CurrentCursor == CursorType.TurnAround)
        //        {
        //            if (CurrentWaypoint == WaypointList[0])
        //            {
        //                MovePlayerUturn();
        //            }
        //        }

        //        if (CurrentCursor == CursorType.Backup)
        //        {
        //            if (CurrentScene.name == "Gate Scene")
        //            {
        //                if (CurrentWaypoint == WaypointList[4])
        //                {
        //                    CurrentPlayer.transform.position = WaypointList[3].transform.position;
        //                    CurrentWaypoint = WaypointList[3];
        //                }
        //                if (CurrentWaypoint == WaypointList[5])
        //                {
        //                    CurrentPlayer.transform.position = WaypointList[3].transform.position;
        //                    CurrentWaypoint = WaypointList[3];
        //                }
        //            }

        //        }
        //    }
        //}
        #endregion

        public void MovePlayer()
        {
            if (CurrentScene.name == "Intro")
            {
                if (CurrentCursor == CursorType.Forward)
                {
                    if (CanForward)
                    {
                        if (CurrentWaypoint == WaypointList[0])
                        {
                            CurrentPlayer.transform.position = WaypointList[1].transform.position;
                            CurrentWaypoint = WaypointList[1];
                            CanUturn = true;
                            CanOrbit = true;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = false;
                            CanBackup = false;
                        }
                        //else if (CurrentWaypoint == WaypointList[2])
                        //{
                        //    CurrentPlayer.transform.position = WaypointList[0].transform.position;
                        //    CurrentWaypoint = WaypointList[0];
                        //    //   Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                        //}
                        //else if (CurrentWaypoint == WaypointList[1])
                        //{
                        //    CurrentPlayer.transform.position = WaypointList[2].transform.position;
                        //    CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 20f, 0f);
                        //    CurrentWaypoint = WaypointList[2];
                        //    Camera.main.transform.rotation = Quaternion.Euler(25f, 19f, 0f);
                        //}

                    }
                }

                if (CurrentCursor == CursorType.TurnAround)
                {
                    MovePlayerUturn();

                }
                if (CurrentCursor == CursorType.Backup)
                {
                    if (CurrentScene.name == "Intro")
                    {
                        if (CurrentWaypoint == WaypointList[2])
                        {
                            CurrentPlayer.transform.position = WaypointList[1].transform.position;
                            CurrentWaypoint = WaypointList[1];

                        }
                    }

                }
            }
            else if (CurrentScene.name == "Gate Scene")
            {
                if (CurrentCursor == CursorType.Forward)
                {
                    if (CanForward)
                    {
                        if (CurrentWaypoint == WaypointList[0])
                        {
                            CurrentPlayer.transform.position = WaypointList[1].transform.position;
                            CurrentWaypoint = WaypointList[1];
                            CanUturn = false;
                            CanOrbit = false;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = true;
                            CanBackup = false;
                        }
                        else if (CurrentWaypoint == WaypointList[1])
                        {
                            CurrentPlayer.transform.position = WaypointList[2].transform.position;
                            CurrentWaypoint = WaypointList[2];
                            CanUturn = false;
                            CanOrbit = true;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = false;
                            CanBackup = false;
                        }
                    }
                }

                if (CurrentCursor == CursorType.TurnAround)
                {
                    if (CurrentWaypoint == WaypointList[0])
                    {
                        MovePlayerUturn();
                    }
                }

                if (CurrentCursor == CursorType.Backup)
                {
                    if (CurrentScene.name == "Gate Scene")
                    {
                        if (CurrentWaypoint == WaypointList[3])
                        {
                            CurrentPlayer.transform.position = WaypointList[2].transform.position;
                            CurrentWaypoint = WaypointList[2];
                            Camera.main.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

                            CanUturn = false;
                            CanOrbit = true;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = false;
                            CanBackup = false;
                        }
                        if (CurrentWaypoint == WaypointList[4])
                        {
                            CurrentPlayer.transform.position = WaypointList[2].transform.position;
                            CurrentWaypoint = WaypointList[2];
                            CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                            Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

                            CanUturn = false;
                            CanOrbit = false;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = false;
                            CanBackup = false;
                        }
                    }

                }
            }
            else if (CurrentScene.name == "HouseGrounds" && ManagerScript.GroundsFromGate)
            {
                if (CurrentCursor == CursorType.Forward)
                {
                    if (CanForward)
                    {
                        if (CurrentWaypoint == WaypointList[0])     // By gate
                        {
                            if (UTurnSelected)     // Looking at gate, controlled by restriction pane
                            {
                                // Do not move, only look at gate.
                                // Foward movement controlled by restirction pane
                                CanUturn = true;        // Uturn able to turn on
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;      // forward able to 
                                CanBackup = false;
                            }
                            else    // Looking towards house, controlled by this
                            {
                                // Move to next waypoint between gate and crossroads
                                CurrentPlayer.transform.position = WaypointList[1].transform.position;
                                CurrentWaypoint = WaypointList[1];

                                CanUturn = true;        // Uturn able to turn on
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = true;      // able to move forward
                                CanBackup = false;
                            }
                        }                   // By Gate
                        else if (CurrentWaypoint == WaypointList[1])
                        {
                            if (!UTurnSelected)     // Looking towards house
                            {
                                // Move to next waypoint between gate and crossroads
                                CurrentPlayer.transform.position = WaypointList[2].transform.position;
                                CurrentWaypoint = WaypointList[2];
                                //   Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                CanUturn = true;
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = true;
                                CanBackup = false;
                            }
                            else     // Looking towards gate
                            {
                                // Move to previous waypoint closer to gate
                                CurrentPlayer.transform.position = WaypointList[0].transform.position;
                                CurrentWaypoint = WaypointList[0];
                                //   Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                CanUturn = true;
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = true;
                                CanBackup = false;
                            }
                        }               // Between gate and crossroads
                        else if (CurrentWaypoint == WaypointList[2])                
                        {
                            if (!UTurnSelected)     // Looking towards house
                            {
                                // Move to crossroads waypoint, initial forward movement no longer controlled here
                                CurrentPlayer.transform.position = WaypointList[3].transform.position;
                                CurrentWaypoint = WaypointList[3];
                                //   Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                CanUturn = false;
                                CanOrbit = true;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;
                                CanBackup = false;

                                UTurnSelected = false;
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            }
                            else     // Looking towards gate
                            {
                                // Move to previous waypoint closer to gate
                                CurrentPlayer.transform.position = WaypointList[1].transform.position;
                                CurrentWaypoint = WaypointList[1];
                                //   Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                CanUturn = true;
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = true;
                                CanBackup = false;
                            }
                        }               // Between gate and crossroads
                        // Crossroads movement controlled by restriction panes
                        // It will no longer be possible to get back to the gate waypoint section
                        else if (CurrentWaypoint == WaypointList[4])
                        {
                            if (!UTurnSelected)     // Looking towards house
                            {
                                // "Move" to the next waypoint closer to the house by loading the house exterior scene
                                UTurnSelected = false;
                                SceneManager.LoadScene("HouseExterior");
                            }
                            else     //Looking towards crossroads
                            {
                                // Move back to crossroads waypoint, initial forward movement no longer controlled here
                                CurrentPlayer.transform.position = WaypointList[3].transform.position;
                                CurrentWaypoint = WaypointList[3];
                                //   Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                CanUturn = false;
                                CanOrbit = true;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;
                                CanBackup = false;

                                UTurnSelected = false;
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            }

                        }               // Between crossroads and house exterior SCENE
                        else if (CurrentWaypoint == WaypointList[5])
                        {
                            if (!UTurnSelected)     // Looking towards Dead End area
                            {
                                // Move closer to Dead End
                                CurrentPlayer.transform.position = WaypointList[6].transform.position;
                                CurrentWaypoint = WaypointList[6];
                                //   Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                CanUturn = true;
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = true;
                                CanBackup = false;
                            }
                            else      // Looking back at crossroads
                            {
                                // Move back to crossroads waypoint, initial forward movement no longer controlled here
                                CurrentPlayer.transform.position = WaypointList[3].transform.position;
                                CurrentWaypoint = WaypointList[3];
                                //   Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                CanUturn = false;
                                CanOrbit = true;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;
                                CanBackup = false;

                                UTurnSelected = false;
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            }
                        }               // Between crossroads and deadend
                        else if (CurrentWaypoint == WaypointList[6])
                        {
                            if (!UTurnSelected)     // Looking towards Dead End area
                            {
                                // Move closer to dead end
                                // Forward movement controlled by restriction pane
                                CurrentPlayer.transform.position = WaypointList[7].transform.position;
                                CurrentWaypoint = WaypointList[7];
                                //   Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                CanUturn = true;
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;
                                CanBackup = false;
                            }
                            else    // Looking back towards crossroads
                            {
                                // Move closer to crossroads
                                CurrentPlayer.transform.position = WaypointList[5].transform.position;
                                CurrentWaypoint = WaypointList[5];
                                //   Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                CanUturn = true;
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = true;
                                CanBackup = false;
                            }
                        }               // Between crossroads and deadend
                        // To Dead End controlled by restriction planes
                        else if (CurrentWaypoint == WaypointList[8])
                        {
                            if (!UTurnSelected)     // Looking towards maze
                            {
                                // Move closer to hedge maze
                                // Forward movement controlled by restriction pane
                                CurrentPlayer.transform.position = WaypointList[9].transform.position;
                                CurrentWaypoint = WaypointList[9];
                                //   Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                CanUturn = true;
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;
                                CanBackup = false;
                            }
                            else   // Looking back at crossroads
                            {
                                // Move to crossroads waypoint, initial forward movement no longer controlled here
                                CurrentPlayer.transform.position = WaypointList[3].transform.position;
                                CurrentWaypoint = WaypointList[3];
                                //   Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                CanUturn = false;
                                CanOrbit = true;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;
                                CanBackup = false;

                                UTurnSelected = false;
                                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            }
                        }               // Between crossroads and hedge maze
                        // To Hedge Maze controlled by restriction panes
                        
                        //    CurrentPlayer.transform.position = WaypointList[2].transform.position;
                        //    CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 20f, 0f);
                        //    Camera.main.transform.rotation = Quaternion.Euler(25f, 19f, 0f);
                    }
                }

                if (CurrentCursor == CursorType.TurnAround)
                {
                    MovePlayerUturn();

                    if(CurrentScene.name == "HouseGrounds")
                    {
                        UTurnSelected = !UTurnSelected;
                    }
                }
            }
            else if (CurrentScene.name == "HouseGrounds" && ManagerScript.GroundsFromHouse)
            {
                if (CurrentCursor == CursorType.Forward)
                {
                    if (CanForward)
                    {
                        // THIS NEEDS WORK
                        if (CurrentWaypoint == WaypointList[0])
                        {
                            CurrentPlayer.transform.position = WaypointList[1].transform.position;
                            CurrentWaypoint = WaypointList[1];
                            CanUturn = false;
                            CanOrbit = false;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = true;
                            CanBackup = false;
                        }
                        else if (CurrentWaypoint == WaypointList[1])
                        {
                            CurrentPlayer.transform.position = WaypointList[2].transform.position;
                            CurrentWaypoint = WaypointList[2];
                            //   Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                            CanUturn = false;
                            CanOrbit = false;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = true;
                            CanBackup = false;
                        }
                        else if (CurrentWaypoint == WaypointList[2])
                        {
                            CurrentPlayer.transform.position = WaypointList[3].transform.position;
                            CurrentWaypoint = WaypointList[3];
                            //   Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                            CanUturn = false;
                            CanOrbit = false;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = true;
                            CanBackup = false;
                        }
                        //else if (CurrentWaypoint == WaypointList[1])
                        //{
                        //    CurrentPlayer.transform.position = WaypointList[2].transform.position;
                        //    CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 20f, 0f);
                        //    CurrentWaypoint = WaypointList[2];
                        //    Camera.main.transform.rotation = Quaternion.Euler(25f, 19f, 0f);
                        //}

                    }
                }

                if (CurrentCursor == CursorType.TurnAround)
                {
                    MovePlayerUturn();

                }
            }
        }

        public void MovePlayerUturn()
        {
            CurrentPlayer.transform.Rotate(0, 180, 0);
        }

        public void RotateLeft()
        {
            if (CurrentScene.name == "HouseGrounds")
            {
                CurrentPlayer.transform.Rotate(0, -40, 0);
            }
            else
            {
                CurrentPlayer.transform.Rotate(0, -90, 0);
            }
        }

        public void RotateRight()
        {
            if (CurrentScene.name == "HouseGrounds")
            {
                CurrentPlayer.transform.Rotate(0, 40, 0);
            }
            else
            {
                CurrentPlayer.transform.Rotate(0, 90, 0);
            }
        }

        public void FindCharacter()
        {
            if (ManagerScript != null && ManagerScript.CurrentPlayer != null)
            {
                if (ManagerScript.CurrentPlayer.PlayerCharacter == Character.Alex)
                {
                    CurrentPlayer = GameObject.FindGameObjectWithTag("PlayerAlex");
                }
                else if (ManagerScript.CurrentPlayer.PlayerCharacter == Character.Anne)
                {
                    CurrentPlayer = GameObject.FindGameObjectWithTag("PlayerAnne");
                }
            }
            else
            {


            }
        }
    }
}