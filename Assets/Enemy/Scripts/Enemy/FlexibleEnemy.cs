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
            // Debug.Log("释放技能");
            previousPos = transform.position;
            transform.position = new Vector3(data.player.transform.position.x-1/2, transform.position.y, transform.position.z);
            data.state = EnemyState.Skill_2;
            StartCoroutine("MakeHarm");
            StartCoroutine("GoRandomPosition");
        }

        IEnumerator MakeHarm()
        {
            yield return new WaitForSecondsRealtime(damageDelay);
            var ifPlayerInAttackDistance = ((data.player.transform.position - transform.position).magnitude <= data.maxHitDistance);
            if (ifPlayerInAttackDistance == true)
            {
                var ev = Schedule<PlayerHitted>();
                ev.enemyTransform = transform;
                ev.damage = skillDamage;
            }
            // Debug.Log("MakeHarm");
            // fire damage event
        }

        IEnumerator GoRandomPosition()
        {
            yield return new WaitForSecondsRealtime(damageAniLength);
            // Debug.Log("GoRandomPosition");
            transform.position = previousPos;
            data.state = EnemyState.Skill_3;
        }
    } 
}
