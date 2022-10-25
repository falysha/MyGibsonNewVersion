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

        public override bool IfPlayerHitted()
        {
            Ray ray = new Ray(transform.position, data.ifFaceRight ? transform.right : -transform.right);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, data.maxHitDistance))
            {
                if (hit.collider.tag == "Player")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
