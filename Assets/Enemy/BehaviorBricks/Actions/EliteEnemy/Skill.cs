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
            Debug.Log("Skill");
            enemyData = gameObject.GetComponent<EnemyData>();
            enemy = gameObject.GetComponent<Enemy>();
            skillAniCD = enemyData.skillTime;
            skillBeforeCD = skillBefore;
            enemyData.state = EnemyState.Skill_1;
        }

        /// <summary>Method of Update of HitPlayer </summary>
        /// <remarks>Enemy will hit player at once.</remarks>
        public override TaskStatus OnUpdate()
        {
            skillAniCD -= Time.deltaTime;
            // a Timer that record when to fire attack event
            if (skillBeforeCD != -1)
            {
                skillBeforeCD -= Time.deltaTime;
                if (skillBeforeCD <= 0) 
                {
                    // Fire skill event
                    enemy.ExecuteSkill();
                    skillBeforeCD = -1;
                }
            }
            if (skillAniCD <= 0)
            {
                 Debug.Log("技能结束");
                enemyData.ifSkillPrepared = false;
            }
            return TaskStatus.RUNNING;
        }
    }
}
