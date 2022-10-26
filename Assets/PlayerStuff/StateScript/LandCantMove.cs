using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandCantMove : StateMachineBehaviour
{
    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerController.canControl = false;
       // _playerController._rigidbody2D.velocity = Vector2.zero;
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerController.canControl = true;
    }
}
