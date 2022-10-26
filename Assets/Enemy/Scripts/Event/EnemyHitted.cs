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
            SkillController.Fury = SkillController.Fury+3;
            if (enemyData.state == EnemyState.Idle || enemyData.state == EnemyState.Walk)
            {
                enemyData.isHitted = true;
            }
            var injury = (int)(playerDamage * ratio);
            enemyData.HP -= injury * (1 - enemyData.injuryFreeRatio);
        }
    }
}