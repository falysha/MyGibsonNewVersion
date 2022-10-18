using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack2 : StateMachineBehaviour
{
    private TimeCounter _timeCounter;
    private void Awake()
    {
        _timeCounter = FindObjectOfType<TimeCounter>();
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timeCounter._PlayerController.canControl = false;
        _timeCounter.atcing2 = true;
        _timeCounter.startAttack2();
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timeCounter.atcing2 = false;
        _timeCounter._PlayerController.canControl = true;
    }
}
