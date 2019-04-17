using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfAI : MonoBehaviour {

    Animator anim;
    public GameObject Target;
    public bool StickThrow;
    NavMeshAgent _navigation;
    public AudioSource Bark;
    public AudioSource Growl;
    public bool SoundPlayed = false;

    public bool WolfOn = true;

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
        if (WolfOn)
        {
            if (StickThrow)
            {
                if (!SoundPlayed)
                {
                    Bark.Play();
                    SoundPlayed = true;
                }
                GameObject go = GameObject.FindGameObjectWithTag("Stick");
                Target = GameObject.FindGameObjectWithTag("Stick");
                anim.SetFloat("distance", Vector3.Distance(transform.position, go.transform.position));
            }

            else
            {
                if (!SoundPlayed)
                {
                    Growl.Play();
                    SoundPlayed = true;
                }
                Target = GameObject.FindGameObjectWithTag("ActiveMovementPlayer");
                anim.SetFloat("distance", Vector3.Distance(transform.position, Target.transform.position));
            }
        }
        else
        {

        }
        //MyAnimation = GetComponentInChildren<Animation>();
        //MyAnimation.Play("Run");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Stick")
        {
            //GameScript.m_GameWinner = true;
            SoundPlayed = false;

        }
    }
}
