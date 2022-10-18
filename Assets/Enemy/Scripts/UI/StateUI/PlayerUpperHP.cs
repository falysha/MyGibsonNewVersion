using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class PlayerUpperHP : MonoBehaviour
    {
        // ������Ϣ
        private PlayerData playerData;

        // Ѫ��ʵ��
        private Image image;

        // ���Ѫ��
        private float maxHP;

        // ��ǰѪ����ʾѪ��
        private float HP;

        // Start is called before the first frame update
        void Start()
        {
            // ��ʼ��������Ϣ
            playerData = GameObject.Find("Player").GetComponent<PlayerData>();
            // ��ʼ��Ѫ��ʵ��
            image = GetComponent<Image>();
            // ��ʼ�����Ѫ��
            maxHP = 100f;
            // ��ʼ����ǰѪ����ʾ
            HP = playerData.HP;

            ShowMP();
        }

        // Update is called once per frame
        void Update()
        {
            if (HP == playerData.HP)
            {
                return;
            }
            else
            {
                HP = playerData.HP;
                ShowMP();
            }
        }

        // ����Ѫ������
        void ShowMP()
        {
            var length = HP / maxHP;
            image.fillAmount = length;
        }
    }
}
