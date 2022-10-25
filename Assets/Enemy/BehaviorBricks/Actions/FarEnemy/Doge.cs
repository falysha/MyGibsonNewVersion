using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using System;
using Platformer.Enemy;
using UnityEngine;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to doge when player walk too close.
    /// </summary>
    [Action("Navigation/Doge")]
    [Help("Doge when player walk too close.")]
    public partial class Doge : GOAction
    {
        private float leftPos;
        private float rightPos;

        private EnemyData enemyData;
        /// <summary>Initialization Method of Doge.</summary>
        public override void OnStart()
        {
            //Debug.Log("Doge");
            enemyData = gameObject.GetComponent<EnemyData>();
            leftPos = enemyData.leftPos;
            rightPos = enemyData.rightPos;
            //Get doge destination
            var playerPos = enemyData.player.transform.position.x;
            var rightSafePos = playerPos + enemyData.maxUnsafeDistance;
            var leftSafePos = playerPos - enemyData.maxUnsafeDistance;
            var previousPos = gameObject.transform.position;
            if (leftPos > leftSafePos) 
            {
                gameObject.transform.position = new Vector3(UnityEngine.Random.Range(rightSafePos, Mathf.Min(rightPos,playerPos+enemyData.maxHitDistance)), previousPos.y, previousPos.z);
                enemyData.ifFaceRight = false;
            }
            else if(rightPos < rightSafePos)
            {
                gameObject.transform.position = new Vector3(UnityEngine.Random.Range(Mathf.Max(leftPos, playerPos - enemyData.maxHitDistance), leftSafePos), previousPos.y, previousPos.z);
                enemyData.ifFaceRight = true;
            }
            else
            {
                var randomNum = UnityEngine.Random.Range(0, 100);
                if (randomNum < 50)
                {
                    gameObject.transform.position = new Vector3(UnityEngine.Random.Range(rightSafePos, Mathf.Min(rightPos, playerPos + enemyData.maxHitDistance)), previousPos.y, previousPos.z);
                    enemyData.ifFaceRight = false;
                }
                else
                {
                    gameObject.transform.position = new Vector3(UnityEngine.Random.Range(Mathf.Max(leftPos, playerPos - enemyData.maxHitDistance), leftSafePos), previousPos.y, previousPos.z);
                    enemyData.ifFaceRight = true;
                }
            }

            enemyData.ifCanDoge = false;
        }

        /// <summary>Method of Update of Doge </summary>
        /// <remarks>Enemy will doge when player walk too close.</remarks>
        public override TaskStatus OnUpdate()
        {
            if (!enemyData.ifCanDoge)
                return TaskStatus.COMPLETED;
            return TaskStatus.RUNNING;
        }
    }
}
