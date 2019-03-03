using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HOS
{
    public class MoveBlockPiece : MonoBehaviour
    {

        public Texture2D LeftCursor;
        public Texture2D RightCursor;
        public Texture2D UpCursor;
        public Texture2D DownCursor;

        public enum CanMove
        {
            None = 0,
            Left = 1,
            Right = 2,
            Up = 3,
            Down = 4
        }

        public CanMove ThisSideMoves;
        public CanMove Moving = CanMove.None;

        public MovingPiece ParentPiece;

        private void Start()
        {
            GameObject go = transform.parent.gameObject;
            ParentPiece = go.GetComponent<MovingPiece>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (Moving == CanMove.Right)
                {
                    ParentPiece.IsMovingRight = true;
                }
                else if (Moving == CanMove.Left)
                {
                    ParentPiece.IsMovingLeft = true;
                }
                else if (Moving == CanMove.Up)
                {
                    ParentPiece.IsMovingUp = true;
                }
                else if (Moving == CanMove.Down)
                {
                    ParentPiece.IsMovingDown = true;
                }
            }
        }

        void OnMouseEnter()
        {
            //If your mouse hovers over the GameObject with the script attached, output this message
            Debug.Log("Mouse is over: " + transform.parent.name + " " + this.name);

            if (ThisSideMoves == CanMove.Right)
            {
                Debug.Log("Mouse is over Move RIGHT Side.");
                Cursor.SetCursor(RightCursor, Vector2.zero, CursorMode.Auto);
                Moving = CanMove.Right;
            }
            else if (ThisSideMoves == CanMove.Left)
            {
                Debug.Log("Mouse is over Move LEFT Side.");
                Cursor.SetCursor(LeftCursor, Vector2.zero, CursorMode.Auto);
                Moving = CanMove.Left;
            }
            else if (ThisSideMoves == CanMove.Up)
            {
                Debug.Log("Mouse is over Move UP Side.");
                Cursor.SetCursor(UpCursor, Vector2.zero, CursorMode.Auto);
                Moving = CanMove.Up;
            }
            else if (ThisSideMoves == CanMove.Down)
            {
                Debug.Log("Mouse is over Move DOWN Side.");
                Cursor.SetCursor(DownCursor, Vector2.zero, CursorMode.Auto);
                Moving = CanMove.Down;
            }
        }

        void OnMouseOver()
        {

        }

        void OnMouseExit()
        {
            //The mouse is no longer hovering over the GameObject so output this message each frame
            Debug.Log("Mouse is no longer on Block.");
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            Moving = CanMove.None;
        }
    }
}