using Pada1.BBCore;
using Platformer.Enemy;

namespace BBUnity.Conditions
{
    /// <summary>
    /// It is a perception condition to check if the attack is prepared.
    /// </summary>
    [Condition("Perception/IsAttackPrepared")]
    [Help("Checks whether an attack prepared")]
    public class IsAttackPrepared : GOCondition
    {
        // Get enemy Data
        private EnemyData enemyData;

        /// <summary>
        /// Get data from enemyData script directly,
        /// </summary>
        /// <returns>True if the attack prepared.</returns>
        public override bool Check()
        {
            //Debug.Log("IsAttackPrepared");
            enemyData = gameObject.GetComponent<EnemyData>();
            if (enemyData.state == EnemyState.Attack)
            {
                return true;
            }
            return enemyData.ifCanAttack;
        }
    }
}