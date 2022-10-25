using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Smash : StateMachineBehaviour
{
    private TimeCounter _timeCounter;
    private void Awake()
    {
        _timeCounter = FindObjectOfType<TimeCounter>();
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timeCounter._PlayerController.Stoic = true;
        _timeCounter._PlayerController.canControl = false;
        _timeCounter.startSmash();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // _timeCounter._PlayerController.canControl = true;
        _timeCounter._PlayerController.Stoic = false;
    }
}
