using UnityEngine;
using Platformer.Enemy;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class UpperHP : MonoBehaviour
    {
        // 怪物信息
        private EnemyData enemyData;

        // 当前血条数值
        private float upperHP;

        // 最大血量
        private float maxHP;

        // 血条实体
        private Image image;

        // Start is called before the first frame update
        void Start()
        {
            // 初始化怪物信息
            enemyData = transform.parent.parent.parent.GetComponent<EnemyData>();
            // 当前血条显示血量
            upperHP = enemyData.HP;
            // 获取怪物最大血量
            maxHP = enemyData.maxHP;
            // 获取血条实体
            image = GetComponent<Image>();

            ShowHP();
        }

        // Update is called once per frame
        void Update()
        {
            if (upperHP == enemyData.HP)
            {
                return;
            }
            upperHP = enemyData.HP;
            ShowHP();
        }

        // 更新血条长度
        void ShowHP()
        {
            var length = upperHP / maxHP;
            image.fillAmount = length;
        }
    }
}
