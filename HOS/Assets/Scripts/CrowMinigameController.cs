using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowMinigameController : MonoBehaviour 
{
    public int NumberOfWorms = 5;
    public bool CanThrowWorm = true;
    public int PlayerHP = 3;
    public const int PlayerMaxLives = 3;
    public bool PlayerDead = false;
    public bool IsGameOver = false;
    public bool IsCrowDistracted = false;
    public GameObject WormThrowerObject;
    public WormThrower WormThrowerScript;
    public GameObject AttackerCrow;
    public GameObject Player;
    public float speed = .1f;
    public GameObject[] LifeArray = new GameObject[PlayerMaxLives];
    public GameObject TransformStartPosition;
    public GameObject PlayerLifeImage;
    public Canvas UICanvas;
	// Use this for initialization
	void Start () 
    {
		GenerateLives();
	}
	
	// Update is called once per frame
	void Update()
    {
        if (!IsCrowDistracted)
        {
            AttackPlayer();
        }
        else
        {
            MoveToWorm();
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
        DetermineNumberOfWorms();   
	}

    void AttackPlayer()
    {
        float timeStep = speed * Time.deltaTime;
        AttackerCrow.transform.position = Vector3.MoveTowards(AttackerCrow.transform.position, Player.transform.position,timeStep);
    }
    
    void MoveToWorm()
    {
        float timeStep = speed * Time.deltaTime;
        AttackerCrow.transform.position = Vector3.MoveTowards(AttackerCrow.transform.position, WormThrowerScript.WormThrown.transform.position,timeStep);
    }

    void DetermineNumberOfWorms()
    {
        if (NumberOfWorms <= 0)
            CanThrowWorm = false;
        else
        {
            CanThrowWorm = true;
        }
    }
    
    void GenerateLives()
    {
        for (int i = 0; i < PlayerMaxLives; i++)
        {
            GameObject Obj = GameObject.Instantiate(PlayerLifeImage,UICanvas.transform);
            LifeArray[i] = Obj;
            if (i == 0)
                LifeArray[i].transform.position = TransformStartPosition.transform.position;
            else
                LifeArray[i].transform.position =new Vector3(LifeArray[i -1].transform.position.x + LifeArray[i].transform.localScale.x * 120, TransformStartPosition.transform.position.y, TransformStartPosition.transform.position.z);
        }
    }

    void RemoveLife()
    {

        
    }
}
