using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Attack1 : StateMachineBehaviour
{
    private GameObject Player;
    private int timer=0;
    private int shot = 0;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.Find("Player");
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer ++;
        if (timer>=43&&shot==0)
        {
            shot++;
            FindObjectOfType<Gunshot>().gunShotOnce();
            Player.GetComponent<PlayerController>().gunFire[3].GetComponent<Gunfire>().gunFire();
        }
        if (timer>=60&&shot==1)
        {
            shot++;
            FindObjectOfType<Gunshot>().gunShotOnce();
            Player.GetComponent<PlayerController>().gunFire[2].GetComponent<Gunfire>().gunFire();
        }
        
    }
    
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        shot = 0;
    }

}
