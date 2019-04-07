using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWorm : MonoBehaviour
{
    public bool DestroyThis = false;
    public float Timer = 0.00f;
    public float TimerReset = 5.00f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        if (DestroyThis)
        {
            Destroy(this.gameObject);
        }
        
        if (Timer >= TimerReset)
        {
            DestroyThis = true;
        }
        Timer += Time.deltaTime;
	}
}
