using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour {

    public Texture2D NewCursor;

    public void Start()
    {
        
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over Letter.");
        Cursor.SetCursor(NewCursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on Letter.");
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
