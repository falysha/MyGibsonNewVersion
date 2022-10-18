using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class LowerHP : MonoBehaviour
    {
        // ��ɫѪ��
        private Image redHP;

        // ��ɫѪ��
        private Image whiteHP;

        // ��ɫѪ����ʧ�ٶ�
        public float fadeSpeed = 10;

        void Start()
        {
            // ��ʼ��Ѫ��
            redHP = transform.parent.GetChild(1).GetComponent<Image>();
            whiteHP = GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {
            if (redHP.fillAmount == whiteHP.fillAmount)
            {
                return;
            }
            else if (redHP.fillAmount > whiteHP.fillAmount)
            {
                whiteHP.fillAmount = redHP.fillAmount;
            }
            else
            {
                whiteHP.fillAmount -= fadeSpeed * 0.01f * Time.deltaTime;
            }
        }
    }
}
