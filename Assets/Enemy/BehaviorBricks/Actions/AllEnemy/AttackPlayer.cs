using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using System;
using UnityEngine;
using Platformer.Enemy;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to move the GameObject to a random position in an area using a NavMeshAgent.
    /// </summary>
    [Action("Navigation/AttackPlayer")]
    [Help("Hit Player and make some damage to player.")]
    public partial class AttackPlayer : GOAction
    {
        private EnemyData enemyData;

        /// <summary>Initialization Method of HitPlayer.</summary>
        public override void OnStart()
        {
            //Debug.Log("HitPlayer");
            enemyData = gameObject.GetComponent<EnemyData>();
            enemyData.ifFaceRight = enemyData.player.transform.position.x - gameObject.transform.position.x > 0 ? true : false;
            enemyData.isAttacking = true;
            enemyData.state = EnemyState.Attack;
        }

        /// <summary>Method of Update of HitPlayer </summary>
        /// <remarks>Enemy will hit player at once.</remarks>
        public override TaskStatus OnUpdate()
        {
            if (!enemyData.isAttacking)
            {
                return TaskStatus.COMPLETED;
            }
            return TaskStatus.RUNNING;
        }
    }
}
