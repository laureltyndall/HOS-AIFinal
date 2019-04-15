using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class PassageManager : MonoBehaviour
    {
        private PlayerCameraController MovementScript;
        public Text TextArea;
        public GameObject Ghost;
        public GameObject DeathGhost;
        private GameObject Twin;
        private Animator TwinAnimation;
        public GameObject GOPanel;
        public MenuManager Controller;

        public bool TwinFree = false;
        public bool GhostChasing = false;
        public bool GhostOn = false;
        public bool FoundTwin = false;
        private bool NamedTwin = false;
        private bool TwinWaypointsFound = false;
        public bool WrongPath = false;
        public bool RightPath = false;
        private bool Dead = false;
        private bool GORun = false;
        public bool Talking = false;

        private float DeathGhostCounter = 1f;

        public List<GameObject> TwinWaypointList = new List<GameObject>();

        // Use this for initialization
        void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
            MovementScript = go.GetComponent<PlayerCameraController>();

            GameObject TempObj = GameObject.FindGameObjectWithTag("TwinWaypoints");
            TwinWaypointList = new List<GameObject>();
            foreach (Transform t in TempObj.transform)
            {
                TwinWaypointList.Add(t.gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (NamedTwin)
            {
                if (!Dead)
                {
                    if (!Talking)
                    {
                        if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[1])
                        {
                            TextArea.text = "";
                        }

                        if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[14])
                        {
                            TextArea.text = MovementScript.SiblingName + ": 'Which way should we go, " + MovementScript.PlayerName + "? The door or the stairs?";
                        }
                        if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[15] || MovementScript.CurrentWaypoint == MovementScript.WaypointList[18])
                        {
                            TextArea.text = "";
                        }
                        if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[17])
                        {
                            TextArea.text = "*Gasp* \n " + MovementScript.SiblingName + ": 'Oh no! It's caught us!";
                            DeathGhost.SetActive(true);
                            if (DeathGhostCounter <= 0)
                            {
                                Dead = true;
                            }
                            else
                            {
                                DeathGhostCounter -= Time.deltaTime;
                            }
                        }
                        if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[24])
                        {
                            TextArea.text = MovementScript.SiblingName + ": 'Try the door, " + MovementScript.PlayerName + "! Quick!";
                        }

                        if (FoundTwin && MovementScript.CurrentWaypoint == MovementScript.WaypointList[3])
                        {
                            // Run Dialogue Cutscene
                            //TwinAnimation.SetBool("Talking", true);

                            // Move twin to their first position
                            TwinFree = true;
                        }

                        if (TwinFree && !GhostChasing)
                        {
                            MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[2].transform.position;
                            MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 190f, 0f);
                            //    Camera.main.transform.rotation = Quaternion.Euler(45f, -160f, 0f);
                            MovementScript.CurrentWaypoint = MovementScript.WaypointList[2];
                            MovementScript.CanUturn = false;
                            MovementScript.CanOrbit = true;
                            MovementScript.CanLeftTurn = false;
                            MovementScript.CanRightTurn = false;
                            MovementScript.CanForward = false;
                            MovementScript.CanBackup = false;

                            TwinAnimation.SetBool("Talking", false);
                            TwinAnimation.SetBool("Scared", true);
                            // Turn on Ghost
                            Ghost.SetActive(true);
                            GhostOn = true;

                            // Have twin instruct to start running and that you need to find another way out

                            GhostChasing = true;
                        }

                        if (GhostChasing && GhostOn)
                        {
                            UpdateGhostPosition();
                            UpdateTwinPosition();
                        }
                    }
                    else
                    {
                        //Talking
                    }
                }
                else
                {
                    if (!GORun)
                    {
                        // DEAD
                        Ghost.transform.position = MovementScript.WaypointList[0].transform.position;
                        Ghost.transform.rotation = Quaternion.Euler(0f, 21.3f, 0f);
                        DeathGhost.SetActive(false);
                        Controller.ShowGameOver(GOPanel);
                        GORun = true;
                    }
                }
            }
            else
            {
                if(MovementScript.PlayerName == "Anne")
                {
                    Twin = GameObject.FindGameObjectWithTag("SiblingAlex");
                    TwinAnimation = Twin.GetComponent<Animator>();
                    GameObject go = GameObject.FindGameObjectWithTag("SiblingAnne");
                    go.SetActive(false);
                    NamedTwin = true;
                }
                else if(MovementScript.PlayerName == "Alex")
                {
                    Twin = GameObject.FindGameObjectWithTag("SiblingAnne");
                    TwinAnimation = Twin.GetComponent<Animator>();
                    GameObject go = GameObject.FindGameObjectWithTag("SiblingAlex");
                    go.SetActive(false);
                    NamedTwin = true;
                }
                else
                {
                    NamedTwin = false;
                }
            }
        }

        void UpdateGhostPosition()
        {
            if(MovementScript.CurrentWaypoint == MovementScript.WaypointList[5])
            {            
                // Constantly Move ghost to always be one movement script waypoint list behind the twins
                // If possible, always have it moving towards their current position with the animator
                Ghost.transform.position = MovementScript.WaypointList[2].transform.position;
                Ghost.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            }
            else if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[7])
            {
                Ghost.transform.position = MovementScript.WaypointList[5].transform.position;
                Ghost.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[10])
            {
                Ghost.transform.position = MovementScript.WaypointList[7].transform.position;
            //    Ghost.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            }
            else if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[14])
            {
                Ghost.transform.position = MovementScript.WaypointList[12].transform.position;
                Ghost.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[24])
            {
                Ghost.transform.position = MovementScript.WaypointList[19].transform.position;
                Ghost.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            }
        }

        void UpdateTwinPosition()
        {
            if (TwinFree)
            {
                // Set up twin waypoints at rotation waypoints - 2, 5,7, 10, 14, 17, 24
                // Move twin there if player is on that waypoint
                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[2])
                {
                    Twin.transform.position = TwinWaypointList[0].transform.position;
                }
                else if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[5])
                {
                    TwinAnimation.SetBool("Scared", false);
                    Twin.transform.position = TwinWaypointList[1].transform.position;
                }
                else if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[7])
                {
                    Twin.transform.position = TwinWaypointList[2].transform.position;
                    //            MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
                }
                else if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[10])
                {
                    Twin.transform.position = TwinWaypointList[3].transform.position;
                    //        MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
                }
                else if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[14])
                {
                    Twin.transform.position = TwinWaypointList[4].transform.position;
                    //        MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
                }
                else if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[17])
                {
                    Twin.transform.position = TwinWaypointList[5].transform.position;
                    //        MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
                }
                else if(MovementScript.CurrentWaypoint == MovementScript.WaypointList[24])
                {
                    Twin.transform.position = TwinWaypointList[6].transform.position;
                    //        MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
                }
            }
        }

        public void ExitChase()
        {
            
        }

        public void RestartChase()
        {
            Dead = false;
            GORun = false;
            //  GhostChasing = true;
            GhostChasing = false;
            TextArea.text = MovementScript.SiblingName + ": 'It's here! We need to run!'";
        }
    }
}