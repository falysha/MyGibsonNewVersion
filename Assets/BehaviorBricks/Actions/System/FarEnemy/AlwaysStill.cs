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
    [Action("Navigation/AlwaysStill")]
    [Help("Always keep still except attacking player.")]
    public partial class AlwaysStill : GOAction
    {
        private EnemyData enemyData;
        /// <summary>Initialization Method of AlwaysStill.</summary>
        public override void OnStart()
        {
            //Debug.Log("KeepStill");
            enemyData = gameObject.GetComponent<EnemyData>();
        }

        /// <summary>Method of Update of AlwaysStill </summary>
        /// <remarks>Enemy will keep still until player in field.</remarks>
        public override TaskStatus OnUpdate()
        {
            if (enemyData.ifPlayerCanBeAttacked)
                return TaskStatus.COMPLETED;
            return TaskStatus.RUNNING;
        }
    }
}
