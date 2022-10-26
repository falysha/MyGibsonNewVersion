using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;
using System;
using Platformer.Enemy;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to move the GameObject to a random position in an area using a NavMeshAgent.
    /// </summary>
    [Action("Navigation/WanderBetweenTwoPoints")]
    [Help("Idel between two points for some second")]
    public partial class WanderBetweenTwoPoints : GOAction
    {
        [InParam("Idle Time")]
        public float idleTime;

        private EnemyData enemyData;
        private float moveSpeed;
        private float leftPos;
        private float rightPos;
        private UnityEngine.Transform transform;

        /// <summary>Initialization Method of WanderBetweenTwoPoints.</summary>
        /// <remarks>Check if there is a NavMeshAgent to assign it one by default and assign it
        public override void OnStart()
        {
            //Debug.Log("wander");
            transform = gameObject.GetComponent<UnityEngine.Transform>();
            enemyData = gameObject.GetComponent<EnemyData>();
            moveSpeed = enemyData.moveSpeed;
            leftPos = enemyData.leftPos;
            rightPos = enemyData.rightPos;
            enemyData.state = EnemyState.Walk;
        }

        /// <summary>Method of Update of WanderBetweenTwoPoints </summary>
        /// <remarks>Check and Change The Direction until time ended.</remarks>
        public override TaskStatus OnUpdate()
        {
            idleTime -= Time.deltaTime;
            if (enemyData.isPlayerInAttackField || idleTime < 0)  
                return TaskStatus.COMPLETED;
            else
            {
                // Change direction of enemy
                if (gameObject.transform.position.x >= rightPos)
                    enemyData.ifFaceRight = false;
                if (gameObject.transform.position.x <= leftPos)
                    enemyData.ifFaceRight = true;
                // Calculate The end position of enemy
                var endPoint = enemyData.ifFaceRight ? rightPos : leftPos;
                var direction = new Vector2(endPoint, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, direction, moveSpeed * Time.deltaTime);
            }
            return TaskStatus.RUNNING;
        }
    }
}
