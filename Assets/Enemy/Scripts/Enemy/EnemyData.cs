using System;
using UnityEngine;

namespace Platformer.Enemy
{
    public class EnemyData:MonoBehaviour
    {
        [Header("base property")]
        /// <summary>
        /// Type of enemy
        /// </summary>
        Type enemyType;

        /// <summary>
        /// Health of enemy
        /// </summary>
        public int HP;

        /// <summary>
        /// Max health of enemy
        /// </summary>
        public int maxHP;

        /// <summary>
        /// Toughness values affect the debuff effect
        /// </summary>
        // public int toughness;

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
        /// Attack animation time
        /// </summary>
        public float attackAniTime;

        /// <summary>
        /// Interval between attacks
        /// </summary>
        public float attackCD;

        /// <summary>
        /// The length of hitted animation
        /// </summary>
        public float hittedTime;

        /// <summary>
        /// The length of died animation
        /// </summary>
        public float diedTime;

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
        /// If enemy is hitted by player, the value should be true.
        /// </summary>
        /// [NonSerialized]
        public bool isHitted = false;

        /// <summary>
        /// If enemy can attack player, the value should be true.
        /// </summary>
        /// [NonSerialized]
        public bool ifCanAttack = true;

        /// <summary>
        /// The debuff stack in the enemy
        /// </summary>

        /// <summary>
        /// When player enter this field, enemy start attack.
        /// </summary>
        public GameObject attackField;

        public GameObject player;

        public EnemyState state = EnemyState.Idle;

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

    public enum EnemyState
    {
        Idle,
        Walk,
        Hitted,
        Attack,
        Die
    }
}
