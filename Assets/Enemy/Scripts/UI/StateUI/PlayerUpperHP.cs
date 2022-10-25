using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class PlayerUpperHP : MonoBehaviour
    {
        // 主角信息
        private PlayerData playerData;

        // 血条实体
        private Image image;

        // 最大血量
        private float maxHP;

        // 当前血条显示血量

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
            if (PlayerHealth.realHealth == PlayerHealth.fakeHealth)
            {
                return;
            }
            else
            {
                ShowMP();
            }
        }

        // 更新血条长度
        void ShowMP()
        {
            var length = PlayerHealth.realHealth / maxHP;
            image.fillAmount = length;
        }
    }
}
