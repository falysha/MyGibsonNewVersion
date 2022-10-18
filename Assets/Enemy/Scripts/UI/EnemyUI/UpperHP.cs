using UnityEngine;
using Platformer.Enemy;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class UpperHP : MonoBehaviour
    {
        // ������Ϣ
        private EnemyData enemyData;

        // ��ǰѪ����ֵ
        private float upperHP;

        // ���Ѫ��
        private float maxHP;

        // Ѫ��ʵ��
        private Image image;

        // Start is called before the first frame update
        void Start()
        {
            // ��ʼ��������Ϣ
            enemyData = transform.parent.parent.parent.GetComponent<EnemyData>();
            // ��ǰѪ����ʾѪ��
            upperHP = enemyData.HP;
            // ��ȡ�������Ѫ��
            maxHP = enemyData.maxHP;
            // ��ȡѪ��ʵ��
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

        // ����Ѫ������
        void ShowHP()
        {
            var length = upperHP / maxHP;
            image.fillAmount = length;
        }
    }
}
