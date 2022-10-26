using Platformer.Gameplay;
using System.Collections;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Enemy
{
    public class FlexibleEnemy : Enemy
    {
        [Header("advanced property")]
        /// <summary>
        /// The damage this skill can make to player.
        /// </summary>
        public int skillDamage;

        /// <summary>
        /// The interval between skill begin and damage begin.
        /// </summary>
        public float damageDelay;

        /// <summary>
        /// The length of damage animation.
        /// </summary>
        public float damageAniLength;

        private Vector3 previousPos;

        public override void ExecuteSkill()
        {
            var ifPlayerInAttackDistance = ((data.player.transform.position - transform.position).magnitude <= data.maxHitDistance);
            if (ifPlayerInAttackDistance == true)
            {
                var ev = Schedule<PlayerHitted>();
                ev.enemyTransform = transform;
                ev.damage = skillDamage;
            }
        }

        public void RushToPlayer()
        {
            previousPos = transform.position;
            transform.position = new Vector3(data.player.transform.position.x - 1 / 2, transform.position.y, transform.position.z);
            data.state = EnemyState.Skill_2;
        }

        public void RuturnPreviousPos()
        {
            transform.position = previousPos;
            data.state = EnemyState.Skill_3;
        }
    } 
}
