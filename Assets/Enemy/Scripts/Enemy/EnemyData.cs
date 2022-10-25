using System;
using UnityEngine;

namespace Platformer.Enemy
{
    public class EnemyData:MonoBehaviour
    {
        /// <summary>
        /// Type of enemy
        /// </summary>
        Type enemyType;

        /// <summary>
        /// Health of enemy
        /// </summary>
        [Header("base property")]
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
        [Header("Set property")]
        public float moveSpeed;

        /// <summary>
        /// left idle position
        /// </summary>
        [NonSerialized]
        public float leftPos;

        /// <summary>
        /// Right idle position
        /// </summary>
        [NonSerialized]
        public float rightPos;

        /// <summary>
        /// Attack animation time
        /// </summary>
        public float attackAniTime;

        /// <summary>
        /// Interval between attacks
        /// </summary>
        [Tooltip("Interval between two attacks")]
        public float attackCD;

        /// <summary>
        /// Interval between doges
        /// </summary>
        [Tooltip("Interval between two attacks")]
        public float dogeCD;

        /// <summary>
        /// Interval between skills
        /// </summary>
        [Tooltip("Interval between two skills")]
        public float skillCD;

        /// <summary>
        /// The length of hitted animation
        /// </summary>
        [Tooltip("The length of hitted animation")]
        public float hittedTime;

        /// <summary>
        /// The length of died animation
        /// </summary>
        [Tooltip("The length of died animation")]
        public float diedTime;

        /// <summary>
        /// The length of skill animation
        /// </summary>
        [Tooltip("The length of skill animation")]
        public float skillTime;

        /// <summary>
        /// The max distance enemy can hit player.
        /// </summary>
        [Tooltip("The max distance enemy can hit player")]
        public float maxHitDistance;

        /// <summary>
        /// The max unsafe distance that enemy feel threaten by player.
        /// </summary>
        [Tooltip("The max distance enemy begin dodge")]
        public float maxUnsafeDistance;

        /// <summary>
        /// If the enemy can move
        /// </summary>
        /// public bool isStatic;

        /// <summary>
        /// If enemy's direction is right, this value is true
        /// </summary>
        [NonSerialized]
        public bool ifFaceRight = true;

        /// <summary>
        /// If enemy is hitted by player, the value should be true.
        /// </summary>
        /// [NonSerialized]
        [Header("State property")]
        public bool isHitted = false;

        /// <summary>
        /// If enemy can attack player, the value should be true.
        /// </summary>
        /// [NonSerialized]
        public bool ifCanAttack = true;

        [NonSerialized]
        public bool isAttacking = false;

        [NonSerialized]
        public bool isReleasingSkill = false;

        /// <summary>
        /// If enemy can doge, the value should be true.
        /// </summary>
        /// [NonSerialized]
        public bool ifCanDoge = true;

        /// <summary>
        /// If enemy can release skill, the value should be true.
        /// </summary>
        /// [NonSerialized]
        public bool SkillAllowed = false;

        /// <summary>
        /// If enemy's skill is prepared, the value should be true.
        /// </summary>
        /// [NonSerialized]
        public bool ifSkillPrepared = true;

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
            get { return (transform.position - player.transform.position).magnitude <= maxHitDistance; }
        }

        /// <summary>
        /// When player is too close to far enemy, enemy will doge.
        /// </summary>
        public bool ifPlayerTooClose
        {
            get { return (transform.position - player.transform.position).magnitude <= maxUnsafeDistance; }
        }

        private void Start()
        {
            player = GameObject.Find("Player");
        }
    }

    public enum EnemyState
    {
        Idle,
        Walk,
        Hitted,
        Attack,
        Die,
        Skill_1,
        Skill_2,
        Skill_3
    }
}
