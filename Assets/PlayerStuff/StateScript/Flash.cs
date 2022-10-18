using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : StateMachineBehaviour
{
    private GameObject Player;
    private Rigidbody2D _rigidbody2D;
    private PlayerController _playerController;
    private Vector2 Direction;

    private void Awake()
    {
        Player = GameObject.Find("Player");
        _playerController = Player.GetComponent<PlayerController>();
        _rigidbody2D = Player.GetComponent<Rigidbody2D>();
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerController.canControl = false;
        Direction.x = Player.transform.localScale.x;
        Direction.y = 0;
        _playerController.flashing = true;
        _rigidbody2D.AddForce(Direction * _playerController.Strength, ForceMode2D.Impulse);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerController.flashing = false;
        _playerController.canControl = true;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}