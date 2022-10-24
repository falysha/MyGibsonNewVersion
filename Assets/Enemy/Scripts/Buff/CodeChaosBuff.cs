using System;
using UnityEngine;

namespace Platformer.Buff
{
    /// <summary>
    /// 代码混乱Buff
    /// </summary>
    public class CodeChaosBuff : BuffBase
    {
        // 存储施加buff前的信息
        private float moveSpeed;
        private float attackCD;
        private float dogeCD;
        private int damage;

        public CodeChaosBuff(BuffControl buffControl, BuffKind buffKind, float length) : base(buffControl, buffKind,
            length)
        {
        }

        public override void OnAdd()
        {
            moveSpeed = m_buffControl.EnemyData.moveSpeed;
            m_buffControl.EnemyData.moveSpeed = m_buffControl.moveSpeed;

            attackCD = m_buffControl.EnemyData.attackCD;
            m_buffControl.EnemyData.attackCD = m_buffControl.attackCD;

            dogeCD = m_buffControl.EnemyData.dogeCD;
            m_buffControl.EnemyData.dogeCD = m_buffControl.dogeCD;

            damage = m_buffControl.EnemyData.damage;
            m_buffControl.EnemyData.damage = m_buffControl.damage;
        }


        public override void OnUpdate()
        {
            if (timer >= m_Length)
            {
                m_buffControl.RemoveBuff(this);
            }

            timer += Time.fixedDeltaTime;
        }

        public override void OnRemove()
        {
            m_buffControl.EnemyData.moveSpeed = moveSpeed;
            m_buffControl.EnemyData.attackCD = attackCD;
            m_buffControl.EnemyData.dogeCD = dogeCD;
            
            m_buffControl.EnemyData.damage = damage;
        }
    }
}
