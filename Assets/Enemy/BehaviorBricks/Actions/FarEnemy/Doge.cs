using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using System;
using Platformer.Enemy;
using UnityEngine;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to doge when player walk too close.
    /// </summary>
    [Action("Navigation/Doge")]
    [Help("Doge when player walk too close.")]
    public partial class Doge : GOAction
    {
        private EnemyData enemyData;
        /// <summary>Initialization Method of Doge.</summary>
        public override void OnStart()
        {
            //Debug.Log("KeepStill");
            enemyData = gameObject.GetComponent<EnemyData>();
        }

        /// <summary>Method of Update of Doge </summary>
        /// <remarks>Enemy will doge when player walk too close.</remarks>
        public override TaskStatus OnUpdate()
        {
            if (enemyData.ifPlayerCanBeAttacked)
                return TaskStatus.COMPLETED;
            return TaskStatus.RUNNING;
        }
    }
}
