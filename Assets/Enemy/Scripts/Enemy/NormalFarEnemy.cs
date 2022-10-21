using System;
using UnityEngine;

namespace Platformer.Enemy
{
    public class NormalFarEnemy: Enemy
    {
        private float dogeCD;

        private void Start()
        {
            dogeCD = data.attackCD;
        }

        public override void RefreshState()
        {
            CheckDoge();
        }

        // Check if enemy can doge
        private void CheckDoge()
        {
            if (data.ifCanDoge == false)
            {
                dogeCD -= Time.deltaTime;
                if (dogeCD <= 0)
                {
                    dogeCD = data.dogeCD;
                    data.ifCanDoge = true;
                }
            }
        }
    }
}
