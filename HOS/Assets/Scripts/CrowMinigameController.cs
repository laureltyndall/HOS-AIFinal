using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowMinigameController : MonoBehaviour 
{
    public int NumberOfWorms = 5;
    public bool CanThrowWorm = true;
    public int PlayerHP = 3;
    public bool PlayerDead = false;
    public bool IsGameOver = false;
    public bool IsCrowDistracted = false;
    public GameObject WormThrowerObject;
    public WormThrower WormThrowerScript;
    public GameObject AttackerCrow;
    public GameObject Player;
    public float speed = .1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        if (!IsCrowDistracted)
        {
            AttackPlayer();
        }
        if(Input.GetKey(KeyCode.W))
        {
            WormThrowerObject.transform.position += Vector3.up;
        }
        if(Input.GetKey(KeyCode.S))
        {
            WormThrowerObject.transform.position += Vector3.down;
        } 
        if(Input.GetKey(KeyCode.A))
        {
            WormThrowerObject.transform.position += Vector3.left;
        } 
        if(Input.GetKey(KeyCode.D))
        {
            WormThrowerObject.transform.position += Vector3.right;
        }   
	}

    void AttackPlayer()
    {
        float timeStep = speed * Time.deltaTime;
        AttackerCrow.transform.position = Vector3.MoveTowards(AttackerCrow.transform.position, Player.transform.position,timeStep);
    }
    
    void MoveToWorm()
    {
        float timeStep = speed * Time.deltaTime;
        AttackerCrow.transform.position = Vector3.MoveTowards(AttackerCrow.transform.position, Player.transform.position,timeStep);
    }
      
}
