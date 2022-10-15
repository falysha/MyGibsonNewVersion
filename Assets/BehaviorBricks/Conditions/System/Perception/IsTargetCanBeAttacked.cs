using Pada1.BBCore;
using Platformer.Enemy;
using UnityEngine;

namespace BBUnity.Conditions
{
    /// <summary>
    /// It is a perception condition to check if the objective is close depending on a given distance.
    /// </summary>
    [Condition("Perception/IsTargetCanBeAttacked")]
    [Help("Checks whether a target is close enough to be attacked depending on a given distance")]
    public class IsTargetCanBeAttacked : GOCondition
    {
        // The maximun distance to consider that the target is close
        private EnemyData enemyData;

        /// <summary>
        /// Checks whether a target is close depending on a given distance,
        /// calculates the magnitude between the gameobject and the target and then compares with the given distance.
        /// </summary>
        /// <returns>True if the magnitude between the gameobject and de target is lower that the given distance.</returns>
        public override bool Check()
		{
            //Debug.Log("CheckIsTargetCanBeAttacked");
            enemyData = gameObject.GetComponent<EnemyData>();
            return enemyData.ifPlayerCanBeAttacked;
		}
    }
}