using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class SkillLower2 : MonoBehaviour
    {
        // 主角信息
        private PlayerData playerData;

        // 技能倒计时实体
        private Image image;

        // 最大CD
        private float maxCD;

        // 当前剩余CD
        private float CD;

        // Start is called before the first frame update
        void Start()
        {
            // 初始化主角信息
            playerData = GameObject.Find("Player").GetComponent<PlayerData>();
            // 初始化技能倒计时实体
            image = GetComponent<Image>();
            // 初始化最大CD
            maxCD = 3f;
            // 初始化当前剩余CD
            CD = playerData.skill2CD;

            ShowCD();
        }

        // Update is called once per frame
        void Update()
        {
            if (CD == playerData.skill2CD)
            {
                return;
            }
            else
            {
                CD = playerData.skill2CD;
                ShowCD();
            }
        }

        // 更新CD
        void ShowCD()
        {
            var length = CD / maxCD;
            image.fillAmount = length;
        }
    }
}
