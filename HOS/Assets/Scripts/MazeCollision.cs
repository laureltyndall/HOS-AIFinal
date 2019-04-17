using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HOS;

public class MazeCollision : MonoBehaviour {

    public GameManager Manager;
	// Use this for initialization
	void Start () 
    {
	   //Manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision Collider)
    {
        if (Collider.gameObject.tag == "ActiveMovementPlayer")
        {
            Manager.CurrentPlayer.gameObject.SetActive(true);
            SceneManager.LoadScene("HedgeMazeCenter");
            Debug.Log("Ding");
        }
    }
}
