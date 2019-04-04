using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HOS;

public class FolderIndicator : MonoBehaviour {

    public Alphabet FolderLanguage;
    public int Position = 0;
    public Texture2D NewCursor;
    public bool Clicked = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        //     Debug.Log("Mouse is over " + this.name);
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
        Clicked = true;
    }
}
