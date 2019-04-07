using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWorm : MonoBehaviour
{
    public bool DestroyThis = false;
    public float Timer = 0.00f;
    public float TimerReset = 5.00f;
    public CrowMinigameController Controller;  

	// Use this for initialization
	void Start () 
    {
        Controller = GameObject.FindGameObjectWithTag("CrowMinigameController").GetComponent<CrowMinigameController>();
	}
	
	// Update is called once per frame
	void Update()
    {
        if (DestroyThis)
        {
            Controller.IsCrowDistracted = false;
            Destroy(this.gameObject);
        }
        
        if (Timer >= TimerReset)
        {
            DestroyThis = true;
        }
        Timer += Time.deltaTime;
	}

    void OnTriggerEnter(Collider Collision)
    {
        if (Collision.gameObject.name == "Crow")
        {
            Controller.IsCrowDistracted = true;
        }
    }
}
