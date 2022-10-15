using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;
using System;
using Platformer.Enemy;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to move towards the player.
    /// </summary>
    [Action("Navigation/MoveToPlayer")]
    [Help("Moves the game object towards a given target")]
    public class MoveToPlayer : GOAction
    {
        private EnemyData enemyData;
        private Transform transform;
        private Transform targetTransform;
        private float moveSpeed;

        /// <summary>Initialization Method of MoveToPlayer.</summary>
        public override void OnStart()
        {
            //Debug.Log("MoveToPlayer");
            enemyData = gameObject.GetComponent<EnemyData>();
            transform = gameObject.GetComponent<Transform>();
            moveSpeed = enemyData.moveSpeed;
            targetTransform = enemyData.player.transform;
        }

        /// <summary>Method of Update of MoveToPlayer.</summary>
        /// <remarks>The task ended when enemy can hit player or player leaves the attack field</remarks>
        public override TaskStatus OnUpdate()
        {
            if (!enemyData.isPlayerInAttackField || enemyData.ifPlayerCanBeAttacked) 
                return TaskStatus.COMPLETED;
            enemyData.ifFaceRight = targetTransform.position.x - transform.position.x > 0 ? true : false;
            transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, moveSpeed * Time.deltaTime);
            return TaskStatus.RUNNING;
        }
    }
}
