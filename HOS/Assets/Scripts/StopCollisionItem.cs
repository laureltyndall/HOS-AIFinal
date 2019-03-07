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
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = other.transform.position;
    }
}
