﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfAI : MonoBehaviour {

    Animator anim;
    public GameObject Target;
    public bool StickThrow;
    NavMeshAgent _navigation;
    
    
    //public MouseGameManager GameScript;
    //public Animation MyAnimation;

    public GameObject GetTarget()
    {
        return Target;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        _navigation = this.GetComponent<NavMeshAgent>();

      
        //GameObject go = GameObject.FindGameObjectWithTag("GameManager");
        //GameScript = go.GetComponent<MouseGameManager>();
        //MyAnimation = GetComponentInChildren<Animation>();
        //MyAnimation.Play("Run");
    }

   

    private void Update()
    {
        if (StickThrow)
        {
            Target = GameObject.FindGameObjectWithTag("Stick");
            anim.SetFloat("distance", Vector3.Distance(transform.position, Target.transform.position));
        }

        else
        {
            Target = GameObject.FindGameObjectWithTag("ActiveMovementPlayer");
            anim.SetFloat("distance", Vector3.Distance(transform.position, Target.transform.position));
        }
        //MyAnimation = GetComponentInChildren<Animation>();
        //MyAnimation.Play("Run");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "USABLE BOX" || collision.gameObject.name == "USABLE BOX (1)" || collision.gameObject.name == "USABLE BOX (2)")
        {
            //GameScript.m_GameWinner = true;
            Destroy(this.gameObject);
        }
    }
}
