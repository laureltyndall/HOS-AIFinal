using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCollisionItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + " his collided with " + this.name);
        collision.rigidbody.velocity = new Vector3(0, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
