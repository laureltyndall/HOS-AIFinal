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
        public GameObject List;
        public PlayerCameraController MovementScript;
        public GameManager ManagerScript;
        public bool ManagerFound = false;
        public float MovementCounter = 1f;
        private float MovementReset = 1f;

        public GameObject Ghost;
        public bool GhostOn = false;
        public bool GhostInPosition = false;
        public bool TurnLIghtsOn = false;
        
        public bool GhostSeen = false;

        private bool TimeToMove = false;
        public int Count = 3;

        public AudioSource GhostLaugh;
        public AudioSource Footstep;
        public AudioSource DoorOpen;
        public AudioSource PaperCrinkle;

        // Use this for initialization
        void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
            MovementScript = go.GetComponent<PlayerCameraController>();
            MovementCounter = MovementReset;
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

                    if (ManagerScript.HallFromRoom)
                    {
                        TurnLIghtsOn = true;
                    }
                }

                if(!GhostSeen && ManagerScript.HallfromOutside & !HaveList)
                {
                    TextArea.text = "Hello? " + MovementScript.SiblingName + "?";
                }

                if (!LightsOn && ManagerScript.InteriorGhostSeen && ManagerScript.HallfromOutside)
                {
                    TextArea.text = "Maybe if I turn the lights on, this place wouldn't be so creepy.";
                }

                if(HaveList && MovementScript.CurrentWaypoint == MovementScript.WaypointList[2])
                {
                    List.SetActive(false);
                }

                if(TimeToMove)
                {
                    MovementCounter -= Time.deltaTime;
                    if (MovementCounter <= 0)
                    {
                        if (Count == 3)
                        {
                            MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[1].transform.position;
                            MovementScript.CurrentWaypoint = MovementScript.WaypointList[1];
                            Footstep.Play();
                        }
                        else if (Count == 2)
                        {
                            MovementScript.CurrentPlayer.transform.position = MovementScript.WaypointList[0].transform.position;
                            MovementScript.CurrentWaypoint = MovementScript.WaypointList[0];
                            Footstep.Play();
                        }
                        else if (Count == 1)
                        {
                            DoorOpen.Play();
                            ManagerScript.HousefromInside = true;
                            ManagerScript.HouseFromGrounds = false;
                            SceneManager.LoadScene("HouseExterior");
                        }

                        Count -= 1;
                        MovementCounter = MovementReset;
                    }
                }

                if(ManagerScript.HallFromRoom && !ManagerScript.InteriorGhostSeen)
                {
                    List.SetActive(false);

                    if (!GhostOn)
                    {
                        MovementScript.CurrentPlayer.transform.Rotate(0f, 180f, 0f);

                        Ghost.SetActive(true);
                        GhostLaugh.Play();
                        GhostOn = true;

                        TextArea.text = "*Gasp!";
                    }
                    else
                    {
                        if (GhostInPosition)
                        {
                            Ghost.SetActive(false);
                            GhostLaugh.Stop();
                            GhostSeen = true;
                            GhostOn = false;
                            TextArea.text = "I need to get out of here!";
                            TimeToMove = true;
                            ManagerScript.HallFromRoom = false;
                            ManagerScript.InteriorGhostSeen = true;
                        }
                        else
                        {
                            TextArea.text = "What IS that?!";
                        }
                    }
                }

                
            }
        }

        public void TurnOffNote()
        {
            PaperCrinkle.Play();
            ManagerScript.AmbientMusic.Stop();
            ManagerScript.RadioMusic.Play();
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
