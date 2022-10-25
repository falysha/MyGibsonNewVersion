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

        // Start is called before the first frame update
        void Start()
        {
            // ��ʼ��������Ϣ
            // ��ʼ��Ѫ��ʵ��
            image = GetComponent<Image>();
            // ��ʼ�����Ѫ��
            maxHP = 100f;
            // ��ʼ����ǰѪ����ʾ
            ShowMP();
        }

        // Update is called once per frame
        void Update()
        {
            if (PlayerHealth.realHealth == PlayerHealth.fakeHealth)
            {
                return;
            }
            else
            {
                ShowMP();
            }
        }

        // ����Ѫ������
        void ShowMP()
        {
            var length = PlayerHealth.realHealth / maxHP;
            image.fillAmount = length;
        }
    }
}
