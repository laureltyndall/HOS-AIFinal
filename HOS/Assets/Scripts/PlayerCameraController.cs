using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCameraController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public Player CurrentPlayer;
    public bool CanOrbit = false;
    public List<GameObject> WaypointList = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
    void Update()
    {
        CurrentPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    public void OnPointerClick(PointerEventData data)
    {
        if ((data.pressPosition.x >= 0 && data.pressPosition.x <= 200) && (data.pressPosition.y >= 0 && data.pressPosition.y <= 451))
        {
            CurrentPlayer.transform.position = WaypointList[0].transform.position;
        }
        if ((data.pressPosition.x >= 0 && data.pressPosition.x <= 200) && (data.pressPosition.y >= 0 && data.pressPosition.y <= 451))
        {
            CurrentPlayer.transform.position = WaypointList[0].transform.position;
        }
        
    }

    public void OnPointerEnter(PointerEventData data)
    {
        if (CanOrbit)
        {
            if ((data.pressPosition.x >= 0 && data.pressPosition.x <= 450) && (data.pressPosition.y >= 0 && data.pressPosition.y <= 800))
            {
                RotateLeft();
            }
            if ((data.pressPosition.x >= 900 && data.pressPosition.x <= 1400) && (data.pressPosition.y >= 0 && data.pressPosition.y <= 800))
            {
                RotateRight();
            }
        }
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
}
