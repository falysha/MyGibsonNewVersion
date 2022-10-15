using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack4 : StateMachineBehaviour
{
    private GameObject Player;
    private int timer=0;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.Find("Player");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer ++;
        if (timer==75)
        {
            FindObjectOfType<Gunshot>().gunShotOnce();
            Vector2 Direction = new Vector2(-Player.transform.localScale.x, 0);
            Player.GetComponent<Rigidbody2D>().AddForce(Direction*7,ForceMode2D.Impulse);
        }
    }
    
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
    }
}
