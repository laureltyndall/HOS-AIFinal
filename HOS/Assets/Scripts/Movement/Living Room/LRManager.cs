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
        private float GhostActiveCounter = 2f;
        public GameObject Flashlight;
        private bool BoxFalling = false;
        private float TimetoMiniGame = 2f;
        public bool WaitingForGame = false;
        public PlayerCameraController MovementScript;

        // Use this for initialization
        void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
            MovementScript = go.GetComponent<PlayerCameraController>();
        }

        // Update is called once per frame
        void Update()
        {
            if(MovementScript.LRMniGameFin)
            {
                LightsOn = true;
                // Switch Lights
                GhostSeen = true;
                HaveFlashlight = true;
                Flashlight.SetActive(false);
                FallingBox.SetActive(false);
                UprightBox.SetActive(true);
            }

            if(!LightsOn)
            {
                TextArea.text = "I should turn the lights on in here, too. Let's find a light switch.";
            }

            if(HaveFlashlight && !GhostSeen)
            {
                Ghost.SetActive(true);
                Flashlight.SetActive(false);
                TextArea.text = "*Gasp!";

                if (GhostActiveCounter <= 0)
                {
                    TextArea.text = "What in the-";
                    Ghost.SetActive(false);
                    Ghost.SetActive(false);
                    WaitingForGame = true;
                    GhostSeen = true;
                }
                else
                {
                    GhostActiveCounter -= Time.deltaTime;
                    if (!BoxFalling)
                    {
                        UprightBox.SetActive(false);
                        FallingBox.SetActive(true);
                        BoxFalling = true;
                    }
                }

            }

            if(WaitingForGame)
            {
                if(TimetoMiniGame <= 0)
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