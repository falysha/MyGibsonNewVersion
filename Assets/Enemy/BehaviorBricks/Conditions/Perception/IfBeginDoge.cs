using Pada1.BBCore;
using Platformer.Enemy;

namespace BBUnity.Conditions
{
    /// <summary>
    /// It is a perception condition to check if the doge is prepared.
    /// </summary>
    [Condition("Perception/IfBeginDoge")]
    [Help("Checks whether an attack prepared")]
    public class IfBeginDoge : GOCondition
    {
        // Get enemy Data
        private EnemyData enemyData;

        /// <summary>
        /// Get data from enemyData script directly,
        /// </summary>
        /// <returns>True if the doge prepared.</returns>
        public override bool Check()
        {
            //Debug.Log("IfBeginDoge");
            enemyData = gameObject.GetComponent<EnemyData>();
            if (enemyData.state != EnemyState.Idle)
            {
                return false;
            }
            return enemyData.ifCanDoge && enemyData.ifPlayerTooClose;
        }
    }
}