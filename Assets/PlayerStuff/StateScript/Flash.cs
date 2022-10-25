using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : StateMachineBehaviour
{
    private GameObject Player;
    private Rigidbody2D _rigidbody2D;
    private PlayerController _playerController;
    private Vector2 Direction;
    private PlayerHealth _playerHealth;
    private void Awake()
    {
        Player = GameObject.Find("Player");
        _playerHealth = Player.GetComponent<PlayerHealth>();
        _playerController = Player.GetComponent<PlayerController>();
        _rigidbody2D = Player.GetComponent<Rigidbody2D>();
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerController.canControl = false;
        _playerController.Stoic = true;
        _playerHealth.locked = true;
        Direction.x = Player.transform.localScale.x;
        Direction.y = 0;
        _playerController.flashing = true;
        _rigidbody2D.AddForce(Direction * _playerController.Strength, ForceMode2D.Impulse);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerHealth.locked = false;
        _playerController.flashing = false;
        _playerController.canControl = true;
        _playerController.Stoic = false;
    }

}