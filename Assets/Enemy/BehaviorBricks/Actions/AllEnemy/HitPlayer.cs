using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using System;
using UnityEngine;
using Platformer.Enemy;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to move the GameObject to a random position in an area using a NavMeshAgent.
    /// </summary>
    [Action("Navigation/HitPlayer")]
    [Help("Hit Player and make some damage to player.")]
    public partial class HitPlayer : GOAction
    {
        [InParam("hitBefore")]
        [Help("The time enemy needed to prepare the hit.")]
        public float hitBefore;

        private EnemyData enemyData;
        private Enemy enemy;
        private float attackAniTime;

        /// <summary>Initialization Method of HitPlayer.</summary>
        public override void OnStart()
        {
            //Debug.Log("HitPlayer");
            enemyData = gameObject.GetComponent<EnemyData>();
            enemy = gameObject.GetComponent<Enemy>();
            attackAniTime = enemyData.attackAniTime;
            enemyData.ifFaceRight = enemyData.player.transform.position.x - gameObject.transform.position.x > 0 ? true : false;
            enemyData.state = EnemyState.Attack;
        }

        /// <summary>Method of Update of HitPlayer </summary>
        /// <remarks>Enemy will hit player at once.</remarks>
        public override TaskStatus OnUpdate()
        {
            attackAniTime -= Time.deltaTime;
            // a Timer that record when to fire attack event
            if (hitBefore != -1)
                hitBefore -= Time.deltaTime;
            if (hitBefore <= 0) 
            {
                // Fire attack event
                if (enemy.IfPlayerHitted())
                {
                    var ev = Schedule<PlayerHitted>();
                    ev.enemyTransform = gameObject.transform;
                    ev.damage = enemyData.damage;
                }
                hitBefore = -1;
            }
            if (attackAniTime <= 0)
            {
                enemyData.ifCanAttack = false;
                return TaskStatus.COMPLETED;
            }
            return TaskStatus.RUNNING;
        }
    }
}
