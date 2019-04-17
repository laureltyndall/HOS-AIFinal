using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class LRManager : MonoBehaviour
    {
        public bool LightsOn = false;
        public bool HaveFlashlight = false;
        public Text TextArea;
        private bool GhostSeen = false;
        public GameObject Ghost;
        public GameObject UprightBox;
        public GameObject FallingBox;
        public GameObject Light;
        private float GhostActiveCounter = 2f;
        public GameObject Flashlight;
        private bool BoxFalling = false;
        private float TimetoMiniGame = 2f;
        public bool WaitingForGame = false;
        public PlayerCameraController MovementScript;
        public AudioSource GhostLaugh;
        public AudioSource BoxSound;

        public GameObject TwinAlex;
        public GameObject TwinAnne;
        private Animator TwinAnimation;
        public GameObject GameWonPanel;
        public MenuManager Controller;
        public GameObject DialoguePanel;
        public DialogueController Dialogue;
        public Text DiaText;
        private bool DiaFinished = false;
        private bool NamedTwin = false;
        private bool Talking = false;
        private float TimeBetweenDialogue = 4f;
        private float ResetDiaTimer = 4f;
        private int DiaCounter = 0;

        private GameManager ManagerScript;
        private bool ManagerFound = false;

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
                if (ManagerScript.LRFromUnderground)
                {
                    LightsOn = true;
                    Light.SetActive(true);

                    if (!NamedTwin)
                    {
                        if (MovementScript.PlayerName == "Anne")
                        {
                            TwinAlex.SetActive(true);
                            TwinAnimation = TwinAlex.GetComponent<Animator>();
                            NamedTwin = true;
                        }
                        else if (MovementScript.PlayerName == "Alex")
                        {
                            TwinAnne.SetActive(true);
                            TwinAnimation = TwinAnne.GetComponent<Animator>();
                            NamedTwin = true;
                        }
                        else
                        {
                            NamedTwin = false;
                        }
                    }
                    else
                    {
                        if(Talking)
                        {
                            if (DiaCounter <= 7)
                            {
                                if (TimeBetweenDialogue <= 0)
                                {
                                    DiaText.text = Dialogue.TwinConvo[DiaCounter];
                                    DiaCounter++;
                                    TimeBetweenDialogue = ResetDiaTimer;
                                }
                                else
                                {
                                    TimeBetweenDialogue -= Time.deltaTime;
                                }
                            }
                            else
                            {
                                Talking = false;
                            }
                        }
                        else
                        {
                            if(!DiaFinished)
                            {
                                TwinAnimation.SetBool("Talking", true);
                                Talking = true;
                                DialoguePanel.SetActive(true);
                            }
                            else
                            {
                                DialoguePanel.SetActive(false);
                                TwinAlex.SetActive(false);
                                TwinAnne.SetActive(false);
                                Controller.ShowGameOver(GameWonPanel);
                            }
                        }
                    }
                }
                else
                {
                    if (MovementScript.LRMniGameFin)
                    {
                        LightsOn = true;
                        // Switch Lights
                        GhostSeen = true;
                        HaveFlashlight = true;
                        Flashlight.SetActive(false);
                        FallingBox.SetActive(false);
                        UprightBox.SetActive(true);
                    }

                    if (!LightsOn)
                    {
                        TextArea.text = "I should turn the lights on in here, too. Let's find a light switch.";
                    }
                    else
                    {
                        Light.SetActive(true);
                    }

                    if (HaveFlashlight && !GhostSeen)
                    {
                        Ghost.SetActive(true);
                        GhostLaugh.Play();
                        Flashlight.SetActive(false);
                        TextArea.text = "*Gasp!";

                        if (GhostActiveCounter <= 0)
                        {
                            TextArea.text = "What in the-";
                            Ghost.SetActive(false);
                            GhostLaugh.Stop();
                            WaitingForGame = true;
                            GhostSeen = true;
                        }
                        else
                        {
                            GhostActiveCounter -= Time.deltaTime;
                            if (!BoxFalling)
                            {
                                GhostLaugh.Play();
                                UprightBox.SetActive(false);
                                FallingBox.SetActive(true);
                                BoxSound.Play();
                                BoxFalling = true;
                            }
                        }

                    }

                    if (WaitingForGame)
                    {
                        if (TimetoMiniGame <= 0)
                        {
                            SceneManager.LoadScene("LivingRoomPuzzleGame");
                        }
                        else
                        {
                            TimetoMiniGame -= Time.deltaTime;
                            TextArea.text = "Oh no! Those folders fell everywhere!";
                        }
                    }
                }
            }
        }

        public void TellGameWon()
        {
            ManagerScript.GameWon = true;
        }
    }
}