using UnityEngine;

namespace Platformer.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    /// <summary>
    /// the base class of enemy
    /// </summary>
    public abstract class Enemy: MonoBehaviour
    {
        /// <summary>
        /// the base data of enemy
        /// </summary>
        protected EnemyData data;
        protected BehaviorExecutor behaviorExecutor;

        protected float attackCD;
        protected float skillCD;


        /// <summary>
        /// Animator attached to the enemy.
        /// </summary>
        private Animator animator;

        private void Awake()
        {
            data = GetComponent<EnemyData>();
            animator = GetComponent<Animator>();
            behaviorExecutor = GetComponent<BehaviorExecutor>();
            attackCD = data.attackCD;
            skillCD = data.skillCD;
        }

        private void FixedUpdate()
        {
            animator.SetInteger("state", (int)data.state);
            animator.SetBool("IfFaceRight", data.ifFaceRight);
            //CheckAttack();
            CheckAlive();
            RefreshState();
            CheckAttack();
            CheckSkill();
        }

        public virtual void RefreshState() { }

        public virtual void ExecuteSkill() { }

        // Check if enemy still alive
        private void CheckAlive()
        {
            if (data.HP <= 0 && data.state != EnemyState.Die) 
            {
                behaviorExecutor.enabled = false;
                data.state = EnemyState.Die;
                Destroy(gameObject, data.diedTime);
            }
        }

        // Check if enemy can attack player
        private void CheckAttack()
        {
            if (data.ifCanAttack == false)
            {
                attackCD -= Time.deltaTime;
                if (attackCD <= 0)
                {
                    attackCD = data.attackCD;
                    data.ifCanAttack = true;
                }
            }
        }

        // Check if enemy can release skill
        private void CheckSkill()
        {
            if (data.ifSkillPrepared == false)
            {
                skillCD -= Time.deltaTime;
                if (skillCD <= 0)
                {
                    skillCD = data.skillCD;
                    data.ifSkillPrepared = true;
                }
            }
        }
    }

    enum Type
    {
        NORMAL_FAR,
        NORMAL_CLOSE,
        BLOOD_RECOVER,
        FLEXIBLE
    };
}
