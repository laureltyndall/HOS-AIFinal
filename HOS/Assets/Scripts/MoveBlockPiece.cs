using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlockPiece : MonoBehaviour {

    public Texture2D LeftCursor;
    public Texture2D RightCursor;
    public Texture2D UpCursor;
    public Texture2D DownCursor;

    public enum CanMove
    {
        None = 0,
        Left = 1,
        Right = 2
    }

    public CanMove CanOnlyMove = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(this.tag == "HorizontalPiece")

            {

            }
        }
    }

    void OnMouseEnter()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over: " + this.name);
        Debug.Log("Position X: " + Input.mousePosition.x.ToString() + " , Position Y: " + Input.mousePosition.y.ToString());

    }

    void OnMouseOver()
    {

    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on Block.");
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
