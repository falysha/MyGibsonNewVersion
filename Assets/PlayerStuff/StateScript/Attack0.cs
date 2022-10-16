using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack0 : StateMachineBehaviour
{
    private GameObject Player;
    private int timer=0;
    private bool shot = false;
     //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.Find("Player");
        Vector2 Direction = new Vector2(Player.transform.localScale.x, 0);
        Player.GetComponent<Rigidbody2D>().AddForce(Direction*5,ForceMode2D.Impulse);
        FindObjectOfType<Gunshot>().gunShotOnce();
        Player.GetComponent<PlayerController>().gunFire[5].GetComponent<Gunfire>().gunFire();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer ++;
        if (timer>=54&&!shot)
        {
            shot=true;
            FindObjectOfType<Gunshot>().gunShotOnce();
            Player.GetComponent<PlayerController>().gunFire[4].GetComponent<Gunfire>().gunFire();
        }
        
    }
    
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        shot = false;
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
