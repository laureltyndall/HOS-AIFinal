using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HOS;

public class WolfBaseFSM : StateMachineBehaviour
{

    public GameObject WolfNPC;
    public GameObject WolfOppenent;
    public float speed = 2.0f;
    public float rotSpeed = 1.0f;
    public float accuracy = 3.0f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        WolfNPC = animator.gameObject;
        WolfOppenent = WolfNPC.GetComponent<WolfAI>().GetTarget();
    }
}
