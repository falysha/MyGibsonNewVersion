using Pada1.BBCore;
using Platformer.Enemy;

namespace BBUnity.Conditions
{
    [Condition("Perception/ifPlayerTooClose")]
    [Help("Checks whether a target is too close to enemy")]
    public class IsPlayerTooClose : GOCondition
    {
        /// <summary>
        /// Checks whether the player is in enemy's unsafe distance,
        /// </summary>
        /// <returns>True if the player is in enemy's unsafe distance.</returns>
        public override bool Check()
        {
            //Debug.Log("IsPlayerTooClose");
            return gameObject.GetComponent<EnemyData>().ifPlayerTooClose;
        }
    }
}