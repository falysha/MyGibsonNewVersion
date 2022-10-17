using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using System;
using Platformer.Enemy;
using UnityEngine;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to move the GameObject to a random position in an area using a NavMeshAgent.
    /// </summary>
    [Action("Navigation/KeepStillUntilAttack")]
    [Help("Keep still in specific place until next attack.")]
    public partial class KeepStillUntilAttack : GOAction
    {
        private EnemyData enemyData;

        /// <summary>Initialization Method of KeepStillUntilAttack.</summary>
        public override void OnStart()
        {
            //Debug.Log("KeepStill");
            enemyData = gameObject.GetComponent<EnemyData>();
            enemyData.state = EnemyState.Idle;
        }

        /// <summary>Method of Update of KeepStillUntilAttack </summary>
        /// <remarks>Enemy will keep still until attack player or player run away.</remarks>
        public override TaskStatus OnUpdate()
        {
            if (enemyData.ifCanAttack || !enemyData.ifPlayerCanBeAttacked) 
                return TaskStatus.COMPLETED;
            return TaskStatus.RUNNING;
        }
    }
}
