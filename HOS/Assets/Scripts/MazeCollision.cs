using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision Collider)
    {
        if (Collider.gameObject.tag == "PlayerAnne" || Collider.gameObject.tag == "PlayerAlex")
        {
            Debug.Log("Ding");
        }
    }
}
