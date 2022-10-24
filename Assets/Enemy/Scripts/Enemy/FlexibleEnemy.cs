using UnityEngine;

namespace Platformer.Enemy
{
    public class FlexibleEnemy : Enemy
    {
        [Header("advanced property")]
        /// <summary>
        /// The probility of an enemy beat back when attacked
        /// </summary>
        [Range(0, 100)]
        public int beatBackProability;

        /// <summary>
        /// Invincible interval when dodging
        /// </summary>
        public float invincibleTime;

        /// <summary>
        /// The time between two dodges
        /// </summary>
        public float dodgeInterval;
    } 
}
