using UnityEngine;
using System.Collections;

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
        /// The min HP when enemy begin to recover HP.
        /// </summary>
        public int minRecoverHP;

        /// <summary>
        /// The amount of health recovered at one time
        /// </summary>
        public int recoverValue;

        /// <summary>
        /// The interval between twice recover.
        /// </summary>
        public int recoverTime;

        /// <summary>
        /// Invincible interval when dodging
        /// </summary>
        public float invincibleTime;

        /// <summary>
        /// The time between two dodges
        /// </summary>
        public float dodgeInterval;

        private void Awake()
        {
            StartCoroutine("Recover");
        }

        IEnumerator Recover()
        {
            while (true)
            {
                if (data.HP < minRecoverHP)
                    data.HP += recoverValue;
                yield return new WaitForSeconds(recoverTime);
            }
        }
    } 
}
