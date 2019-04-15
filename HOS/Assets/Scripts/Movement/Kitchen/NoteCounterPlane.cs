using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class NoteCounterPlane : MonoBehaviour
    {
        public bool Clickable = false;
        public Texture2D NewCursor;
        public PlayerCameraController MovementScript;
        public KitchenSceneManager KitchenManager;
        public BoxCollider MyCollider;
        public Text TextArea;
        public GameObject CloseUpCamera;
        public AudioSource MouseSqueak;

        // Use this for initialization
        void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
            MovementScript = go.GetComponent<PlayerCameraController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[4] && !KitchenManager.LookingForCheese)
            {
                // If we are right next to the gate and we are looking at it
                Clickable = true;
                MyCollider.enabled = true;
            }
            else
            {
                Clickable = false;
                MyCollider.enabled = false;
            }

            if(MovementScript.TurnOffCloseup)
            {
                CloseUpCamera.SetActive(false);
                MovementScript.CanOrbit = true;
                MovementScript.CanBackup = false;
                MovementScript.TurnOffCloseup = false;
                KitchenManager.InCloseUp = false;
            }
        }

        void OnMouseOver()
        {
            if (Clickable)
            {
                // If Inventory does not have flashlight
                Cursor.SetCursor(MovementScript.CursorList[2], Vector2.zero, CursorMode.Auto);
            }
        }

        void OnMouseExit()
        {
            //The mouse is no longer hovering over the GameObject so output this message each frame
            //      Debug.Log("Mouse is no longer on " + this.name);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }

        private void OnMouseDown()
        {
            if (Clickable)
            {
                Debug.Log(this.name + " has been clicked");
                Clickable = false;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

                if(!KitchenManager.MouseOn)
                {
                    CloseUpCamera.SetActive(true);
                    MovementScript.CanBackup = true;
                    MovementScript.CanOrbit = false;
                    KitchenManager.InCloseUp = true;
                }
                else
                {
                    MouseSqueak.Play();
                    if(KitchenManager.HasBox && KitchenManager.HasCheese)
                    {
                        CloseUpCamera.SetActive(true);
                        MovementScript.CanBackup = true;
                        MovementScript.CanOrbit = false;
                        KitchenManager.InCloseUp = true;
                    }
                    else
                    {
                        if(!KitchenManager.HasBox && !KitchenManager.HasCheese)
                        {
                            // Has neither
                            TextArea.text = "I need to find a way to get rid of that mouse.";
                            KitchenManager.LookingForCheese = true;
                        }
                        else if (KitchenManager.HasBox && !KitchenManager.HasCheese)
                        {
                            // Has only box
                            TextArea.text = "I still need to find a way to lure the mouse into the box.";
                        }
                        else if (!KitchenManager.HasBox && KitchenManager.HasCheese)
                        {
                            // Has only cheese
                            TextArea.text = "I still need to find something to trap the mouse in.";
                        }
                    }
                }
            }
        }
    }
}