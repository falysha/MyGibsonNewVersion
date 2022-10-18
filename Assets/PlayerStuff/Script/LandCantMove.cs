using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandCantMove : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.Find("Player").GetComponent<PlayerController>().canControl = false;
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.Find("Player").GetComponent<PlayerController>().canControl = true;
    }
}
