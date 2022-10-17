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

        private void Awake()
        {
            data = GetComponent<EnemyData>();
            behaviorExecutor = GetComponent<BehaviorExecutor>();
            attackCD = 0;
        }

        private void FixedUpdate()
        {
            //CheckAttack();
            CheckAlive();
            RefreshState();
        }

        public virtual void RefreshState() { }

        // Check if enemy still alive
        private void CheckAlive()
        {
            if (data.HP <= 0)
            {
                behaviorExecutor.enabled = false;
                data.state = EnemyState.Die;
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
                    attackCD = 0;
                    data.ifCanAttack = true;
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
