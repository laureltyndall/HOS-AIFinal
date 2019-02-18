using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour 
{
    public bool CanOrbit = false;
    private int TurnsLeft = 0;
    private int TurnsRight = 0;

	// Use this for initialization
	void Start () {
		
	}
	
    public void MovePlayerFoward()
    {
        this.gameObject.transform.Translate(0,0,10);
    }

    public void MovePlayerBackward()
    {
        this.gameObject.transform.Translate(0,0,-10);
    }

    public void MovePlayerLeft()
    {
        this.gameObject.transform.Translate(-10,0,0);
    }

    public void MovePlayerRight()
    {
        this.gameObject.transform.Translate(10,0,0);
    }

    public void MovePlayerUturn()
    {
        this.gameObject.transform.Translate(0,0,0);
        this.gameObject.transform.Rotate(0,180,0);
    }

    public void OrbitLeft()
    {
        if (CanOrbit)
        {
            if (TurnsLeft <= 0)
            {
                this.gameObject.transform.GetChild(0).transform.Translate(-4, 0, 0);
            }
            this.gameObject.transform.Rotate(0, -90, 0);
            TurnsLeft += 1;
        }
    }

    public void OrbitRight()
    {
        if (CanOrbit)
        {
            if (TurnsRight <= 0)
            {
                this.gameObject.transform.GetChild(0).transform.Translate(4, 0, 0);
            }
            this.gameObject.transform.Rotate(0, -90, 0);
            TurnsRight += 1;
        }
    }
}
