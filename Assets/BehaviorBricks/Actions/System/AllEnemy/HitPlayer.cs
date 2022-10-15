using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using System;
using UnityEngine;
using Platformer.Enemy;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to move the GameObject to a random position in an area using a NavMeshAgent.
    /// </summary>
    [Action("Navigation/HitPlayer")]
    [Help("Hit Player and make some damage to player.")]
    public partial class HitPlayer : GOAction
    {
        [InParam("hitBefore")]
        [Help("The time enemy needed to prepare the hit.")]
        public float hitBefore;

        private float attackTime;

        /// <summary>Initialization Method of HitPlayer.</summary>
        public override void OnStart()
        {
            //Debug.Log("HitPlayer");
            attackTime = gameObject.GetComponent<EnemyData>().attackTime;
        }

        /// <summary>Method of Update of HitPlayer </summary>
        /// <remarks>Enemy will hit player at once.</remarks>
        public override TaskStatus OnUpdate()
        {
            attackTime -= Time.deltaTime;
            // a Timer that record when to fire attack event
            if (hitBefore != -1)
                hitBefore -= Time.deltaTime;
            if(hitBefore<0)
            {
                // Fire attack event
                Debug.Log("hit player");

                hitBefore = -1;
            }
            if(attackTime<0)
                return TaskStatus.COMPLETED;
            return TaskStatus.RUNNING;
        }
    }
}
