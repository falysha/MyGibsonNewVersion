using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class PlayerMP : MonoBehaviour
    {
        // ������Ϣ
        private PlayerData playerData;

        // ����ʵ��
        private Image image;

        // ���Ѫ��
        private float maxMP;

        // ��ǰѪ����ʾ����
        private float MP;

        // Start is called before the first frame update
        void Start()
        {
            // ��ʼ��������Ϣ
            playerData = GameObject.Find("Player").GetComponent<PlayerData>();
            // ��ʼ������ʵ��
            image = GetComponent<Image>();
            // ��ʼ���������
            maxMP = 100f;
            // ��ʼ����ǰ������ʾ
            MP = playerData.MP;

            ShowMP();
        }

        // Update is called once per frame
        void Update()
        {
            if (MP == playerData.MP)
            {
                return;
            }
            else
            {
                MP = playerData.MP;
                ShowMP();
            }
        }

        // ������������
        void ShowMP()
        {
            var length = MP / maxMP;
            image.fillAmount = length;
        }
    }
}
