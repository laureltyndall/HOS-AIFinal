using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace HOS
{
    public class CursorChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public PlayerCameraController MovementScript;
        public Texture2D NewCursor;
        //public bool Clickable = false;

        public void Start()
        {
            GameObject go = GameObject.FindGameObjectWithTag("UISystem");
            MovementScript = go.GetComponent<PlayerCameraController>();
        }

        void OnMouseOver()
        {
            //if (Clickable)
            //{
            //If your mouse hovers over the GameObject with the script attached, output this message
            //     Debug.Log("Mouse is over " + this.name);
            Cursor.SetCursor(NewCursor, Vector2.zero, CursorMode.Auto);
            //   }
        }

        void OnMouseExit()
        {
            //The mouse is no longer hovering over the GameObject so output this message each frame
            //      Debug.Log("Mouse is no longer on " + this.name);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }

        public void OnPointerEnter(PointerEventData data)
        {
            Debug.Log("Position X: " + Input.mousePosition.x.ToString() + " , Position Y: " + Input.mousePosition.y.ToString());

            if (MovementScript.CanOrbit)
            {
                if ((Input.mousePosition.x >= 0 && Input.mousePosition.x <= 100) && (Input.mousePosition.y >= 0 && Input.mousePosition.y <= 800))
                {
                    Debug.Log("Rotating Left");
                    Cursor.SetCursor(MovementScript.CursorList[4], Vector2.zero, CursorMode.Auto);
                    MovementScript.CurrentCursor = CursorType.Panoramic;
                    MovementScript.RotateLeft();
                }
                if ((Input.mousePosition.x >= 1100 && Input.mousePosition.x <= 1400) && (Input.mousePosition.y >= 0 && Input.mousePosition.y <= 800))
                {
                    Debug.Log("Rotating Right");
                    Cursor.SetCursor(MovementScript.CursorList[4], Vector2.zero, CursorMode.Auto);
                    MovementScript.CurrentCursor = CursorType.Panoramic;
                    MovementScript.RotateRight();
                }
            }
            else
            {
                //if (CanSharpTurn)
                //{
                //    if ((Input.mousePosition.x >= 0 && Input.mousePosition.x <= 100) && (Input.mousePosition.y >= 0 && Input.mousePosition.y <= 800))
                //    {
                //        Debug.Log("Changing to Turn Left Cursor");
                //        Cursor.SetCursor(CursorList[6], Vector2.zero, CursorMode.Auto);
                //        CurrentCursor = CursorType.LeftTurn;
                //    }
                //    if ((Input.mousePosition.x >= 1100 && Input.mousePosition.x <= 1400) && (Input.mousePosition.y >= 0 && Input.mousePosition.y <= 800))
                //    {
                //        Debug.Log("Changing to Turn Right Cursor");
                //        Cursor.SetCursor(CursorList[7], Vector2.zero, CursorMode.Auto);
                //        CurrentCursor = CursorType.RightTurn;
                //    }
                //}
                if (MovementScript.CanForward)
                {
                    if ((Input.mousePosition.x >= 539 && Input.mousePosition.x <= 936) && (Input.mousePosition.y >= 234 && Input.mousePosition.y <= 800))
                    {
                        Debug.Log("Changing to Forward Cursor");
                        Cursor.SetCursor(MovementScript.CursorList[3], Vector2.zero, CursorMode.Auto);
                        MovementScript.CurrentCursor = CursorType.Forward;
                    }
                }

                if ((Input.mousePosition.x >= 100 && Input.mousePosition.x <= 1100) && (Input.mousePosition.y >= 50 && Input.mousePosition.y <= 120))
                {
                    if (MovementScript.CanBackup)
                    {
                        Debug.Log("Changing to Backup Cursor");
                        Cursor.SetCursor(MovementScript.CursorList[0], Vector2.zero, CursorMode.Auto);
                        MovementScript.CurrentCursor = CursorType.Backup;
                    }
                    else if (MovementScript.CanUturn)
                    {
                        Debug.Log("Changing to U-Turn Cursor");
                        Cursor.SetCursor(MovementScript.CursorList[8], Vector2.zero, CursorMode.Auto);
                        MovementScript.CurrentCursor = CursorType.TurnAround;
                    }
                }
            }
        }

        public void OnPointerExit(PointerEventData data)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            MovementScript.CurrentCursor = CursorType.Default;
        }
    }
}