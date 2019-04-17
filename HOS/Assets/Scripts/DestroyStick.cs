using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStick : MonoBehaviour 
{
    public WolfAI WolfObj;
	// Use this for initialization
	void Start () 
    {
		WolfObj = GameObject.FindGameObjectWithTag("Wolf").GetComponent<WolfAI>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collide)
    {
        if (collide.transform.tag == "Wolf")
        {
            WolfObj.StickThrow = false;
            Destroy(this.gameObject);
        }
    }
}
