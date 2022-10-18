using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class Shotgun : StateMachineBehaviour
{
    private TimeCounter _timeCounter;
    private void Awake()
    {
        _timeCounter = FindObjectOfType<TimeCounter>();
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        _timeCounter.starShotGun();
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // _timeCounter._PlayerController.canControl = true;
    }
}
