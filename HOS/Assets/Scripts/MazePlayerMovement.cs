using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HOS;

public class MazePlayerMovement : MonoBehaviour 
{

    public GameManager Manager;
    public GameObject Player;
    public Rigidbody PlayerBody;
	// Use this for initialization
	void Start () 
    {
        Manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()  
    {
        if (Input.GetKey(KeyCode.W))
        {
            PlayerBody.velocity = Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            PlayerBody.velocity = Vector3.back;
        } 
        if (Input.GetKey(KeyCode.A))
        {
            PlayerBody.velocity = Vector3.left;
        } 
        if (Input.GetKey(KeyCode.D))
        {
            PlayerBody.velocity = Vector3.right;
        }
	}
}
