using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class PlayerLowerHP : MonoBehaviour
    {
        private Image image;
        private float maxHP;
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
            ShowMP();
        }

        // ����Ѫ������
        void ShowMP()
        {
            var length = PlayerHealth.fakeHealth / maxHP;
            image.fillAmount = length;
        }
    }
}
