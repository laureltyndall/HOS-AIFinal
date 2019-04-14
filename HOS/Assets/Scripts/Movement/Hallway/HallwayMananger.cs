using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class HallwayMananger : MonoBehaviour
    {
        public bool LightsOn = false;
        public bool HaveList = false;
        public Text TextArea;
        public bool GhostSeen = false;
        public bool GhostAttacking = false;
        public GameObject Ghost;
        private float GhostActiveCounter = 3f;
        public GameObject List;
        public PlayerCameraController MovementScript;
        public GameManager ManagerScript;
        public bool ManagerFound = false;

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
                if(ManagerScript.InteriorGhostSeen)
                {
                    GhostSeen = true;
                    HaveList = true;
                    List.SetActive(false);
                }

                if(!GhostSeen && ManagerScript.HallfromOutside & !HaveList)
                {
                    TextArea.text = "Hello? " + MovementScript.SiblingName + "?";
                }

                if (!LightsOn && GhostSeen && ManagerScript.HallfromOutside)
                {
                    TextArea.text = "Maybe if I turn the lights on, this place wouldn't be so creepy.";
                }

                if (HaveList && !GhostSeen && ManagerScript.HallFromRoom)
                {
                    Ghost.SetActive(true);
                    TextArea.text = "*Gasp!";

                    if (GhostActiveCounter <= 0)
                    {
                        Ghost.SetActive(false);
                        GhostSeen = true;
                        TextArea.text = "I need to get out of here!";

                        // Run Out
                    }
                    else if (GhostActiveCounter <= 1)
                    {
                        TextArea.text = "What IS that?!";
                    }
                    else
                    {
                        GhostActiveCounter -= Time.deltaTime;
                    }

                }

                if(HaveList && MovementScript.CurrentWaypoint == MovementScript.WaypointList[2])
                {
                    List.SetActive(false);
                }
            }
        }

        public void TurnOffNote()
        {
            // Turn on music
            TextArea.text = "Where's that music coming from?";

            HaveList = true;

            MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[1].transform.position;
            MovementScript.CurrentPlayer.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            Camera.main.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            MovementScript.CurrentWaypoint = MovementScript.WaypointList[1];
            MovementScript.CanUturn = false;
            MovementScript.CanOrbit = true;
            MovementScript.CanLeftTurn = false;
            MovementScript.CanRightTurn = false;
            MovementScript.CanForward = false;
            MovementScript.CanBackup = false;
        }
    }
}