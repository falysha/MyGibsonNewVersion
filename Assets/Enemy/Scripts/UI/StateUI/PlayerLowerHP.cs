using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class PlayerLowerHP : MonoBehaviour
    {
        // 主角信息
        private PlayerData playerData;

        // 血条实体
        private Image image;

        // 最大血量
        private float maxHP;

        // 当前血条显示血量
        private float HP;

        // Start is called before the first frame update
        void Start()
        {
            // 初始化主角信息
            playerData = GameObject.Find("Player").GetComponent<PlayerData>();
            // 初始化血条实体
            image = GetComponent<Image>();
            // 初始化最大血量
            maxHP = 100f;
            // 初始化当前血量显示
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

        // 更新血条长度
        void ShowMP()
        {
            var length = HP / maxHP;
            image.fillAmount = length;
        }
    }
}
