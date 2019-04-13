using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HOS;

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

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Crow")
        {
            Controller.IsCrowDistracted = true;
        }

        if (collision.gameObject.name == "Crow" && Vector3.Distance(this.transform.position, collision.transform.position) <= 4 && Controller.IsCrowDistracted == true)
        {
            Controller.TimesCrowDistracted += 1;
            Destroy(this.gameObject);
            Controller.IsCrowDistracted = false;
        }
    }
}
