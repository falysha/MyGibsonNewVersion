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
            // 初始化主角信息
            // 初始化血条实体
            image = GetComponent<Image>();
            // 初始化最大血量
            maxHP = 100f;
            // 初始化当前血量显示
            ShowMP();
        }

        // Update is called once per frame
        void Update()
        {
            ShowMP();
        }

        // 更新血条长度
        void ShowMP()
        {
            var length = PlayerHealth.fakeHealth / maxHP;
            image.fillAmount = length;
        }
    }
}
