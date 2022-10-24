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

        public override void RefreshState()
        {
            beginRecover = data.HP < minRecoverHP ? true : false;
            data.SkillAllowed = beginRecover; 
        }

        public override void ExecuteSkill()
        {
            Debug.Log("回血");
            data.HP += recoverValue;
        }
    } 
}
