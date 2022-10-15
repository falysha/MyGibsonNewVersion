using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using System;
using UnityEditor.PackageManager.UI;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;
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
        [InParam("Left Idle Area")]
        public Vector2 leftPos;
        [InParam("Right Idle Area")]
        public Vector2 rightPos;

        [InParam("Idle Time")]
        public float idleTime;

        private EnemyData enemyData;
        private float moveSpeed;
        private UnityEngine.Transform transform;

        /// <summary>Initialization Method of WanderBetweenTwoPoints.</summary>
        /// <remarks>Check if there is a NavMeshAgent to assign it one by default and assign it
        public override void OnStart()
        {
            //Debug.Log("wander");
            transform = gameObject.GetComponent<UnityEngine.Transform>();
            enemyData = gameObject.GetComponent<EnemyData>();
            moveSpeed = enemyData.moveSpeed;
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
                if (gameObject.transform.position.x >= rightPos.x)
                    enemyData.ifFaceRight = false;
                if (gameObject.transform.position.x <= leftPos.x)
                    enemyData.ifFaceRight = true;
                var direction = enemyData.ifFaceRight ? rightPos : leftPos;
                transform.position = Vector2.MoveTowards(transform.position, direction, moveSpeed * Time.deltaTime);
            }
            return TaskStatus.RUNNING;
        }
    }
}
