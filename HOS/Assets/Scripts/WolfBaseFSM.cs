using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using HOS;

public class WolfBaseFSM : StateMachineBehaviour
{
    public NavMeshAgent WolfNavAgent;
    public GameObject WolfNPC;
    public GameObject WolfOppenent;
    public GameObject StickTarget;
    public float speed = 2.0f;
    public float rotSpeed = 1.0f;
    public float accuracy = 3.0f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        WolfNPC = animator.gameObject;
        WolfOppenent = WolfNPC.GetComponent<WolfAI>().GetTarget();
        StickTarget = GameObject.FindGameObjectWithTag("Stick");
        WolfNavAgent = WolfNPC.GetComponent<NavMeshAgent>();

    }
}
