using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HOS
{
    public class CutsceneController : MonoBehaviour
    {

        public GameObject Ghost;
        public PlayerCameraController MovementScript;
        private float BeforeGhostCounter = 2f;
        private float GhostActiveCounter = 2f;
        public float MovementCounter = 1f;
        private float MovementReset = 1f;
        private bool GhostActive = false;
        private bool TimeToMove = false;
        public Text TextArea;
        public int Count = 7;
        public AudioSource Footstep;
        public AudioSource WoodFootstep;
        public AudioSource GhostLaugh;

        // Use this for initialization
        void Start()
        {
            MovementCounter = MovementReset;
        }

        // Update is called once per frame
        void Update()
        {
            if(MovementScript.CurrentWaypoint == MovementScript.WaypointList[1])
            {
                if (!GhostActive)
                {
                    BeforeGhostCounter -= Time.deltaTime;
                    if (BeforeGhostCounter <= 0)
                    {
                        // Lightning Strike
                        Ghost.SetActive(true);
                        GhostActive = true;
                        TextArea.text = "*Gasp!*";
                        GhostLaugh.Play();
                    }
                }
                else
                {
                    GhostActiveCounter -= Time.deltaTime;

                    if(GhostActiveCounter <= 0)
                    {
                        TextArea.text = "What in the-";
                        Ghost.SetActive(false);
                        GhostLaugh.Stop();
                        TimeToMove = true;
                    }
                }
            }
            if (TimeToMove)
            {
                MovementCounter -= Time.deltaTime;
                TextArea.text = "I need to get inside now!";
                if (MovementCounter <= 0)
                {
                    if (Count == 7)
                    {
                        MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[5].transform.position;
                        MovementScript.CurrentWaypoint = MovementScript.WaypointList[5];
                        Footstep.Play();
                    }
                    else if (Count == 6)
                    {
                        MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[6].transform.position;
                        MovementScript.CurrentWaypoint = MovementScript.WaypointList[6];
                        Footstep.Play();
                    }
                    else if (Count == 5)
                    {
                        MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[7].transform.position;
                        MovementScript.CurrentWaypoint = MovementScript.WaypointList[7];
                        Footstep.Play();
                    }
                    else if (Count == 4)
                    {
                        MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[8].transform.position;
                        MovementScript.CurrentWaypoint = MovementScript.WaypointList[8];
                        Footstep.Play();
                    }
                    else if (Count == 3)
                    {
                        MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[9].transform.position;
                        MovementScript.CurrentWaypoint = MovementScript.WaypointList[9];
                        Footstep.Play();
                    }
                    else if (Count == 2)
                    {
                        MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[10].transform.position;
                        MovementScript.CurrentWaypoint = MovementScript.WaypointList[10];
                        Footstep.Play();
                    }
                    else if (Count == 1)
                    {
                        MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[2].transform.position;
                        MovementScript.CurrentWaypoint = MovementScript.WaypointList[2];
                        Camera.main.transform.rotation = Quaternion.Euler(13.028f, -180f, 0f);
                        WoodFootstep.Play();
                    }

                    Count -= 1;
                    MovementCounter = MovementReset;
                }
            }

        }
    }
}