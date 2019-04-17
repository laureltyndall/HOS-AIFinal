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
	   
	}
	
	// Update is called once per frame
	void Update () {
        Manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    void OnCollisionEnter(Collision Collider)
    {
        if (Collider.gameObject.tag == "ActiveMovementPlayer")
        {
            Manager.CurrentPlayer.gameObject.SetActive(true);
            Manager.CenterFromMaze = true;
            SceneManager.LoadScene("HedgeMazeCenter");
            Debug.Log("Ding");
        }
    }
}
