using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HOS
{
    public class PickupInventoryItem : MonoBehaviour
    {
        #region Variables
        // Private Variables
        private MenuManager Controller;
        private GameManager Manager;
        private LetterNarration LetterNarration;

        private float TimeBetweenNarration = 13;
        private float TimeCounter;
        private float BeforeLetterCounter = 4f;
        public float AfterLetterCounter = 4f;

        private bool LetterClicked = false;
        private bool PaperOpen = false;
        private bool LetterFlipped = false;

        private int LetterNarrationCounter = 0;
        private int SpeakCounter = 2;

        private Scene CurrentScene;

        private string CharacterName;
        private string SiblingName;

        // Public Variables
        public GameObject LetterAnnetoAlex;
        public GameObject LetterAlextoAnne;
        public GameObject NarrativeUI;
        public GameObject PermanentUI;
        public RawImage AnneLetterText;
        public RawImage AlexLetterText;
        public Texture LetterBack;
        public GameObject AnneBloodSpatter;
        public GameObject AlexBloodSpatter;

        public Text NarrativeText;
        public Text SceneText;
        #endregion

        // Use this for initialization
        void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("GameController");
            Controller = go.gameObject.GetComponent<MenuManager>();
            LetterNarration = go.gameObject.GetComponent<LetterNarration>();
            GameObject ag = GameObject.FindGameObjectWithTag("GameManager");
            Manager = ag.gameObject.GetComponent<GameManager>();

            CurrentScene = SceneManager.GetActiveScene();

            LetterNarrationCounter = LetterNarration.Narration.Count;
            TimeCounter = TimeBetweenNarration;

            CharacterName = LetterNarration.CharacterName;
            SiblingName = LetterNarration.SiblingName;
        }

        // Update is called once per frame
        void Update()
        {
            if (LetterClicked)
            {
                BeforeLetterCounter -= Time.deltaTime;

                if (BeforeLetterCounter <= 0)
                {
                    OpenLetter();
                    NarrativeText.text = LetterNarration.Narration[LetterNarrationCounter - 1];
                    LetterNarrationCounter--;
                    SceneText.text = LetterNarration.CharacterSpeaks[0];
                    PaperOpen = true;
                    LetterClicked = false;
                }
            }

            if (PaperOpen)
            {
                TimeCounter -= Time.deltaTime;

                if (CurrentScene.name == "Intro")
                {
                    if (LetterNarrationCounter > 0)
                    {
                        if (TimeCounter <= 0)
                        {
                            NarrativeText.text = LetterNarration.Narration[LetterNarrationCounter - 1];
                            LetterNarrationCounter--;
                            TimeCounter = TimeBetweenNarration;
                        }
                    }
                    else if (LetterNarrationCounter == 0)
                    {
                        NarrativeText.text = LetterNarration.Narration[LetterNarrationCounter];
                        TimeCounter = TimeBetweenNarration;
                        LetterNarrationCounter--;
                    }
                    else
                    {
                        AfterLetterCounter -= Time.deltaTime;

                        if (AfterLetterCounter <= 0)
                        {
                            if (SpeakCounter > 0)
                            {
                                NarrativeText.text = LetterNarration.CharacterSpeaks[SpeakCounter];

                                if (SpeakCounter == 1)
                                {
                                    // Change the letter to the back of the paper.
                                    if (Manager != null)
                                    {
                                        if (Manager.CurrentPlayer != null)
                                        {
                                            if (Manager.CurrentPlayer.PlayerCharacter == Character.Alex)
                                            {
                                                // Display back of envelope
                                                AnneLetterText.texture = LetterBack;
                                                Controller.TogglePanel(AnneBloodSpatter);
                                            }
                                            else if (Manager.CurrentPlayer.PlayerCharacter == Character.Anne)
                                            {
                                                // Display back of envelope
                                                AlexLetterText.texture = LetterBack;
                                                Controller.TogglePanel(AlexBloodSpatter);
                                            }
                                            else
                                            {
                                                // Display back of envelope
                                                AlexLetterText.texture = LetterBack;
                                                Controller.TogglePanel(AlexBloodSpatter);
                                            }
                                        }
                                        else
                                        {
                                            // Display back of envelope
                                            AlexLetterText.texture = LetterBack;
                                            Controller.TogglePanel(AlexBloodSpatter);
                                        }
                                    }
                                }

                                SpeakCounter--;
                            }
                            else
                            {
                                OpenLetter();
                                PaperOpen = false;
                            }

                            AfterLetterCounter = 4f;
                        }
                    }
                }
            }
        }

        private void OnMouseDown()
        {
            if (tag == "SiblingLetter")
            {
                if (SiblingName == "Anne")
                {
                    SceneText.text = "A letter from Anne? I haven't heard from her in years.";
                }
                else if (SiblingName == "Alex")
                {
                    SceneText.text = "A letter from Alex? I haven't heard from him in years.";
                }

                LetterClicked = true;
            }
        }

        private void OpenLetter()
        {
            Controller.TogglePanel(NarrativeUI);
            Controller.TogglePanel(PermanentUI);

            if (Manager != null)
            {
                if (Manager.CurrentPlayer != null)
                {
                    if (Manager.CurrentPlayer.PlayerCharacter == Character.Alex)
                    {
                        Controller.TogglePanel(LetterAnnetoAlex);
                    }
                    else if (Manager.CurrentPlayer.PlayerCharacter == Character.Anne)
                    {
                        Controller.TogglePanel(LetterAlextoAnne);
                    }
                    else
                    {
                        Controller.TogglePanel(LetterAlextoAnne);
                    }
                }
                else
                {
                    Controller.TogglePanel(LetterAlextoAnne);
                }
            }

        }
    }
}