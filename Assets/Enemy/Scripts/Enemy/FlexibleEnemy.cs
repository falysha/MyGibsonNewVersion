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
        private GameObject Player = GameObject.Find("Player");
        private Vector3 previousPos;

        public override void ExecuteSkill()
        {
            var ifPlayerInAttackDistance = ((data.player.transform.position - transform.position).magnitude <= data.maxHitDistance);
            if (ifPlayerInAttackDistance == true)
            {
                var ev = Schedule<PlayerHitted>();
                ev.player = Player;
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
