using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrowMinigameController : MonoBehaviour 
{
    public int NumberOfWorms = 8;
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
    public int TimesCrowDistracted = 0;
    public Text WormText;

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

        if (Input.GetKey(KeyCode.W))
        {
            WormThrowerObject.transform.position += Vector3.up / 2;
        }
        if (Input.GetKey(KeyCode.S))
        {
            WormThrowerObject.transform.position += Vector3.down / 2;
        } 
        if (Input.GetKey(KeyCode.A))
        {
            WormThrowerObject.transform.position += Vector3.right / 2;
        } 
        if (Input.GetKey(KeyCode.D))
        {
            WormThrowerObject.transform.position += Vector3.left / 2;
        }
        DetermineNumberOfWorms();

        if (WormThrowerObject.transform.position.x < -4)
        {
            WormThrowerObject.transform.position = new Vector3(WormThrowerObject.transform.position.x + 1f, WormThrowerObject.transform.position.y, WormThrowerObject.transform.position.z);
        }
        if (WormThrowerObject.transform.position.x > 4)
        {
            WormThrowerObject.transform.position = new Vector3(WormThrowerObject.transform.position.x - 1f, WormThrowerObject.transform.position.y, WormThrowerObject.transform.position.z);
        }

        if (WormThrowerObject.transform.position.y < -1.5)
        {
            WormThrowerObject.transform.position = new Vector3(WormThrowerObject.transform.position.x, WormThrowerObject.transform.position.y + 1f, WormThrowerObject.transform.position.z);
        }

        if (WormThrowerObject.transform.position.y > .5)
        {
            WormThrowerObject.transform.position = new Vector3(WormThrowerObject.transform.position.x, WormThrowerObject.transform.position.y - 1f, WormThrowerObject.transform.position.z);
        }

        if (AttackerCrow.transform.position.x < -4.5)
        {
            AttackerCrow.transform.position = new Vector3(AttackerCrow.transform.position.x + 1f, AttackerCrow.transform.position.y, AttackerCrow.transform.position.z);
        }

        if (AttackerCrow.transform.position.x > 4.5)
        {
            AttackerCrow.transform.position = new Vector3(AttackerCrow.transform.position.x - 1f, AttackerCrow.transform.position.y, AttackerCrow.transform.position.z);
        }

        if (AttackerCrow.transform.position.y < -2)
        {
            AttackerCrow.transform.position = new Vector3(AttackerCrow.transform.position.x, AttackerCrow.transform.position.y + 1f, AttackerCrow.transform.position.z);
        }

        if (AttackerCrow.transform.position.y >.75 )
        {
            AttackerCrow.transform.position = new Vector3(AttackerCrow.transform.position.x, AttackerCrow.transform.position.y - 1f, AttackerCrow.transform.position.z);

        }

        if (TimesCrowDistracted >= 5)
        {
            IsGameOver = true;
        }   
        UpdateWorms();
	}

    void AttackPlayer()
    {
        float timeStep = speed * Time.deltaTime;
        AttackerCrow.transform.position = Vector3.MoveTowards(AttackerCrow.transform.position, Player.transform.position,timeStep);
        AttackerCrow.transform.rotation.SetFromToRotation(AttackerCrow.transform.position,Player.transform.position);
    }
    
    void MoveToWorm()
    {
        float timeStep = speed * Time.deltaTime;
        AttackerCrow.transform.position = Vector3.MoveTowards(AttackerCrow.transform.position, WormThrowerScript.WormThrown.transform.position,timeStep);
        AttackerCrow.transform.rotation.SetFromToRotation(AttackerCrow.transform.position,WormThrowerScript.WormThrown.transform.position);
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

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Crow")
        {
            LifeArray[PlayerHP -1].SetActive(false);
            PlayerHP -= 1;
        }

        if (PlayerHP <= 0)
        {
            PlayerDead = true;
        }
    }

    void UpdateWorms()
    {
        WormText.text = "Number of Worms Remaining: " + NumberOfWorms.ToString();

    }
}
