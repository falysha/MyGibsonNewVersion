using UnityEngine;
using System.Collections;
using Platformer.Gameplay;

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

        public override bool IfPlayerHitted()
        {
            //Debug.Log("Begin hit test");
            Ray2D ray = new Ray2D(transform.position, data.ifFaceRight ? Vector2.right : -Vector2.right);
            RaycastHit2D info = Physics2D.Raycast(ray.origin, ray.direction, data.maxHitDistance, 1 << 8);
            if (info.collider != null && info.collider.tag == "Player")
            {
                return true;
            }
            return false;
        }
    } 
}
