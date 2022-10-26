using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Object = UnityEngine.Object;


public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float horizontalMoveSpeed = 8;
    public float Strength = 10;
    public JumpState jumpState = JumpState.Grounded;
    public bool canControl = true;
    public Rigidbody2D _rigidbody2D;
    public Animator _animator;
    private Collider2D _collider2D;
    private Vector2 move;
    private int right = 2; //人物朝向
    private int left = 1;
    private bool isGrounded = true;
    public KnifeState _knifeState = KnifeState.Knife0;
    public bool flashing = false;
    private SkillController _skillController;
    private Hack _hack;
    public bool Stoic = false;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _collider2D = GetComponent<Collider2D>();
        _animator.SetLayerWeight(right, 1);
        _animator.SetLayerWeight(left, 0);
        _skillController = GetComponent<SkillController>();
        _hack = GameObject.Find("Hack").GetComponent<Hack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canControl && !flashing && GameManager.instance.State == GameState.IsPlaying)
        {
            horizontalMove();
            knifeAttackStateIn();
            if (jumpState == JumpState.Grounded && Input.GetKeyDown(KeyCode.W)) //跳跃
            {
                jumpState = JumpState.Jumping;
                startJump();
                _animator.SetTrigger("jump");
            }

            if (jumpState == JumpState.Grounded && Input.GetKeyDown(KeyCode.L)&&_skillController.isFlashReady) //闪现
            {
                _animator.SetTrigger("flash");
                _skillController.startCountingFlash();
            }

            if (jumpState == JumpState.Grounded && Input.GetKeyDown(KeyCode.U) && GameManager.instance.haveskill &&_skillController.isRocketReady
               ) //火箭
            {
                _animator.SetTrigger("rocket");
                _skillController.startCountingRocket();
            }

            if (jumpState == JumpState.Grounded && Input.GetKeyDown(KeyCode.I) && GameManager.instance.haveskill&&_skillController.isShotGunReady
               ) //霰弹枪
            {
                _animator.SetTrigger("shotgun");
                _skillController.startCountingShotGun();
            }

            if (jumpState == JumpState.Grounded && Input.GetKeyDown(KeyCode.O) && GameManager.instance.haveskill&&_skillController.isHackReady) //大招
            {
                _hack.startAttack();
                _skillController.startCountingHack();
            }

            if (jumpState == JumpState.Grounded && Input.GetKeyDown(KeyCode.Q) && GameManager.instance.havespeed)
            {
                _skillController.speedUpStart();
            }

            if (jumpState == JumpState.Grounded && Input.GetKeyDown(KeyCode.E) && GameManager.instance.havespeed)
            {
                _skillController.speedDownStart();
            }
        }
    }

    void knifeAttackStateIn()
    {
        if (_knifeState == KnifeState.Knife0 && Input.GetKeyDown(KeyCode.J))
        {
            _animator.SetTrigger("knife");
            canControl = false;
        }
    }

    void verticalSpeedCheck()
    {
        if (_rigidbody2D.velocity.y < -0.001&&!isGrounded)
        {
            _animator.SetBool("falling", true);
            jumpState = JumpState.Jumping;
        }
        else
        {
            _animator.SetBool("falling", false);
        }
    }

    //水平移动部分的代码，同时兼顾了左右状态下动画机层级的切换
    void horizontalMove()
    {
        move.x = Input.GetAxis("Horizontal");
        if (move.x != 0)
        {
            _animator.SetBool("run", true);
        }
        else
        {
            _animator.SetBool("run", false);
        }

        _rigidbody2D.velocity = move * horizontalMoveSpeed + Vector2.up * _rigidbody2D.velocity.y;
        if (move.x > 0.01f)
        {
            _animator.SetLayerWeight(right, 1);
            _animator.SetLayerWeight(left, 0);
            gameObject.transform.localScale = Vector3.one;
        }
        else if (move.x < -0.01f)
        {
            _animator.SetLayerWeight(left, 1);
            _animator.SetLayerWeight(right, 0);
            gameObject.transform.localScale = Vector3.one + Vector3.left * 2;
        }
    }
    

    void startJump()
    {
        _rigidbody2D.AddForce(Vector2.up * 28, ForceMode2D.Impulse);
    }

    void groundCheck()
    {
        if ((_rigidbody2D.velocity.y<0.01f&&_rigidbody2D.velocity.y>=-0.01f)&&_collider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            isGrounded = true;
            jumpState = JumpState.Grounded;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        groundCheck();
        verticalSpeedCheck();
    }

    public enum JumpState
    {
        Grounded,
        Jumping
    }


    public enum KnifeState
    {
        Knife0,
        Knife1,
        Knife2,
        Knife3,
        Knife4,
    }
}