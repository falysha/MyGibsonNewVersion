namespace Platformer.Buff
{
    public abstract class BuffBase
    {
        /// <summary>
        /// Buff的类型
        /// </summary>
        public BuffKind m_BuffKind;

        /// <summary>
        /// 计时器
        /// </summary>
        public float timer;

        /// <summary>
        /// Buff持续时间,我们约定,Buff时间为0,则为瞬时Buff,只执行OnAdd
        /// </summary>
        public float m_Length;

        /// <summary>
        /// 所归属的实体
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
        /// 当添加到实体时执行逻辑
        /// </summary>
        public virtual void OnAdd()
        {
        }

        /// <summary>
        /// 跟随实体每帧更新
        /// </summary>
        public virtual void OnUpdate()
        {
        }

        /// <summary>
        /// 当从实体移除时
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
