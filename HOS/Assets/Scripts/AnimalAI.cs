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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "USABLE BOX" || collision.gameObject.name == "USABLE BOX (1)" || collision.gameObject.name == "USABLE BOX (2)")
        {
            Destroy(this.gameObject);
        }
    }
}
