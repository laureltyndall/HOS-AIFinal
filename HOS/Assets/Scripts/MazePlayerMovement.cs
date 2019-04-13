using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HOS;

public class MazePlayerMovement : MonoBehaviour 
{

    public GameManager Manager;
 
	// Use this for initialization
	void Start () 
    {
        Manager = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update ()  
    {
		
	}
}
