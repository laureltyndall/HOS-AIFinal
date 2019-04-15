using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        public bool InteriorGhost = false;
        public Text TextArea;
        public bool LRMniGameFin = false;
        public bool CenterGameFin = false;

        public string PlayerName;
        public string SiblingName;
        public string pronoun;
        public bool TurnOffCloseup = false;

        public bool CanUturn = false;
        public bool CanOrbit = false;
        public bool CanLeftTurn = false;
        public bool CanRightTurn = false;
        public bool CanForward = false;
        public bool CanBackup = false;

        public AudioSource Footstep;

        // Use this for initialization
        void Start()
        {
            FindWaypointList();
            CurrentScene = SceneManager.GetActiveScene();
            GameObject GO = GameObject.FindGameObjectWithTag("GameController");
            ManagerScript = GO.GetComponent<GameManager>();
            MainCamera = Camera.main;
            //FindCharacter();
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
                        pronoun = "she";
                    }
                    else if (CurrentPlayer.tag == "PlayerAnne")
                    {
                        PlayerName = "Anne";
                        SiblingName = "Alex";
                        pronoun = "he";
                    }

                    if (CurrentScene.name == "Intro")
                    {
                        MainCamera = Camera.main;
                        CurrentPlayer.transform.position = WaypointList[0].transform.position;
                        CurrentWaypoint = WaypointList[0];
                        CanUturn = true;
                        CanForward = true;
                    }
                    else if (CurrentScene.name == "Gate Scene")
                    {
                        MainCamera = Camera.main;
                        CurrentPlayer.transform.position = WaypointList[0].transform.position;
                        CurrentWaypoint = WaypointList[0];
                        CanUturn = true;
                        CanForward = true;
                    }
                    else if (CurrentScene.name == "HouseGrounds")
                    {
                        if (ManagerScript.GroundsFromGate)
                        {
                            MainCamera = Camera.main;
                            CurrentPlayer.transform.position = WaypointList[0].transform.position;
                            CurrentWaypoint = WaypointList[0];
                            CanUturn = true;
                            CanForward = true;
                            TextArea.text = "Well, this certainly isn't what I expected.";
                        }
                        else if (ManagerScript.GroundsFromHouse)
                        {
                            MainCamera = Camera.main;
                            CurrentPlayer.transform.position = WaypointList[4].transform.position;
                            CurrentWaypoint = WaypointList[4];
                            MovePlayerUturn();
                            // Turn the player around
                            CanUturn = true;
                            CanForward = true;
                            UTurnSelected = true;
                        }
                    }
                    else if(CurrentScene.name == "HouseExterior")
                    {
                        if (ManagerScript.HouseFromGrounds)
                        {
                            MainCamera = Camera.main;
                            CurrentPlayer.transform.position = WaypointList[0].transform.position;
                            CurrentWaypoint = WaypointList[0];
                            CanUturn = true;
                            CanForward = true;
                            TextArea.text = "Wow! I didn't picture " + SiblingName + " as the Gothic type. This place is kind of creepy.";
                        }
                        else if (ManagerScript.HousefromInside)
                        {
                            MainCamera = Camera.main;
                            CurrentPlayer.transform.position = WaypointList[2].transform.position;
                            CurrentWaypoint = WaypointList[2];
                            MovePlayerUturn();
                            // Turn the player around
                            CanUturn = true;
                            CanForward = false;
                            CanOrbit = true;
                            UTurnSelected = true;
                        }
                    }
                    else if (CurrentScene.name == "HouseHallWay")
                    {
                        if (ManagerScript.HallfromOutside)
                        {
                            MainCamera = Camera.main;
                            CurrentPlayer.transform.position = WaypointList[0].transform.position;
                            CurrentWaypoint = WaypointList[0];
                            CanUturn = true;
                            CanForward = true;
                            CanOrbit = false;
                        }
                        else if(ManagerScript.HallFromRoom && !ManagerScript.InteriorGhostSeen)
                        {
                            MainCamera = Camera.main;
                            CurrentPlayer.transform.position = WaypointList[3].transform.position;
                            CurrentWaypoint = WaypointList[3];
                            CanUturn = false;
                            CanForward = false;
                            CanOrbit = true;
                        }
                        else if (ManagerScript.HallFromRoom && ManagerScript.InteriorGhostSeen)
                        {
                            MainCamera = Camera.main;
                            CurrentPlayer.transform.position = WaypointList[3].transform.position;
                            CurrentWaypoint = WaypointList[3];
                        }
                    }
                    else if (CurrentScene.name == "Kitchen")
                    {
                        if (ManagerScript.KitchenFromHall)
                        {
                            MainCamera = Camera.main;
                            CurrentPlayer.transform.position = WaypointList[0].transform.position;
                            CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 146.75f, 0f);
                            CurrentWaypoint = WaypointList[0];
                            CanUturn = false;
                            CanForward = false;
                            CanOrbit = true;
                            TextArea.text = "I wonder why " + SiblingName + " would leave the radio on if " + pronoun + " left the house.";
                        }
                        else if (ManagerScript.KitchenFromGame)
                        {
                            MainCamera = Camera.main;
                            CurrentPlayer.transform.position = WaypointList[4].transform.position;
                            CurrentWaypoint = WaypointList[4];
                            CanUturn = true;
                            CanForward = false;
                            CanOrbit = true;
                            UTurnSelected = false;
                        }
                    }
                    else if (CurrentScene.name == "Living Room")
                    {
                        if (ManagerScript.LRFromHall)
                        {
                            MainCamera = Camera.main;
                            CurrentPlayer.transform.position = WaypointList[0].transform.position;
                            CurrentWaypoint = WaypointList[0];
                            CanUturn = false;
                            CanForward = false;
                            CanOrbit = true;
                        }
                        else if (ManagerScript.LRFromGame)
                        {
                            MainCamera = Camera.main;
                            CurrentPlayer.transform.position = WaypointList[4].transform.position;
                            CurrentWaypoint = WaypointList[4];
                            CanUturn = false;
                            CanForward = false;
                            CanOrbit = true;
                            LRMniGameFin = true;
                        }
                        else if(ManagerScript.LRFromUnderground)
                        {
                            MainCamera = Camera.main;
                            CurrentPlayer.transform.position = WaypointList[3].transform.position;
                            CurrentWaypoint = WaypointList[3];
                            MovePlayerUturn();
                            UTurnSelected = true;
                            CanUturn = true;
                            CanForward = true;
                            CanOrbit = false;
                            LRMniGameFin = true;
                        }
                    }
                    else if (CurrentScene.name == "HedgeMazeCenter")
                    {
                        if (ManagerScript.CenterFromMaze)
                        {
                            MainCamera = Camera.main;
                            CurrentPlayer.transform.position = WaypointList[0].transform.position;
                            CurrentWaypoint = WaypointList[0];
                            CanUturn = true;
                            CanForward = true;
                            CanOrbit = false;
                        }
                        else if (ManagerScript.CenterFromGame)
                        {
                            MainCamera = Camera.main;
                            CurrentPlayer.transform.position = WaypointList[1].transform.position;
                            CurrentWaypoint = WaypointList[1];
                            CanUturn = false;
                            CanForward = true;
                            CanOrbit = false;
                            UTurnSelected = false;
                            CenterGameFin = true;
                        }
                    }
                    else if (CurrentScene.name == "Underground Passage")
                    {
                        MainCamera = Camera.main;
                        CurrentPlayer.transform.position = WaypointList[0].transform.position;
                        CurrentWaypoint = WaypointList[0];
                        CanUturn = true;
                        CanForward = true;
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
            else if(CurrentScene.name == "HouseGrounds")
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
                if(CurrentWaypoint == WaypointList[4])
                {
                    if (!UTurnSelected)      // Looking at house
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
                else if(CurrentWaypoint == WaypointList[7])
                {
                    if (!UTurnSelected)      // Looking at dead end
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
                else if (CurrentWaypoint == WaypointList[9])
                {
                    if (!UTurnSelected)      // Looking at hedge maze
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
            else if (CurrentScene.name == "Kitchen")
            {
                if(CurrentWaypoint == WaypointList[4])
                {
                    UTurnSelected = false;
                }
            }
            else if (CurrentScene.name == "HedgeMazeCenter")
            {
                if (CurrentWaypoint == WaypointList[2])     // Near fountain
                {
                    if (UTurnSelected)      // Looking at maze entrance
                    {
                        CanUturn = true;
                        CanOrbit = false;
                        CanLeftTurn = false;
                        CanRightTurn = false;
                        CanForward = true;
                        CanBackup = false;
                    }
                    else    // Looking at fountain
                    {
                        CanUturn = true;
                        CanOrbit = false;
                        CanLeftTurn = false;
                        CanRightTurn = false;
                        CanForward = false;
                        CanBackup = false;
                    }
                }
                if (CurrentWaypoint == WaypointList[3])
                {
                    if (!UTurnSelected)      // Looking at puzzle
                    {
                        CanUturn = true;
                        CanOrbit = false;
                        CanLeftTurn = false;
                        CanRightTurn = false;
                        CanForward = false;
                        CanBackup = false;
                    }
                    else    // Looking at maze entrance
                    {
                        CanUturn = true;
                        CanOrbit = false;
                        CanLeftTurn = false;
                        CanRightTurn = false;
                        CanForward = true;
                        CanBackup = false;
                    }
                }
                if (CurrentWaypoint == WaypointList[4])
                {
                    if (!UTurnSelected)      // Looking at rock
                    {
                        CanUturn = true;
                        CanOrbit = false;
                        CanLeftTurn = false;
                        CanRightTurn = false;
                        CanForward = false;
                        CanBackup = false;
                    }
                    else    // Looking at maze entrance
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
            else if (CurrentScene.name == "Underground Passage")
            {
                if(CurrentWaypoint == WaypointList[2] || CurrentWaypoint == WaypointList[5] || CurrentWaypoint == WaypointList[7] || CurrentWaypoint == WaypointList[10] || CurrentWaypoint == WaypointList[14] || CurrentWaypoint == WaypointList[24])
                {
                    CanUturn = false;
                    CanForward = false;
                    CanOrbit = true;
                }
                
            }

            if (ManagerScript != null)
            {
                if(ManagerScript.InteriorGhostSeen)
                {
                    InteriorGhost = true;
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
                            CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                            Camera.main.transform.rotation = Quaternion.Euler(0f, 180, 0f);

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
                            CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                            Camera.main.transform.rotation = Quaternion.Euler(0f, 180, 0f);

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
            else if (CurrentScene.name == "HouseGrounds")
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

                                TextArea.text = "";
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
                                TextArea.text = "This place is huge! I wonder how " + SiblingName + " found it?";
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
                            if (!UTurnSelected)     // Looking at HOUSE, controlled by restriction pane
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
                            TextArea.text = "";

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
                            TextArea.text = "";

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
                        else if (CurrentWaypoint == WaypointList[7])
                        {
                            if (!UTurnSelected)     // Looking at DEAD END, controlled by restriction pane
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
                                CurrentPlayer.transform.position = WaypointList[6].transform.position;
                                CurrentWaypoint = WaypointList[6];

                                CanUturn = true;        // Uturn able to turn on
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = true;      // able to move forward
                                CanBackup = false;

                                TextArea.text = "";
                            }
                        }               // Dead End
                        else if (CurrentWaypoint == WaypointList[8])
                        {
                            TextArea.text = "";

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

                                TextArea.text = "Is that a  - hedge maze? I honestly can't decide if that's weird or awesome.";
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
                        else if (CurrentWaypoint == WaypointList[9])
                        {
                            if (!UTurnSelected)     // Looking at HEDGE MAZE, controlled by restriction pane
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
                                CurrentPlayer.transform.position = WaypointList[8].transform.position;
                                CurrentWaypoint = WaypointList[8];

                                CanUturn = true;        // Uturn able to turn on
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = true;      // able to move forward
                                CanBackup = false;

                                TextArea.text = "";
                            }
                        }               // Hedge Maze Entrance


                        //    CurrentPlayer.transform.position = WaypointList[2].transform.position;
                        //    CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 20f, 0f);
                        //    Camera.main.transform.rotation = Quaternion.Euler(25f, 19f, 0f);
                    }
                }

                if (CurrentCursor == CursorType.TurnAround)
                {
                    MovePlayerUturn();

                    if (CurrentScene.name == "HouseGrounds")
                    {
                        UTurnSelected = !UTurnSelected;
                    }
                }
            }
            else if (CurrentScene.name == "HouseExterior")
            {
                if (CurrentCursor == CursorType.Forward)
                {
                    if (CanForward)
                    {
                        if (CurrentWaypoint == WaypointList[0])     // By grounds
                        {
                            if (UTurnSelected)     // Looking at grounds, controlled by restriction pane
                            {
                                // Do not move, only look at grounds.
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
                                if (!ManagerScript.ExteriorGhostSeen)        // If we haven't seen the ghost tree cutscene yet
                                {
                                    // Move to next waypoint between gate and crossroads
                                    CurrentPlayer.transform.position = WaypointList[1].transform.position;
                                    CurrentWaypoint = WaypointList[1];

                                    CanUturn = false;
                                    CanOrbit = false;
                                    CanLeftTurn = false;
                                    CanRightTurn = false;
                                    CanForward = false;
                                    CanBackup = false;

                                    TextArea.text = "";
                                }
                                else
                                {
                                    // Move to next waypoint by the door
                                    CurrentPlayer.transform.position = WaypointList[2].transform.position;
                                    CurrentWaypoint = WaypointList[2];
                                    //   Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                    CanUturn = false;
                                    CanOrbit = true;
                                    CanLeftTurn = false;
                                    CanRightTurn = false;
                                    CanForward = false;
                                    CanBackup = false;
                                }

                            }
                        }                   // By Grounds
                        else if (CurrentWaypoint == WaypointList[1])
                        {
                            // Run the cutscene
                        }               // By Dead Tree

                        // Door Area movement controlled by restriction panes
                        else if (CurrentWaypoint == WaypointList[3])
                        {
                            TextArea.text = "";
                            if (!UTurnSelected)     // Looking at Backyard
                            {
                                CurrentPlayer.transform.position = WaypointList[4].transform.position;
                                CurrentWaypoint = WaypointList[4];
                                // Move to the next exploration waypoint
                                CanUturn = true;        // Uturn able to turn on
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = true;      // forward able to 
                                CanBackup = false;
                            }
                            else    // Looking towards door
                            {
                                // Move back to door waypoint, initial forward movement no longer controlled here
                                CurrentPlayer.transform.position = WaypointList[2].transform.position;
                                CurrentWaypoint = WaypointList[2];
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

                        }               // Porch exploring section 1
                        else if (CurrentWaypoint == WaypointList[4])
                        {
                            TextArea.text = "";
                            if (!UTurnSelected)     // Looking at backyard, controlled by restriction pane
                            {
                                // Do not move, only look at grounds.
                                // Foward movement controlled by restirction pane
                                CanUturn = true;        // Uturn able to turn on
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;      // forward able to 
                                CanBackup = false;
                            }
                            else    // Looking towards door, controlled by this
                            {

                                // Move to next waypoint between gate and crossroads
                                CurrentPlayer.transform.position = WaypointList[3].transform.position;
                                CurrentWaypoint = WaypointList[3];

                                CanUturn = false;
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;
                                CanBackup = false;

                                TextArea.text = "";
                            }
                        }               // Porch exploring section 2

                        //    CurrentPlayer.transform.position = WaypointList[2].transform.position;
                        //    CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 20f, 0f);
                        //    Camera.main.transform.rotation = Quaternion.Euler(25f, 19f, 0f);
                    }
                }

                if (CurrentCursor == CursorType.TurnAround)
                {
                    MovePlayerUturn();

                    if (CurrentScene.name == "HouseExterior")
                    {
                        UTurnSelected = !UTurnSelected;
                    }
                }
            }
            else if (CurrentScene.name == "HouseHallWay")
            {
                if (CurrentCursor == CursorType.Forward)
                {
                    if (CanForward)
                    {
                        if (CurrentWaypoint == WaypointList[0])
                        {
                            if (!UTurnSelected)
                            {
                                CurrentPlayer.transform.position = WaypointList[1].transform.position;
                                CurrentWaypoint = WaypointList[1];
                                CanUturn = false;
                                CanOrbit = true;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;
                                CanBackup = false;
                            }
                            else
                            {
                                CanUturn = true;        // Uturn able to turn on
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;      // forward able to 
                                CanBackup = false;
                            }
                        }
                    }
                }

                if (CurrentCursor == CursorType.TurnAround)
                {
                    MovePlayerUturn();
                    UTurnSelected = true;
                }
            }
            else if (CurrentScene.name == "Kitchen")
            {
                if (CurrentCursor == CursorType.Forward)
                {
                    if (CanForward)
                    {
                        if (CurrentWaypoint == WaypointList[2])
                        {
                            if (!UTurnSelected)     // Looking towards fridge
                            {
                                // Move to next waypoint between door and fridge
                                CurrentPlayer.transform.position = WaypointList[3].transform.position;
                                CurrentWaypoint = WaypointList[3];
                                //   Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                CanUturn = true;
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = true;
                                CanBackup = false;
                            }
                            else     // Looking towards door
                            {
                                // Move to previous waypoint closer to door
                                CurrentPlayer.transform.position = WaypointList[0].transform.position;
                                //CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 20f, 0f);
                                CurrentWaypoint = WaypointList[0];
                                //   Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                CanUturn = false;
                                CanOrbit = true;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;
                                CanBackup = false;
                            }
                        }               // Between gate and crossroads
                        else if (CurrentWaypoint == WaypointList[3])
                        {

                            if (!UTurnSelected)     // Looking towards fridge
                            {
                                // Move to counter area waypoint, initial forward movement no longer controlled here
                                CurrentPlayer.transform.position = WaypointList[4].transform.position;
                                CurrentWaypoint = WaypointList[4];
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
                        }               // Between gate and crossroads
                                        // Counter Area movement controlled by separate script
                        else if (CurrentWaypoint == WaypointList[1])
                        {
                            if (!UTurnSelected)     // Looking at Box Counter, controlled by box script
                            {
                                // Do not move, only look at box.
                                // Foward movement controlled by restriction pane
                                CanUturn = true;        // Uturn able to turn on
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;      // forward able to 
                                CanBackup = false;
                            }
                            else    // Looking towards door, controlled by this
                            {
                                // Move back to crossroads waypoint, initial forward movement no longer controlled here
                                CurrentPlayer.transform.position = WaypointList[0].transform.position;
                                //      CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 146.75f, 0f);
                                CurrentWaypoint = WaypointList[0];
                                //    Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                CanUturn = false;
                                CanOrbit = true;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;
                                CanBackup = false;

                                UTurnSelected = false;
                            }

                        }               // By box counter

                        //    CurrentPlayer.transform.position = WaypointList[2].transform.position;
                        //    CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 20f, 0f);
                        //    Camera.main.transform.rotation = Quaternion.Euler(25f, 19f, 0f);
                    }
                }
            

                if (CurrentCursor == CursorType.TurnAround)
                {
                    MovePlayerUturn();

                    if (CurrentScene.name == "Kitchen")
                    {
                        UTurnSelected = !UTurnSelected;

                        if(CurrentWaypoint == WaypointList[1])
                        {
                            Camera.main.transform.rotation = Quaternion.Euler(0f, 77f, 0f);
                            TextArea.text = "";
                        }
                    }
                }

                if(CurrentCursor == CursorType.Backup)
                {
                    if (CurrentWaypoint == WaypointList[4])
                    {
                        TurnOffCloseup = true;
                    }
                }
            }
            else if (CurrentScene.name == "Living Room")
            {
                if (CurrentCursor == CursorType.Forward)
                {
                    if (CanForward)
                    {
                        if (CurrentWaypoint == WaypointList[1])
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
                        else if (CurrentWaypoint == WaypointList[1])
                        {
                            if (!UTurnSelected)         // Looking at door
                            {
                                CurrentPlayer.transform.position = WaypointList[0].transform.position;
                                CurrentWaypoint = WaypointList[0];
                                CanUturn = false;
                                CanOrbit = true;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;
                                CanBackup = false;
                            }
                            else
                            {
                                // Looking at midroom
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
                        else if (CurrentWaypoint == WaypointList[3])
                        {
                            if (!UTurnSelected)         // Looking at fireplace
                            {
                                CanUturn = true;
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;
                                CanBackup = false;
                            }
                            else
                            {
                                // Looking at midroom
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
            else if (CurrentScene.name == "HedgeMazeCenter")
            {
                if (CurrentCursor == CursorType.Forward)
                {
                    if (CanForward)
                    {
                        if (CurrentWaypoint == WaypointList[0])
                        {
                            if (!CenterGameFin)
                            {
                                if (!UTurnSelected)         // Looking at Fountain
                                {
                                    CurrentPlayer.transform.position = WaypointList[1].transform.position;
                                    CurrentWaypoint = WaypointList[1];
                                    CanUturn = false;
                                    CanOrbit = true;
                                    CanLeftTurn = false;
                                    CanRightTurn = false;
                                    CanForward = false;
                                    CanBackup = false;
                                    UTurnSelected = false;
                                }
                                else
                                {
                                    // Looking at Exit to maze - controlled by restriction script
                                    CanUturn = true;
                                    CanOrbit = false;
                                    CanLeftTurn = false;
                                    CanRightTurn = false;
                                    CanForward = false;
                                    CanBackup = false;
                                }
                            }
                            else
                            {
                                CurrentPlayer.transform.position = WaypointList[2].transform.position;
                                CurrentWaypoint = WaypointList[2];
                                CanUturn = false;
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = true;
                                CanBackup = false;
                                UTurnSelected = false;
                            }
                        } // By maze entrance
                        if (CurrentWaypoint == WaypointList[1])
                        {
                            if (CenterGameFin)
                            {
                                SceneManager.LoadScene("Underground Passage");
                            }
                        } // By maze entrance
                        // Waypoint 1 between maze entrance and fountain controlled by panes
                        else if (CurrentWaypoint == WaypointList[2])
                        {
                            if (CenterGameFin)
                            {
                                SceneManager.LoadScene("Underground Passage");
                            }
                            else
                            {
                                if (!UTurnSelected)         // Looking at fountain
                                {
                                    CanUturn = true;
                                    CanOrbit = false;
                                    CanLeftTurn = false;
                                    CanRightTurn = false;
                                    CanForward = false;
                                    CanBackup = false;
                                }
                                else
                                {
                                    // Looking at maze entrance
                                    CurrentPlayer.transform.position = WaypointList[1].transform.position;
                                    CurrentWaypoint = WaypointList[1];
                                    CanUturn = false;
                                    CanOrbit = true;
                                    CanLeftTurn = false;
                                    CanRightTurn = false;
                                    CanForward = false;
                                    CanBackup = false;
                                    UTurnSelected = false;
                                }
                            }
                        } // Up on fountain base
                        else if (CurrentWaypoint == WaypointList[3])
                        {
                            if (!UTurnSelected)         // Looking at puzzle
                            {
                                CanUturn = true;
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;
                                CanBackup = false;
                            }
                            else
                            {
                                // Looking at maze entrance
                                CurrentPlayer.transform.position = WaypointList[1].transform.position;
                                CurrentWaypoint = WaypointList[1];
                                CanUturn = false;
                                CanOrbit = true;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;
                                CanBackup = false;
                                UTurnSelected = false;
                            }
                        } // By puzzle
                        else if (CurrentWaypoint == WaypointList[4])
                        {
                            if (!UTurnSelected)         // Looking at bushes
                            {
                                CanUturn = true;
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;
                                CanBackup = false;
                            }
                            else
                            {
                                // Looking at maze entrance
                                CurrentPlayer.transform.position = WaypointList[1].transform.position;
                                CurrentWaypoint = WaypointList[1];
                                CanUturn = false;
                                CanOrbit = true;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;
                                CanBackup = false;
                                UTurnSelected = false;
                            }
                        } // By rock bushes
                    }
                }

                if (CurrentCursor == CursorType.TurnAround)
                {
                    MovePlayerUturn();
                    if (CurrentScene.name == "HedgeMazeCenter")
                    {
                        UTurnSelected = !UTurnSelected;

                        if (CurrentWaypoint == WaypointList[3])
                        {
                              Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                            //Camera.main.transform.Rotate(40f, -175f, 0);
                        }
                        if(CurrentWaypoint == WaypointList[4])
                        {
                            Camera.main.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                        }
                    }
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
            else if (CurrentScene.name == "Underground Passage")
            {
                if (CurrentCursor == CursorType.Forward)
                {
                    if (CanForward)
                    {
                        if (CurrentWaypoint == WaypointList[0])
                        {
                            // By Entrance. Forward and Uturn
                            if (UTurnSelected)
                            {
                                // Looking at stairs up, controlled by restriction pane
                                CanUturn = true;
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = false;
                                CanBackup = false;
                            }
                            else
                            {
                                // Move to the next waypoint, can no longer go back
                                CurrentPlayer.transform.position = WaypointList[1].transform.position;
                                CurrentWaypoint = WaypointList[1];
                                CanUturn = false;
                                CanOrbit = false;
                                CanLeftTurn = false;
                                CanRightTurn = false;
                                CanForward = true;      // Can ONLY forward
                                CanBackup = false;
                            }
                        }   // By Entrance, move only to WP1
                        else if (CurrentWaypoint == WaypointList[1])
                        {
                            CurrentPlayer.transform.position = WaypointList[2].transform.position;
                            CurrentWaypoint = WaypointList[2];
                            CanUturn = false;
                            CanOrbit = true;            // Movement controlled by panes
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = false;
                            CanBackup = false;
                        }   // Between Entrance and Cell, can only move forward to WP2
                        // Waypoint 2 controlled by movement panes
                        // Waypoint 3 - By cell - controlled by scene's manager
                        else if (CurrentWaypoint == WaypointList[4])
                        {
                            CurrentPlayer.transform.position = WaypointList[5].transform.position;
                            CurrentWaypoint = WaypointList[5];
                            CanUturn = false;
                            CanOrbit = true;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = false;
                            CanBackup = false;
                        }   // On Path
                        // Waypoint 5 controlled by movement pane
                        else if (CurrentWaypoint == WaypointList[6])
                        {
                            CurrentPlayer.transform.position = WaypointList[7].transform.position;
                            CurrentWaypoint = WaypointList[7];
                            CanUturn = false;
                            CanOrbit = true;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = false;
                            CanBackup = false;
                        }   // On Path
                        // Waypoint 7 controlled by movement pane
                        else if (CurrentWaypoint == WaypointList[8])
                        {
                            CurrentPlayer.transform.position = WaypointList[9].transform.position;
                            CurrentWaypoint = WaypointList[9];
                            CanUturn = false;
                            CanOrbit = false;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = true;
                            CanBackup = false;
                        }   // On Path
                        else if (CurrentWaypoint == WaypointList[9])
                        {
                            CurrentPlayer.transform.position = WaypointList[10].transform.position;
                            CurrentWaypoint = WaypointList[10];
                            CanUturn = false;
                            CanOrbit = true;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = false;
                            CanBackup = false;
                        }   // On Path
                        // Waypoint 10 controlled by movement pane
                        else if (CurrentWaypoint == WaypointList[11])
                        {
                            CurrentPlayer.transform.position = WaypointList[12].transform.position;
                            CurrentWaypoint = WaypointList[12];
                            CanUturn = false;
                            CanOrbit = false;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = true;
                            CanBackup = false;
                        }   // On Path
                        else if (CurrentWaypoint == WaypointList[12])
                        {
                            CurrentPlayer.transform.position = WaypointList[13].transform.position;
                            CurrentWaypoint = WaypointList[13];
                            CanUturn = false;
                            CanOrbit = false;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = true;
                            CanBackup = false;
                        }   // On Path
                        else if (CurrentWaypoint == WaypointList[13])
                        {
                            CurrentPlayer.transform.position = WaypointList[14].transform.position;
                            CurrentWaypoint = WaypointList[14];
                            CanUturn = false;
                            CanOrbit = true;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = false;
                            CanBackup = false;
                        }   // On Path
                        // Waypoint 14 controlled by movement panes
                        else if (CurrentWaypoint == WaypointList[15])
                        {
                            CurrentPlayer.transform.position = WaypointList[16].transform.position;
                            CurrentWaypoint = WaypointList[16];
                            CanUturn = false;
                            CanOrbit = false;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = true;
                            CanBackup = false;
                        }   // On Death Path
                        else if (CurrentWaypoint == WaypointList[16])
                        {
                            // 17 Can't move at all, player about to die
                            CurrentPlayer.transform.position = WaypointList[17].transform.position;
                            CurrentWaypoint = WaypointList[17];
                            CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 6f, 0f);
                            CanUturn = false;
                            CanOrbit = false;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = false;
                            CanBackup = false;
                        }   // On Death Path
                        else if (CurrentWaypoint == WaypointList[18])
                        {
                            CurrentPlayer.transform.position = WaypointList[19].transform.position;
                            CurrentWaypoint = WaypointList[19];
                            CanUturn = false;
                            CanOrbit = false;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = true;
                            CanBackup = false;
                        }   // On MiniGame Path
                        else if (CurrentWaypoint == WaypointList[19])
                        {
                            CurrentPlayer.transform.position = WaypointList[20].transform.position;
                            CurrentWaypoint = WaypointList[20];
                            CanUturn = false;
                            CanOrbit = false;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = true;
                            CanBackup = false;
                        }   // On MiniGame Path
                        else if (CurrentWaypoint == WaypointList[20])
                        {
                            CurrentPlayer.transform.position = WaypointList[21].transform.position;
                            CurrentWaypoint = WaypointList[21];
                            CanUturn = false;
                            CanOrbit = false;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = true;
                            CanBackup = false;
                        }   // On MiniGame Path
                        else if (CurrentWaypoint == WaypointList[21])
                        {
                            CurrentPlayer.transform.position = WaypointList[22].transform.position;
                            CurrentWaypoint = WaypointList[22];
                            CanUturn = false;
                            CanOrbit = false;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = true;
                            CanBackup = false;
                        }   // On MiniGame Path
                        else if (CurrentWaypoint == WaypointList[22])
                        {
                            CurrentPlayer.transform.position = WaypointList[23].transform.position;
                            CurrentWaypoint = WaypointList[23];
                            CanUturn = false;
                            CanOrbit = false;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = true;
                            CanBackup = false;
                        }   // On MiniGame Path
                        else if (CurrentWaypoint == WaypointList[23])
                        {
                            CurrentPlayer.transform.position = WaypointList[24].transform.position;
                            CurrentWaypoint = WaypointList[24];
                            CanUturn = false;
                            CanOrbit = true;
                            CanLeftTurn = false;
                            CanRightTurn = false;
                            CanForward = false;
                            CanBackup = false;
                        }   // On MiniGame Path
                        // Waypoint 24 controlled by restrition panes
                    }
                }

                if (CurrentCursor == CursorType.TurnAround)
                {
                    MovePlayerUturn();
                    UTurnSelected = !UTurnSelected;
                }
            }

            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            CurrentCursor = CursorType.Default;

            Footstep.Play();

            //    CurrentPlayer.transform.position = WaypointList[2].transform.position;
            //    CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 20f, 0f);
            //    Camera.main.transform.rotation = Quaternion.Euler(25f, 19f, 0f);
        }

        public void MovePlayerUturn()
        {
            CurrentPlayer.transform.Rotate(0, 180, 0);

        }

        public void RotateLeft()
        {
            CurrentPlayer.transform.Rotate(0, -40, 0);
        }

        public void RotateRight()
        {
            CurrentPlayer.transform.Rotate(0, 40, 0);
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
        }
    }
}