using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HOS;

public class MazePlayerMovement : MonoBehaviour 
{

    public GameManager Manager;
    public GameObject Player;
    public Rigidbody PlayerBody;
    public GameObject FireTarget;
    public GameObject StickObject;
    public WolfAI stickFlag;
    public int NumberOfSticks = 3;
    public bool CanThrowStick = true;
    public GameObject gameOver;
    public MenuManager mManagerObject;
    private bool GameOverShown = false;
    public AudioSource StickThrowSound;
    public GameObject Wolf;
    private bool WolfOn = true;
    public float WoflTimer = 7f;
    private float resettimer = 7f;
    
    public float Speed = 5.0f;
	// Use this for initialization
	void Start () 
    {
        Manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update()
    {
        if (!WolfOn)
        {
            if (WoflTimer <= 0)
            {
                //stickFlag.WolfOn = true;
               // WolfOn = true;
                //Wolf.SetActive(true);
                WoflTimer = resettimer;
            }
            else
            {
                WoflTimer -= Time.deltaTime;

            }
        }

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
            Player.transform.Rotate(0, -5, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && CanThrowStick)
        {
            StickThrowSound.Play();
            stickFlag.SoundPlayed = false;
            GameObject shellInstance = GameObject.Instantiate(StickObject, FireTarget.transform);
            shellInstance.GetComponent<Rigidbody>().AddForce(200, 4, 2000);
            shellInstance.transform.SetParent(null);
            stickFlag.StickThrow = true;
            NumberOfSticks -= 1;

            if (NumberOfSticks <= 0)
            {
                CanThrowStick = false;
            }

            //stickFlag.WolfOn = false;
            //WolfOn = false;
            //Wolf.SetActive(false);
        }
        if (Input.GetKey(KeyCode.E))
        {
            Player.transform.Rotate(0,5,0);
       } 
        HorzMovement *=Time.deltaTime;
        VertMovement *=Time.deltaTime;
        //Vector3 Movement = new Vector3(HorzMovement, 0 , VertMovement);
        //PlayerBody.AddForce(Movement * Speed);
        Player.transform.Translate(HorzMovement * Speed,0,VertMovement * Speed);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wolf")
        {
            stickFlag.Growl.Play();
            if (!GameOverShown)
            {
                mManagerObject.ShowGameOver(gameOver);
                GameOverShown = true;
            }

        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("HedgeMaze");
    }
}
