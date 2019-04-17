using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using HOS;

public class WolfChase : WolfBaseFSM {

    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //var direction = WolfOppenent.transform.position - WolfNPC.transform.position;
        //WolfNPC.transform.rotation = Quaternion.Slerp(WolfNPC.transform.rotation,
        //    Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
        WolfNavAgent.SetDestination(WolfOppenent.transform.position);

        WolfNPC.transform.Translate(0, 0, Time.deltaTime * speed);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    //private void SetDestination()
    //{
    //    if (_destination != null)
    //    {
    //        Vector3 targetVector = _destination.transform.position;
    //        _nav.SetDestination(targetVector);
    //    };
    //}
}
