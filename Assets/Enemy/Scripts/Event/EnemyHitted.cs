using Platformer.Core;
using Platformer.Enemy;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the health component on an enemy has a hitpoint value of  0.
    /// </summary>
    /// <typeparam name="EnemyDeath"></typeparam>
    public class EnemyHitted : Simulation.Event<EnemyHitted>
    {
        public PlayerDamageJudge playerDamage;
        public EnemyData enemyData;

        public override void Execute()
        {
            if(enemyData.state==EnemyState.Idle|| enemyData.state == EnemyState.Walk)
            {
                enemyData.isHitted = true;
            }
            var injury = playerDamage.damage;
            enemyData.HP -= injury * (1 - enemyData.injuryFreeRatio);
        }
    }
}