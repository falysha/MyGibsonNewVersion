using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class SkillLower1 : MonoBehaviour
    {
        // ������Ϣ
        private PlayerData playerData;

        // ���ܵ���ʱʵ��
        private Image image;

        // ���CD
        private float maxCD;

        // ��ǰʣ��CD
        private float CD;

        // Start is called before the first frame update
        void Start()
        {
            // ��ʼ��������Ϣ
            playerData = GameObject.Find("Player").GetComponent<PlayerData>();
            // ��ʼ�����ܵ���ʱʵ��
            image = GetComponent<Image>();
            // ��ʼ�����CD
            maxCD = 3f;
            // ��ʼ����ǰʣ��CD
            CD = playerData.skill1CD;

            ShowCD();
        }

        // Update is called once per frame
        void Update()
        {
            if (CD == playerData.skill1CD)
            {
                return;
            }
            else
            {
                CD = playerData.skill1CD;
                ShowCD();
            }
        }

        // ����CD
        void ShowCD()
        {
            var length = CD / maxCD;
            image.fillAmount = length;
        }
    }
}
