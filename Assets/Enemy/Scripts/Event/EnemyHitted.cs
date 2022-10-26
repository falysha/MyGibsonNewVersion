using Platformer.Core;
using Platformer.Enemy;
using System.Diagnostics;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the health component on an enemy has a hitpoint value of  0.
    /// </summary>
    /// <typeparam name="EnemyDeath"></typeparam>
    public class EnemyHitted : Simulation.Event<EnemyHitted>
    {
        public int playerDamage;
        public EnemyData enemyData;
        public static float ratio = 1;
        public override void Execute()
        {
            // Debug.Log("enemy hitted");
            if(PlayerHealth.realHealth<100)
            {
                PlayerHealth.realHealth += 2;
            }
            else
            {
                SkillController.Fury = SkillController.Fury + 2;
            }
            if (enemyData.state == EnemyState.Idle || enemyData.state == EnemyState.Walk)
            {
                enemyData.isHitted = true;
                var ifplayerinLeft = enemyData.player.transform.position.x - enemyData.enemy.transform.position.x > 0 ? -100 : 100;
                enemyData.enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(ifplayerinLeft, 0));
            }
            var injury = (int)(playerDamage * ratio);
            enemyData.HP -= injury * (1 - enemyData.injuryFreeRatio);
        }
    }
}