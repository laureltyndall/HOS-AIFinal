using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class MouseControllerKitchen : MonoBehaviour
    {
        public bool Clickable = false;
        public Texture2D NewCursor;
        public PlayerCameraController MovementScript;
        public CapsuleCollider MyCollider;
        public Text TextArea;
        public KitchenSceneManager KitchenManager;
        public Animation MyAnimation;
        public bool IsWalking = false;
        public bool isBiting = false;
        public Transform EndPoint;
        private bool EndReached = false;
        private float Speed = 2f;
        public int ClickCounter = 0;

        // Use this for initialization
        void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
            MovementScript = go.GetComponent<PlayerCameraController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (IsWalking)
            {
                MyAnimation.Play("Run");
            }
            else if (isBiting)
            {
                MyAnimation.Play("Idle_Eat");
            }
            else
            {
                MyAnimation.Play("Idle2");
            }

            if (KitchenManager.MouseOn && !KitchenManager.MouseInPosition)
            {
                IsWalking = true;
                // Run towards location
                float StepSpeed = Speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, EndPoint.transform.position, StepSpeed);
            }
            else
            {
                IsWalking = false;
            }

            if(transform.position == EndPoint.position)
            {
                KitchenManager.MouseInPosition = true;
            }

            if (MovementScript.CurrentWaypoint == MovementScript.WaypointList[4] && KitchenManager.MouseInPosition)
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

            if(ClickCounter >= 5)
            {
                KitchenManager.PlayerKilledByMouse = true;
                ClickCounter = 0;
            }
        }

        void OnMouseOver()
        {
            if (Clickable)
            {
                // If Inventory does not have flashlight
                Cursor.SetCursor(MovementScript.CursorList[5], Vector2.zero, CursorMode.Auto);
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

                if(KitchenManager.HasBox && KitchenManager.HasCheese)
                {
                 //   SceneManager.LoadScene("MouseTestScene");
                }
                else
                {
                    KitchenManager.LookingForCheese = true;
                    TextArea.text = "It bit me! I need to find a way to get rid of that mouse.";
                    ClickCounter++;
                }
            }
        }
    }
}