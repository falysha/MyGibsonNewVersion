using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class LowerHP : MonoBehaviour
    {
        // 红色血条
        private Image redHP;

        // 白色血条
        private Image whiteHP;

        // 白色血条消失速度
        public float fadeSpeed = 10;

        void Start()
        {
            // 初始化血条
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
