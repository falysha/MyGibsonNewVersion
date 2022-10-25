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
            //Debug.Log("Begin hit test");
            Ray2D ray = new Ray2D(transform.position, data.ifFaceRight ? Vector2.right : -Vector2.right);
            RaycastHit2D info = Physics2D.Raycast(ray.origin, ray.direction, data.maxHitDistance, 1 << 8);
            if (info.collider != null && info.collider.tag == "Player") 
            {
                return true;
            }
            return false;
        }
    }
}
