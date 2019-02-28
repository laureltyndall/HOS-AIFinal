using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour {

  //  public Texture2D NewCursor;

    public void Start()
    {
        
    }

    public void OnMouseEnter(Texture2D NewCursor)
    {
        // Use this to set the cursor to the chosen sprite image
        Cursor.SetCursor(NewCursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnMouseExit()
    {
        // This sets the cursor back to default
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
