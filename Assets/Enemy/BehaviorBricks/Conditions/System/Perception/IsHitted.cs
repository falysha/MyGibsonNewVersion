using Pada1.BBCore;
using Platformer.Enemy;

namespace BBUnity.Conditions
{
    [Condition("Perception/IsHitted")]
    [Help("Checks if the enemy is hitted by player")]
    public class IsHitted : GOCondition
    {
        /// <summary>
        /// Checks whether the player is in enemy's attack field,
        /// </summary>
        /// <returns>True if the player in enemy's attack field.</returns>
        public override bool Check()
        {
            //Debug.Log("IsTargetInAttackField");
            return gameObject.GetComponent<EnemyData>().isHitted;
        }
    }
}