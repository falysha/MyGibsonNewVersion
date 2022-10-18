using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack3 : StateMachineBehaviour
{
    private TimeCounter _timeCounter;
    private void Awake()
    {
        _timeCounter = FindObjectOfType<TimeCounter>();
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timeCounter._PlayerController.canControl = false;
        _timeCounter.atcing3 = true;
        _timeCounter.startAttack3();
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timeCounter.atcing3 = false;
        _timeCounter._PlayerController.canControl = true;
    }
}
