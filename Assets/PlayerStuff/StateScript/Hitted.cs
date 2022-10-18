using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitted : StateMachineBehaviour
{
    private GameObject Player;

    private void Awake()
    {
        Player = GameObject.Find("Player");
    }

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player.GetComponent<PlayerController>().canControl = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player.GetComponent<PlayerController>().canControl = true;
    }
}
