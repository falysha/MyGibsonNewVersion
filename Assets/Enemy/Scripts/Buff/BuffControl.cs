using Platformer.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Buff
{
    /// <summary>
    /// 为了添加Buff设计的自定义EntityLogic
    /// </summary>
    public class BuffControl : MonoBehaviour
    {
        public List<BuffBase> m_Buffs = new List<BuffBase>();

        public EnemyData EnemyData;

        [Header("CodeChaosBuff")]
        public float reduceRatio;

        private void Start()
        {
            EnemyData = GetComponent<EnemyData>();
        }

        public void AddBuff(BuffBase buffNeed2Add)
        {
            m_Buffs.Add(buffNeed2Add);
            buffNeed2Add.OnAdd();
        }

        private void Update()
        {
            ReFreshBuff();
        }

        public void ReFreshBuff()
        {
            for (int i = m_Buffs.Count - 1; i >= 0; i--)
            {
                m_Buffs[i].OnUpdate();
            }
        }

        public void RemoveBuff(BuffBase buffNeed2Remove)
        {
            m_Buffs.Remove(buffNeed2Remove);
            buffNeed2Remove.OnRemove();
        }
    }
}
