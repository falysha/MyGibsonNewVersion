using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : StateMachineBehaviour
{
    private GameObject Player;
    private Rigidbody2D _rigidbody2D;
    private PlayerController _playerController;
    private Vector2 Direction;

    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player=GameObject.Find("Player");
        Direction.x = Player.transform.localScale.x;
        Direction.y = 0;
        _playerController = Player.GetComponent<PlayerController>();
        _rigidbody2D = Player.GetComponent<Rigidbody2D>();
        _playerController.flashing = true;
        _rigidbody2D.AddForce(Direction*_playerController.Strength,ForceMode2D.Impulse);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    /*override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       _rigidbody2D.AddForce(Direction*20,ForceMode2D.Impulse);
    }*/

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerController.flashing = false; 
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
