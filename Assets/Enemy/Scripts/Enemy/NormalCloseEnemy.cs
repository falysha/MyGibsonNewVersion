using System;
using UnityEngine;

namespace Platformer.Enemy
{

    public class NormalCloseEnemy: Enemy
    {
        /// <summary>
        /// Animator attached to the enemy.
        /// </summary>
        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public override void RefreshState()
        {
            animator.SetInteger("state", (int)data.state);
            animator.SetBool("IfFaceRight", data.ifFaceRight);
        }
    } 
}
