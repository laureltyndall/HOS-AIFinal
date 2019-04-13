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
        public GameObject MovementSystem;
        private bool WolfActive = true;
        private bool SmokeActive = false;
        private float WolfCounter = 5.5f;
        private float SmokeCounter = 2f;
        public PlayerCameraController MovementScript;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (WolfActive)
            {
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
                            WolfCamera.SetActive(false);
                            AnneCamera.SetActive(true);
                            AlexCamera.SetActive(true);
                            MovementSystem.SetActive(true);
                            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
                            MovementScript = go.GetComponent<PlayerCameraController>();
                            WolfActive = false;
                        }
                        else
                        {
                            SmokeCounter -= Time.deltaTime;
                        }
                    }
                }
                else
                {
                    WolfCounter -= Time.deltaTime;
                }
            }
        }
    }
}