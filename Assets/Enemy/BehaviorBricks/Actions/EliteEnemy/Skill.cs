using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using System;
using Platformer.Enemy;
using UnityEngine;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to release skill.
    /// </summary>
    [Action("Navigation/Skill")]
    [Help("Release specific skill.")]
    public partial class Skill : GOAction
    {
        // Set skill before time.
        [InParam("Skill Before")]
        public float skillBefore;

        // Get enemy data.
        private EnemyData enemyData;
        private Enemy enemy;

        // Get skill animation CD.
        private float skillAniCD;
        private float skillBeforeCD;

        /// <summary>Initialization Method of Skill.</summary>
        public override void OnStart()
        {
            enemyData = gameObject.GetComponent<EnemyData>();
            enemyData.isReleasingSkill = true;
            enemyData.state = EnemyState.Skill_1;
        }

        /// <summary>Method of Update of HitPlayer </summary>
        /// <remarks>Enemy will hit player at once.</remarks>
        public override TaskStatus OnUpdate()
        {
            if (!enemyData.isReleasingSkill)
            {
                return TaskStatus.COMPLETED;
            }
            return TaskStatus.RUNNING;
        }
    }
}
