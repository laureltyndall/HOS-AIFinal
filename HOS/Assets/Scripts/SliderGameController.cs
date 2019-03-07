using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HOS
{
    public class SliderGameController : MonoBehaviour
    {
        public GameManager ManagerScript;
        public Text NarrativeBox;
        public GameObject GameOverPanel;
        private bool ManagerFound = false;
        private bool NamesFound = false;
        public bool GameOver = false;
        public string PlayerName;
        private string SiblingName;

        private float TimeLeft = 180.0f;

        private string Narration1 = "It looks like I need to move the blocks out of the way so the key gets to the keyhole.";
        private string Narration2 = ": Please hurry, ";
        private string Narration3 = ": I think it's getting closer!";
        private string Narration4 = ": It's here!";
        private string Narration5 = "Got it!";

        // Use this for initialization
        void Start()
        {
            if (!ManagerFound)
            {
                FindManagerScript();
            }

            NarrativeBox.text = Narration1;
        }

        // Update is called once per frame
        void Update()
        {
            if (!GameOver)
            {
                if (ManagerFound)
                {
                    if (NamesFound)
                    {
                        Narration2 = SiblingName + Narration2 + PlayerName + "!";
                        Narration3 = SiblingName + Narration3;
                        Narration4 = SiblingName + Narration4;
                    }
                    else
                    {
                        FindNames();
                    }
                }
                else
                {
                    FindManagerScript();
                }

                TimeLeft -= Time.deltaTime;
                if (TimeLeft <= 60)
                {
                    NarrativeBox.text = Narration2;
                }
                if (TimeLeft <= 30)
                {
                    NarrativeBox.text = Narration3;
                }
                if (TimeLeft <= 10)
                {
                    NarrativeBox.text = Narration4;
                }
                if (TimeLeft <= 0)
                {
                    GameOver = true;
                    RunGameOver();
                }
            }
        }

        void FindManagerScript()
        {
            GameObject go = GameObject.FindGameObjectWithTag("GameManager");

            if (go != null)
            {
                ManagerScript = go.gameObject.GetComponent<GameManager>();

                if (ManagerScript != null)
                {
                    PlayerName = ManagerScript.CurrentPlayer.name;

                    if (PlayerName != null)
                    {
                        FindNames();
                    }

                    ManagerFound = true;
                }
            }
        }
            
        void FindNames()
        {
            if (PlayerName != null)
            {
                if (PlayerName == "Alex")
                {
                    SiblingName = "Anne";
                    NamesFound = true;
                }
                else if (PlayerName == "Anne")
                {
                    SiblingName = "Alex";
                    NamesFound = true;
                }
            }
        }

        void RunGameOver()
        {
            // If the pause menu is on, turn it off. If it is off, turn it on
            GameOverPanel.SetActive(!GameOverPanel.activeSelf);
        }

        public void RunWinGame()
        {
            ManagerScript.PuzzleComplete = true;
            GameOver = true;

        }
    }
}