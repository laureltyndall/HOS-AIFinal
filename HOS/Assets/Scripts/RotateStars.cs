using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStars : MonoBehaviour {

    private Vector3 TargetAngle = new Vector3(270f, 0f, 0f);
    private Vector3 currentangle;
    public bool StarsTurning = false;

    // Use this for initialization
    void Start () {
        currentangle = transform.eulerAngles;

    }
	
	// Update is called once per frame
	void Update () {
		if(StarsTurning)
        {
            currentangle = new Vector3(
             Mathf.LerpAngle(currentangle.x, TargetAngle.x, Time.deltaTime),
             Mathf.LerpAngle(currentangle.y, TargetAngle.y, Time.deltaTime),
             Mathf.LerpAngle(currentangle.z, TargetAngle.z, Time.deltaTime));

            transform.eulerAngles = currentangle;
        }
	}
}
