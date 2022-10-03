using UnityEngine;

namespace Platformer.Enemy
{
    public delegate void Mydelegate();
    public class BloodRecoverEnemy: Enemy
    {
        [Header("advanced property")]
        /// <summary>
        /// If the enemy is recovering HP
        /// </summary>
        public bool beginRecover;

        /// <summary>
        /// The amount of health recovered at one time
        /// </summary>
        public int recoverValue;

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
