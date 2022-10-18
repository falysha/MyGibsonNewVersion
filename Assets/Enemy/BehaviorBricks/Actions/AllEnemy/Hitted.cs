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
    [Action("Navigation/Hitted")]
    [Help("Enemy hitted by player.")]
    public partial class Hitted : GOAction
    {
        private EnemyData enemyData;
        // The time enemy needed to play the hit animation
        private float hittedTime;

        /// <summary>Initialization Method of HitPlayer.</summary>
        public override void OnStart()
        {
            //Debug.Log("Hitted");
            enemyData = gameObject.GetComponent<EnemyData>();
            hittedTime = enemyData.hittedTime;
            enemyData.state = EnemyState.Hitted;
        }

        /// <summary>Method of Update of HitPlayer </summary>
        /// <remarks>Enemy will hit player at once.</remarks>
        public override TaskStatus OnUpdate()
        {
            hittedTime -= Time.deltaTime;
            if (hittedTime < 0)
            {
                enemyData.isHitted = false;
                return TaskStatus.COMPLETED;
            }
            return TaskStatus.RUNNING;
        }
    }
}
