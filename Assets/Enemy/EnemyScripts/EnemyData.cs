using BBUnity.Actions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Enemy
{
    public class EnemyData:MonoBehaviour
    {
        [Header("base property")]
        /// <summary>
        /// ID of enemy
        /// </summary>
        public int ID;

        /// <summary>
        /// Health of enemy
        /// </summary>
        public int HP;

        /// <summary>
        /// Toughness values affect the debuff effect
        /// </summary>
        public int toughness;

        /// <summary>
        /// Damage affects the damage done by enemies to players
        /// </summary>
        public int damage;

        /// <summary>
        /// The percentage of damage reduction when the enemy is wounded
        /// </summary>
        [Range(0, 100)]
        public int injuryFreeRatio;

        /// <summary>
        /// The speed of enemy move
        /// </summary>
        public float moveSpeed;

        /// <summary>
        /// Interval between attacks
        /// </summary>
        public float attackTime;

        /// <summary>
        /// The max distance enemy can hit player.
        /// </summary>
        public float maxHitDistance;

        /// <summary>
        /// If the enemy can move
        /// </summary>
        public bool isStatic;

        /// <summary>
        /// If enemy's direction is right, this value is true
        /// </summary>
        [NonSerialized]
        public bool ifFaceRight = true;

        /// <summary>
        /// The debuff stack in the enemy
        /// </summary>

        /// <summary>
        /// When player enter this field, enemy start attack.
        /// </summary>
        public GameObject attackField;

        public GameObject player;

        /// <summary>
        /// When player can be attacked, the value will be true.
        /// </summary>
        public bool isPlayerInAttackField
        {
            get { return attackField.GetComponent<AttackField>().isPlayerInAttackField; }
        }

        /// <summary>
        /// When player can be attacked, the value will be true.
        /// </summary>
        public bool ifPlayerCanBeAttacked
        {
            get { return (transform.position - player.transform.position).sqrMagnitude <= maxHitDistance; }
        }
    }
}
