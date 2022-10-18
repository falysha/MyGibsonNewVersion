using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class PlayerMP : MonoBehaviour
    {
        // 主角信息
        private PlayerData playerData;

        // 蓝条实体
        private Image image;

        // 最大血量
        private float maxMP;

        // 当前血条显示蓝量
        private float MP;

        // Start is called before the first frame update
        void Start()
        {
            // 初始化主角信息
            playerData = GameObject.Find("Player").GetComponent<PlayerData>();
            // 初始化蓝条实体
            image = GetComponent<Image>();
            // 初始化最大蓝量
            maxMP = 100f;
            // 初始化当前蓝量显示
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

        // 更新蓝条长度
        void ShowMP()
        {
            var length = MP / maxMP;
            image.fillAmount = length;
        }
    }
}
