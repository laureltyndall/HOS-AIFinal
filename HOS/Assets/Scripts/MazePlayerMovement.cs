using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HOS;

public class MazePlayerMovement : MonoBehaviour 
{

    public GameManager Manager;
    public GameObject Player;
    public Rigidbody PlayerBody;
    public float Speed = 5.0f;
	// Use this for initialization
	void Start () 
    {
        //Manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()  
    {
        float HorzMovement = Input.GetAxis("Horizontal");
        float VertMovement = Input.GetAxis("Vertical");
//        if (Input.GetKey(KeyCode.W))
//        {
//            //PlayerBody.velocity = Vector3.forward * Speed;
//        }
//        if (Input.GetKey(KeyCode.S))
//        {
//           // PlayerBody.velocity = Vector3.back * Speed;
//        } 
//        if (Input.GetKey(KeyCode.A))
//        {
//            //PlayerBody.velocity = Vector3.left * Speed;
//            Player.transform.Rotate(0,-5,0);
//
//        } 
//        if (Input.GetKey(KeyCode.D))
//        {
//            //PlayerBody.velocity = Vector3.right * Speed;
//            Player.transform.Rotate(0,5,0);
//
//        }
        if (Input.GetKey(KeyCode.Q))
        {
            Player.transform.Rotate(0,-5,0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            Player.transform.Rotate(0,5,0);
       } 
        Vector3 Movement = new Vector3(HorzMovement, 0 , VertMovement);
        PlayerBody.AddForce(Movement * Speed);
	}
}
