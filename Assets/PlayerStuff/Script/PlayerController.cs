using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;



    public class PlayerController : MonoBehaviour
    {
        // Start is called before the first frame update
        public float horizontalMoveSpeed = 10;
        public float Strength = 10;
        public JumpState jumpState = JumpState.Grounded;
        public bool canControl = true;
        public Rigidbody2D _rigidbody2D;
        public Animator _animator;
        private Collider2D _collider2D;
        public Vector2 move;
        private int right = 2;//人物朝向
        private int left = 1;
        public bool isGrounded = true;
        public KnifeState _knifeState = KnifeState.Knife0;
        public bool flashing = false;
        private Rocket _rocket;
        private SkillController _skillController;
        public Object[] gunFire;
        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _collider2D = GetComponent<Collider2D>();
            _animator.SetLayerWeight(right, 1);
            _animator.SetLayerWeight(left, 0);
            _rocket = FindObjectOfType<Rocket>();
            _skillController = GetComponent<SkillController>();
            gunFire = FindObjectsOfType(typeof(Gunfire));
        }

        // Update is called once per frame
        void Update()
        {
            if (canControl&&!flashing)
            {
                jumpStateCheck();
                horizontalMove();
                knifeAttackStateIn();
                if (jumpState == JumpState.Grounded && Input.GetKeyDown(KeyCode.W))//跳跃
                {
                    jumpState = JumpState.PrepareToJump;
                    startJump();
                    _animator.SetTrigger("jump");
                }
                
                if (jumpState == JumpState.Grounded && Input.GetKeyDown(KeyCode.L))//闪现
                {
                    _animator.SetTrigger("flash");
                }

                if (jumpState == JumpState.Grounded && Input.GetKeyDown(KeyCode.U)&&!_rocket.fired&&_skillController.isRocketReady)//火箭
                {
                    _animator.SetTrigger("rocket");
                    _skillController.startCountingRocket();
                }

                if (jumpState == JumpState.Grounded && Input.GetKeyDown(KeyCode.I)&&_skillController.isShotGunReady)//霰弹枪
                {
                    _animator.SetTrigger("shotgun");
                    _skillController.startCountingShotGun();
                }
                
                if (jumpState == JumpState.Grounded && Input.GetKeyDown(KeyCode.O)&&_skillController.isHackReady)//大招
                {
                    _animator.SetTrigger("hack");
                    _skillController.startCountingHack();
                }

                if (jumpState == JumpState.Grounded && Input.GetKeyDown(KeyCode.Q))
                {
                    _skillController.speedUpStart();
                }

                if (jumpState == JumpState.Grounded && Input.GetKeyDown(KeyCode.E))
                {
                    _skillController.speedDownStart();
                }
                
            }
            /*else if(!canControl&&!flashing)
            {
                move.x = 0;
            }*/
            verticalSpeedCheck();
        }

        void knifeAttackStateIn()
        {
            if (_knifeState==KnifeState.Knife0&&Input.GetKeyDown(KeyCode.J))
            {
                _animator.SetTrigger("knife");
                canControl = false;
            }
        }
        void verticalSpeedCheck()
        {
            if (_rigidbody2D.velocity.y<-0.01)
            {
                _animator.SetBool("falling",true);
            }
            else
            {
                _animator.SetBool("falling",false);
            }
            
        }
        //水平移动部分的代码，同时兼顾了左右状态下动画机层级的切换
        void horizontalMove()
        {
            move.x = Input.GetAxis("Horizontal");
            if (move.x!=0)
            {
                _animator.SetBool("run",true);
            }
            else
            {
                _animator.SetBool("run",false);
            }
            _rigidbody2D.velocity = move * horizontalMoveSpeed + Vector2.up * _rigidbody2D.velocity.y;
            if (move.x > 0.01f)
            {
                _animator.SetLayerWeight(right, 1);
                _animator.SetLayerWeight(left, 0);
                gameObject.transform.localScale=Vector3.one;
            }
            else if (move.x < -0.01f)
            {
                _animator.SetLayerWeight(left, 1);
                _animator.SetLayerWeight(right, 0);
                gameObject.transform.localScale=Vector3.one+Vector3.left*2;
            }
        }
        
        void jumpStateCheck()
        {
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    break;
                case JumpState.Jumping:
                    if (!isGrounded)
                    {
                        //该事件需要播放跳跃音效
                        //Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;
                    }

                    break;
                case JumpState.InFlight:
                    if (isGrounded)
                    {
                        //需要加上下落攻击的音效播放
                        //Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                    }

                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }

        void startJump()
        {
            _rigidbody2D.AddForce(Vector2.up * 28, ForceMode2D.Impulse);
        }

        void groundCheck()
        {
            if (_collider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }

        private void FixedUpdate()
        {
            groundCheck();
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
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
