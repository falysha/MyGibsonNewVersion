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
    [Action("Navigation/KeepStillUntilMove")]
    [Help("Keep still in specific place until next move.")]
    public partial class KeepStillUntilMove : GOAction
    {
        [InParam("duration")]
        [Help("How long the enemy keep still.")]
        public float stillDuration;

        private EnemyData enemyData;

        /// <summary>Initialization Method of KeepStillUntilMove.</summary>
        public override void OnStart()
        {
            //Debug.Log("KeepStill");
            enemyData = gameObject.GetComponent<EnemyData>();
        }

        /// <summary>Method of Update of KeepStillUntilMove </summary>
        /// <remarks>Enemy will keep still until time ended or player in field.</remarks>
        public override TaskStatus OnUpdate()
        {
            stillDuration -= Time.deltaTime;
            if (enemyData.isPlayerInAttackField || stillDuration <= 0)
                return TaskStatus.COMPLETED;
            return TaskStatus.RUNNING;
        }
    }
}
