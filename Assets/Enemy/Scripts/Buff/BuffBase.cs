namespace Platformer.Buff
{
    public abstract class BuffBase
    {
        /// <summary>
        /// Buff������
        /// </summary>
        public BuffKind m_BuffKind;

        /// <summary>
        /// ��ʱ��
        /// </summary>
        public float timer;

        /// <summary>
        /// Buff����ʱ��,����Լ��,Buffʱ��Ϊ0,��Ϊ˲ʱBuff,ִֻ��OnAdd
        /// </summary>
        public float m_Length;

        /// <summary>
        /// ��������ʵ��
        /// </summary>
        public BuffControl m_buffControl;

        public BuffBase(BuffControl buffControl, BuffKind buffKind, float length)
        {
            m_buffControl = buffControl;
            m_Length = length;
            m_BuffKind = buffKind;
            timer = 0;
        }

        /// <summary>
        /// ����ӵ�ʵ��ʱִ���߼�
        /// </summary>
        public virtual void OnAdd()
        {
        }

        /// <summary>
        /// ����ʵ��ÿ֡����
        /// </summary>
        public virtual void OnUpdate()
        {
        }

        /// <summary>
        /// ����ʵ���Ƴ�ʱ
        /// </summary>
        public virtual void OnRemove()
        {
        }
    }

    public enum BuffKind
    {
        CodeChaos = 1,
    }
}
