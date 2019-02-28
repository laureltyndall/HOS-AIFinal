﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCameraController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Player CurrentPlayer;
    public bool CanOrbit = false;
    public bool CanBackup = false;
    public float RotateTime = 0.2f;
    public List<GameObject> WaypointList = new List<GameObject>();
    public List<Texture2D> CursorList;
    CursorType CurrentCursor = CursorType.Default;

	// Use this for initialization
	void Start () {
		
	}
	
    void Update()
    {
        CurrentPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    public void OnPointerClick(PointerEventData data)
    {
        if (CurrentCursor == CursorType.Forward)
        {
            CurrentPlayer.transform.position = WaypointList[0].transform.position;
        }
        if (CurrentCursor == CursorType.TurnAround)
        {
            MovePlayerUturn();
        }
    }

    public void OnPointerEnter(PointerEventData data)
    {
        Debug.Log("Position X: " + Input.mousePosition.x.ToString() + " , Position Y: " + Input.mousePosition.y.ToString());

        if (CanOrbit)
        {
            if ((Input.mousePosition.x >= 0 && Input.mousePosition.x <= 100) && (Input.mousePosition.y >= 0 && Input.mousePosition.y <= 800))
            {
                Debug.Log("Rotating Left");
                Cursor.SetCursor(CursorList[4], Vector2.zero, CursorMode.Auto);
                CurrentCursor = CursorType.Panoramic;
                RotateLeft();
            }
            if ((Input.mousePosition.x >= 1100 && Input.mousePosition.x <= 1400) && (Input.mousePosition.y >= 0 && Input.mousePosition.y <= 800))
            {
                Debug.Log("Rotating Right");
                Cursor.SetCursor(CursorList[4], Vector2.zero, CursorMode.Auto);
                CurrentCursor = CursorType.Panoramic;
                RotateRight();
            }
        }
        else
        {
            if ((Input.mousePosition.x >= 0 && Input.mousePosition.x <= 100) && (Input.mousePosition.y >= 0 && Input.mousePosition.y <= 800))
            {
                Debug.Log("Changing to Turn Left Cursor");
                Cursor.SetCursor(CursorList[6], Vector2.zero, CursorMode.Auto);
                CurrentCursor = CursorType.LeftTurn;
            }
            if ((Input.mousePosition.x >= 1100 && Input.mousePosition.x <= 1400) && (Input.mousePosition.y >= 0 && Input.mousePosition.y <= 800))
            {
                Debug.Log("Changing to Turn Right Cursor");
                Cursor.SetCursor(CursorList[7], Vector2.zero, CursorMode.Auto);
                CurrentCursor = CursorType.RightTurn;
            }
            if ((Input.mousePosition.x >= 539 && Input.mousePosition.x <= 936) && (Input.mousePosition.y >= 234 && Input.mousePosition.y <= 800))
            {
                Debug.Log("Changing to Forward Cursor");
                Cursor.SetCursor(CursorList[3], Vector2.zero, CursorMode.Auto);
                CurrentCursor = CursorType.Forward;
            }
            if ((Input.mousePosition.x >= 100 && Input.mousePosition.x <= 1100) && (Input.mousePosition.y >= 50 && Input.mousePosition.y <= 120))
            {
                if (CanBackup)
                {
                    Debug.Log("Changing to Backup Cursor");
                    Cursor.SetCursor(CursorList[0], Vector2.zero, CursorMode.Auto);
                    CurrentCursor = CursorType.Backup;
                }
                else
                {
                    Debug.Log("Changing to U-Turn Cursor");
                    Cursor.SetCursor(CursorList[8], Vector2.zero, CursorMode.Auto);
                    CurrentCursor = CursorType.TurnAround;
                }
            }
        }
    }

    public void OnPointerExit(PointerEventData data)
    {
       Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        CurrentCursor = CursorType.Default;
    }

    public void MovePlayerUturn()
    {
        CurrentPlayer.transform.Rotate(0,180,0);
    }
    
    public void RotateLeft()
    {
        CurrentPlayer.transform.Rotate(0,-90,0);
    }

    public void RotateRight()
    {
        CurrentPlayer.transform.Rotate(0,90,0);
    }

    public void OnGUI()
    {
      //  GUI.Box(new Rect(0, 0, 4, 3), );
    }
}
