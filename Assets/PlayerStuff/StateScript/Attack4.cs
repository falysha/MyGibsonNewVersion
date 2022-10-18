using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
public class Attack4 : StateMachineBehaviour
{
    private TimeCounter _timeCounter;
    private void Awake()
    {
        _timeCounter = FindObjectOfType<TimeCounter>();
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timeCounter._PlayerController.canControl = false;
        _timeCounter.atcing1 = true;
        _timeCounter.startAttack4();
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timeCounter.atcing1 = false;
        _timeCounter._PlayerController.canControl = true;
    }
}
