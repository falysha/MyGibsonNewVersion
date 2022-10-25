using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class playerUpperMP : MonoBehaviour
    {
        // ������Ϣ
        // Ѫ��ʵ��
        private Image image;

        // ���Ѫ��
        private float maxMP;
        // ��ǰѪ����ʾѪ��

        // Start is called before the first frame update
        void Start()
        {
            // ��ʼ��������Ϣ
            // ��ʼ��Ѫ��ʵ��
            image = GetComponent<Image>();
            // ��ʼ�����Ѫ��
            maxMP = 100f;
            // ��ʼ����ǰѪ����ʾ
            ShowMP();
        }

        // Update is called once per frame
        void Update()
        {
            ShowMP();
        }

        // ����Ѫ������
        void ShowMP()
        {
            var length = SkillController.Fury / maxMP;
            image.fillAmount = length;
        }
    }
}