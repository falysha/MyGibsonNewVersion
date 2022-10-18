using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeStateCheck : StateMachineBehaviour
{
    private PlayerController Player;

    private PlayerController.KnifeState current;

    private void Awake()
    {
        Player = FindObjectOfType<PlayerController>();
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        current = Player._knifeState;
        Player.canControl = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.J) && current == Player._knifeState)
        {
            Player._animator.SetTrigger("knife");
            Player._knifeState = (PlayerController.KnifeState)(((int)current + 1) % 5);
            
        }
    }
}