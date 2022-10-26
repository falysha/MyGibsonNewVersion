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

        private void Start()
        {
            enemy = GetComponent<Enemy>();
            enemyData = GetComponent<EnemyData>();
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
    }
}
