using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RocketLaunch : StateMachineBehaviour
{
    private TimeCounter _timeCounter;
    private void Awake()
    {
        _timeCounter = FindObjectOfType<TimeCounter>();
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timeCounter._PlayerController.canControl = false;
        _timeCounter._PlayerController.Stoic = true;
        _timeCounter.startRocket();
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timeCounter._PlayerController.canControl = true;
        _timeCounter._PlayerController.Stoic = false;
    }
}
