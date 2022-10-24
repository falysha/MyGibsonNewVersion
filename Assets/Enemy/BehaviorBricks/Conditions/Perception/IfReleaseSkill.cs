using Pada1.BBCore;
using Platformer.Enemy;
using UnityEngine;

namespace BBUnity.Conditions
{
    /// <summary>
    /// It is a perception condition to check if the skill is prepared.
    /// </summary>
    [Condition("Perception/IfReleaseSkill")]
    [Help("Checks whether a skill prepared")]
    public class IfReleaseSkill : GOCondition
    {
        // Get enemy Data
        private EnemyData enemyData;

        /// <summary>
        /// Get data from enemyData script directly,
        /// </summary>
        /// <returns>True if the skill prepared.</returns>
        public override bool Check()
        {
            // Debug.Log("IfCanReleaseSkill");
            enemyData = gameObject.GetComponent<EnemyData>();
            // Skill is releasing
            if(enemyData.ifSkillPrepared&&(enemyData.state== EnemyState.Skill_1|| 
                enemyData.state == EnemyState.Skill_2|| enemyData.state == EnemyState.Skill_3))
            {
                return true;
            }
            if (enemyData.state != EnemyState.Hitted && enemyData.state != EnemyState.Attack && enemyData.state != EnemyState.Die) 
            {
                if(enemyData.SkillAllowed == true&& enemyData.ifSkillPrepared == true)
                {
                    //Debug.Log(enemyData.ifCanReleaseSkill);
                    //Debug.Log("出错啦！");
                    return true;
                }
            }
            return false;
        }
    }
}