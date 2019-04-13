using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class HMCenterManager : MonoBehaviour
    {
        public GameObject Wolf;
        public GameObject Smoke;
        public GameObject AnneCamera;
        public GameObject AlexCamera;
        public GameObject WolfCamera;
        public bool CanMove = false;
        private bool WolfActive = true;
        private bool SmokeActive = false;
        private bool WolfDisappear = false;
        private float WolfCounter = 5.5f;
        private float SmokeCounter = 2f;
        private float AfterWolf = 2f;
        public PlayerCameraController MovementScript;
        public Text TextArea;

        // Use this for initialization
        void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
            MovementScript = go.GetComponent<PlayerCameraController>();
        }

        // Update is called once per frame
        void Update()
        {
            if(MovementScript.CenterGameFin)
            {
                WolfCamera.SetActive(false);
                AnneCamera.SetActive(true);
                AlexCamera.SetActive(true);
                WolfActive = false;

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

                        if(WolfDisappear)
                        {
                            if(AfterWolf <= 0)
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
        }
    }
}