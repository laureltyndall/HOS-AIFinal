using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDoorController : MonoBehaviour {

    public Texture2D NewCursor;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Cursor.SetCursor(NewCursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        //      Debug.Log("Mouse is no longer on " + this.name);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseDown()
    {
        Debug.Log(this.name + " has been clicked");
    }
}
