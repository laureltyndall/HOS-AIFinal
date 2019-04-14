using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HOS;

public class AnimalAI : MonoBehaviour {

    Animator anim;
    public GameObject Target;
    
    public GameObject GetTarget()
    {
        return Target;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        anim.SetFloat("distance", Vector3.Distance(transform.position, Target.transform.position));
        
    }
}
