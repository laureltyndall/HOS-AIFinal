using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class HMCenterManager : MonoBehaviour
    {
        public PlayerCameraController MovementScript;
        public MenuManager Controller;

        public GameObject Wolf;
        public GameObject Smoke;
        public GameObject AnneCamera;
        public GameObject AlexCamera;
        public GameObject WolfCamera;
        public GameObject CrowWithStar;
        public GameObject GameOverPanel;
        public GameObject WormsPane;
        public GameObject CrowGame;
        public GameObject FountainClosed;
        public GameObject FountainOpen;

        public bool CanMove = false;
        private bool WolfActive = true;
        private bool SmokeActive = false;
        private bool WolfDisappear = false;
        public bool ClothFound = false;
        public bool PuzzleFound = false;
        public bool PuzzleFinished = false;
        public bool HasStar = false;
        public bool CrowGameStarted = false;
        public bool HasWorms = false;
        public bool KilledByBird = false;
        public bool RavenFound = false;

        private float WolfCounter = 5.5f;
        private float SmokeCounter = 2f;
        private float AfterWolf = 2f;
        private float Speed = 10f;

        public Text TextArea;
        public Text GOText;

        // Use this for initialization
        void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
            MovementScript = go.GetComponent<PlayerCameraController>();
            CrowGame = GameObject.FindGameObjectWithTag("CrowGameObject");
            CrowGame.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (MovementScript.CenterGameFin)
            {
                SmokeActive = false;
                ClothFound = true;
                PuzzleFound = true;
                PuzzleFinished = true;
                HasStar = true;
                CrowGameStarted = true;
                HasWorms = true;
                KilledByBird = false;
                RavenFound = true;

                AnneCamera.SetActive(true);
                AlexCamera.SetActive(true);
                WolfActive = false;
                CanMove = true;

                PuzzleFinished = true;
            }
            else
            {
                if (WolfActive)
                {
                    MovementScript.CanUturn = false;
                    MovementScript.CanOrbit = false;
                    MovementScript.CanLeftTurn = false;
                    MovementScript.CanRightTurn = false;
                    MovementScript.CanForward = false;
                    MovementScript.CanBackup = false;

                    if (WolfCounter <= 0)
                    {
                        if (!SmokeActive)
                        {
                            Smoke.SetActive(true);
                            SmokeActive = true;
                        }
                        else
                        {
                            if (SmokeCounter <= 0)
                            {
                                Wolf.SetActive(false);
                                Smoke.SetActive(false);
                                WolfDisappear = true;
                                TextArea.text = "It just - disappeared!";
                            }
                            else
                            {
                                SmokeCounter -= Time.deltaTime;
                            }

                            if (WolfDisappear)
                            {
                                if (AfterWolf <= 0)
                                {
                                    WolfCamera.SetActive(false);
                                    AnneCamera.SetActive(true);
                                    AlexCamera.SetActive(true);
                                    WolfActive = false;
                                    TextArea.text = "What is going on here? I need to find " + MovementScript.SiblingName + ".";
                                }
                                else
                                {
                                    AfterWolf -= Time.deltaTime;
                                }
                            }
                        }
                    }
                    else
                    {
                        WolfCounter -= Time.deltaTime;
                        TextArea.text = "*Gasp!*";
                    }
                }
                else
                {
                    if (!CanMove)
                    {
                        MovementScript.CanUturn = true;
                        MovementScript.CanOrbit = false;
                        MovementScript.CanLeftTurn = false;
                        MovementScript.CanRightTurn = false;
                        MovementScript.CanForward = true;
                        MovementScript.CanBackup = false;
                        CanMove = true;
                    }
                }

                if (CanMove)
                {
                    if (!PuzzleFinished)
                    {
                        if (!ClothFound && MovementScript.CurrentWaypoint == MovementScript.WaypointList[1] && !PuzzleFound)
                        {
                            TextArea.text = "I wonder what " + MovementScript.pronoun + " meant by 'Open the fountain'? Maybe I should take a look at it.";
                        }
                        else if (ClothFound && MovementScript.CurrentWaypoint == MovementScript.WaypointList[1] && !PuzzleFound)
                        {
                            TextArea.text = "There must be some way to open this. I bet " + MovementScript.SiblingName + " found a way in!";
                        }

                        if (HasWorms && MovementScript.CurrentWaypoint == MovementScript.WaypointList[2] && !CrowGameStarted)
                        {
                            TextArea.text = "Polly want a yummy - disgusting -  worm?";
                        }

                        if (PuzzleFound && !HasStar && !CrowGameStarted)
                        {
                            CrowWithStar.SetActive(true);
                        }

                        if (HasWorms)
                        {
                            WormsPane.SetActive(false);
                        }

                        if (CrowGameStarted)
                        {
                            CrowWithStar.SetActive(false);
                            TextArea.text = "";
                            CrowGame.SetActive(true);
                        }
                    }
                }

                if (KilledByBird)
                {
                    if (HasWorms)
                    {
                        GOText.text = "The good news? \n Now you know that earthworms are very hard to throw. \n \n The bad news? \n That crow has better aim than you.";
                    }
                    else
                    {
                        GOText.text = "You couldn't find a way to distract the bird. \n \n Until it managed to peck you in the eye. \n \n Then you were very distracting.";
                    }
                    Controller.ShowGameOver(GameOverPanel);
                }
            }
            
            if(PuzzleFinished)
            {
                TextArea.text = "*Gasp!* There was a secret passage!";
                // Move the fountain
                FountainOpen.SetActive(true);
                FountainClosed.SetActive(false);
                //float StepSpeed = Speed * Time.deltaTime;
                //FountainClosed.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0,transform.position.y,transform.position.z), StepSpeed);
                Camera.main.transform.rotation = Quaternion.Euler(50f, -180f, 0f);
            }
        }
    }
}