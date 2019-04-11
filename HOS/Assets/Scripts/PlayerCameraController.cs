using System.Collections;
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
                else if (CurrentWaypoint == WaypointList[2])     // By gate
                {
                    //CanUturn = false;
                    //CanOrbit = true;
                    //CanLeftTurn = false;
                    //CanRightTurn = false;
                    //CanForward = false;
                    //CanBackup = false;
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
        }

        public void MovePlayerUturn()
        {
            CurrentPlayer.transform.Rotate(0, 180, 0);
        }

        public void RotateLeft()
        {
            CurrentPlayer.transform.Rotate(0, -90, 0);
        }

        public void RotateRight()
        {
            CurrentPlayer.transform.Rotate(0, 90, 0);
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