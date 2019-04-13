using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class KitchenSceneManager : MonoBehaviour
    {

        public bool LookingForCheese = false;
        public bool MouseOn = false;
        public bool HasCheese = false;
        public bool HasBox = false;
        public bool RadioOn = true;
        public bool NoteOn = false;
        public bool InCloseUp = false;
        public bool MouseInPosition = false;
        public Text TextArea;
        public bool PlayerKilledByMouse = false;
        public GameObject MouseObject;
        public GameObject Cheese;
        public GameObject BoxObject;
        public GameObject GameOverPanel;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(MouseOn)
            {
                MouseObject.SetActive(true);
            }

            if(HasCheese)
            {
                Cheese.SetActive(false);
            }

            if(HasBox)
            {
                BoxObject.SetActive(false);
            }

            if(HasBox && HasCheese)
            {
                LookingForCheese = false;
            }

            if(PlayerKilledByMouse)
            {
                GameOverPanel.SetActive(true);
            }
        }

        public void TurnOffNote()
        {
            TextArea.text = "'Open the fountain? I didn't see a fountain out there. Could it be somewhere in the hedge maze?";
            // Add note to inventory
        }
    }
}