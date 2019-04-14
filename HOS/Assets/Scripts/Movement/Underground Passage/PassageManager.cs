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
        public GameObject Twin;

        public bool TwinFree = false;
        public bool GhostChasing = false;
        public bool FoundTwin = false;
        private bool NamedTwin = false;


        // Use this for initialization
        void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
            MovementScript = go.GetComponent<PlayerCameraController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (NamedTwin)
            {
                if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[1])
                {
                    TextArea.text = "";
                }

                if (FoundTwin && MovementScript.CurrentWaypoint == MovementScript.WaypointList[3])
                {
                    // Run Dialogue Cutscene

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

                    // Turn on Ghost
                    Ghost.SetActive(true);

                    // Have twin instruct to start running and that you need to find another way out

                    GhostChasing = true;
                }

                if (GhostChasing)
                {
                    UpdateGhostPosition();
                    UpdateTwinPosition();
                }
            }
            else
            {
                if(MovementScript.PlayerName == "Anne")
                {
                    Twin = GameObject.FindGameObjectWithTag("SiblingAlex");
                    GameObject go = GameObject.FindGameObjectWithTag("SiblingAnne");
                    go.SetActive(false);
                    NamedTwin = true;
                }
                else if(MovementScript.PlayerName == "Alex")
                {
                    Twin = GameObject.FindGameObjectWithTag("SiblingAnne");
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
        }

        void UpdateTwinPosition()
        {
            // Set up twin waypoints at rotation waypoints - 2, 5,7, 10, 14, 17, 24
            // Move twin there if player is on that waypoint
            if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[2])
            {

            }
        }
    }
}