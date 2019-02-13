using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using HOS;

public class MouseController : MonoBehaviour {

    public Camera cam;
    public NavMeshAgent agent;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(r, out hit))
            {
                //Move Our Mouse Agent
                agent.SetDestination(hit.point);
            }
        }
		
	}
}
