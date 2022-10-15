using BBUnity.Actions;
using Pada1.BBCore;
using Platformer.Enemy;
using UnityEngine;

namespace BBUnity.Conditions
{
    [Condition("Perception/IsTargetInAttackField")]
    [Help("Checks whether a target is in the attack field")]
    public class IsTargetInAttackField : GOCondition
    {
        /// <summary>
        /// Checks whether the player is in enemy's attack field,
        /// </summary>
        /// <returns>True if the player in enemy's attack field.</returns>
        public override bool Check()
        {
            //Debug.Log("IsTargetInAttackField");
            return gameObject.GetComponent<EnemyData>().isPlayerInAttackField;
        }
    }
}