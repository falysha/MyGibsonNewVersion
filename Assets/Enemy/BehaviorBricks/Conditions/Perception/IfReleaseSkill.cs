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
            if(enemyData.isReleasingSkill)
            {
                return true;
            }
            if (enemyData.state==EnemyState.Idle|| enemyData.state == EnemyState.Walk) 
            {
                if (enemyData.SkillAllowed == true && enemyData.ifSkillPrepared == true) 
                {
                    //Debug.Log(enemyData.ifCanReleaseSkill);
                    return true;
                }
            }
            return false;
        }
    }
}