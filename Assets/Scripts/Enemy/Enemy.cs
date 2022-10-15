using UnityEngine;

namespace Platformer.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    /// <summary>
    /// the base class of enemy
    /// </summary>
    public abstract class Enemy : MonoBehaviour
    {
        /// <summary>
        /// the base data of enemy
        /// </summary>
        EnemyData data;

        private void Awake()
        {
            data = GetComponent<EnemyData>();
        }

        private void FixedUpdate()
        {
            RefreshState();
        }

        private void RefreshState() { }
    }
}
