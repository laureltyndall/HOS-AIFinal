using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStick : MonoBehaviour 
{
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collide)
    {
        if (collide.transform.tag == "Wolf")
        {
            Destroy(this.gameObject);
        }
    }
}
