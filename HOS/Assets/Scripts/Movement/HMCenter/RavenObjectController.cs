using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class RavenObjectController : MonoBehaviour
    {
        public bool Clickable = false;
        public Texture2D NewCursor;
        public PlayerCameraController MovementScript;
        public HMCenterManager HMCManager;
        public BoxCollider MyCollider;
        public Text TextArea;
        public int ClickCount = 0;
        public bool Clicked = false;
        public MeshRenderer RavenStillMesh;
        public MeshRenderer RavenEyesMesh;
        public MeshRenderer RavenStillStar;
        public GameObject RavenFlying;
        private float TimetoSettle = 2f;
        private bool Flying = false;

        // Use this for initialization
        void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
            MovementScript = go.GetComponent<PlayerCameraController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[2] && HMCManager.PuzzleFound)
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

            if(Clicked)
            {
                if(TimetoSettle <= 0)
                {
                    RavenStillMesh.enabled = true;
                    RavenEyesMesh.enabled = true;
                    RavenStillStar.enabled = true;
                    RavenFlying.SetActive(false);
                    Clicked = false;
                }
                else
                {
                    if(!Flying)
                    {
                        RavenStillMesh.enabled = false;
                        RavenEyesMesh.enabled = false;
                        RavenStillStar.enabled = false;
                        RavenFlying.SetActive(true);

                        if(ClickCount <= 1)
                        {
                            TextArea.text = "Shoot! I need to find something to distract that bird and make it drop the star.";
                        }
                        else if (ClickCount > 1 && ClickCount <=4 )
                        {
                            TextArea.text = "Ouch! It pecked me!";
                        }
                    }

                    TimetoSettle -= Time.deltaTime;
                }
            }

        }

        void OnMouseOver()
        {
            if (Clickable)
            {
                // If Inventory does not have flashlight
                Cursor.SetCursor(MovementScript.CursorList[2], Vector2.zero, CursorMode.Auto);
                // else
                // Cursor.SetCursor(MovementScript.CursorList[3], Vector2.zero, CursorMode.Auto);
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

                if(ClickCount == 0)
                {
                    TextArea.text = "Here birdie! Give " + MovementScript.PlayerName + " the star!";
                    HMCManager.RavenFound = true;
                }
                else
                {
                    if(HMCManager.HasWorms)
                    {
                        // Start Mini Game
                        HMCManager.CrowGameStarted = true;
                    }
                    else
                    {
                        if(ClickCount > 4)
                        {
                            TextArea.text = "Ooh. I don't feel so good.";
                            HMCManager.KilledByBird = true;
                        }

                        Clicked = true;
                        TimetoSettle = 2f;
                        ClickCount++;
                    }
                }
            }
        }
    }
}