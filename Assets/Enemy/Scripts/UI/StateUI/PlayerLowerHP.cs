using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class PlayerLowerHP : MonoBehaviour
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
            HP = playerData.currentHP;

            ShowMP();
        }

        // Update is called once per frame
        void Update()
        {
            if (HP == playerData.currentHP)
            {
                return;
            }
            else
            {
                HP = playerData.currentHP;
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
