using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpPuzzleItem : MonoBehaviour {

    public Texture2D NewCursor;
    public bool AttachedtoMouse = false;
    public Transform StartPosition;
    public float CameraDistance = 800f;

    // Use this for initialization
    void Start () {
        StartPosition = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (AttachedtoMouse)
        {
            ObjectFollowCursor();
        }
	}

    void OnMouseOver()
    {
        if (!AttachedtoMouse)
        {
            //If your mouse hovers over the GameObject with the script attached, output this message
            Debug.Log("Mouse is over Letter.");
            Cursor.SetCursor(NewCursor, Vector2.zero, CursorMode.Auto);
        }
    }

    void OnMouseExit()
    {
        if (!AttachedtoMouse)
        {
            //The mouse is no longer hovering over the GameObject so output this message each frame
            Debug.Log("Mouse is no longer on Letter.");
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    private void OnMouseDown()
    {
        if (!AttachedtoMouse)
        {
            Cursor.visible = false;
            AttachedtoMouse = true;
        }
        else
        {
            AttachedtoMouse = false;
            Cursor.visible = true;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    private void ObjectFollowCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 point = ray.origin + (ray.direction * CameraDistance);
        this.transform.position = point;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Border")
        {
            this.transform.position = StartPosition.position;
        }
        if (other.tag == "PuzzlePiece")
        {
            this.transform.position = StartPosition.position;
        }
    }
}
