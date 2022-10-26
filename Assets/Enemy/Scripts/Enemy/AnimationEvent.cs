using Platformer.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Enemy
{
    public class AnimationEvent : MonoBehaviour
    {
        private Enemy enemy;
        private EnemyData enemyData;
        private Rigidbody2D rigidbody2D;

        private void Start()
        {
            enemy = GetComponent<Enemy>();
            enemyData = GetComponent<EnemyData>();
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void FireHitEvent()
        {
            if (enemy.IfPlayerHitted())
            {
                Debug.Log("FireHitEvent");
                var ev = Schedule<PlayerHitted>();
                ev.enemyTransform = gameObject.transform;
                ev.damage = enemyData.damage;
            }
        }

        public void FireSkillEvent()
        {
            enemy.ExecuteSkill();
        }

        public void EndupAttackState()
        {
            enemyData.state = EnemyState.Idle;
            // Debug.Log("EndupAttackState");
            enemyData.isAttacking = false;
            enemyData.ifCanAttack = false;
        }

        public void EndupSkillState()
        {
            enemyData.ifSkillPrepared = false;
            enemyData.isReleasingSkill = false;
        }

        public void EndupHittedState()
        {
            enemyData.isHitted = false;
        }

        public void FireDiedEvent()
        {
            Destroy(gameObject);
        }

        public void ClearVelocity()
        {
            rigidbody2D.velocity = new Vector2(0, 0);
        }
    }
}
