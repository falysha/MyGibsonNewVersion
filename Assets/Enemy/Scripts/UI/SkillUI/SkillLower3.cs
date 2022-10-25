using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class SkillLower3 : MonoBehaviour
    {
        // 主角信息
        private SkillController _skillController;

        // 技能倒计时实体
        private Image image;
        

        // Start is called before the first frame update
        void Start()
        {
            // 初始化主角信息
            _skillController = GameObject.Find("Player").GetComponent<SkillController>();
            // 初始化技能倒计时实体
            image = GetComponent<Image>();
            // 初始化最大CD
            ShowCD();
        }

        // Update is called once per frame
        void Update()
        {
            if (_skillController.hackCD <= _skillController.countedHackCD)
            {
                //0
            }
            else
            {
                ShowCD();
            }
        }

        // 更新CD
        void ShowCD()
        {
            var length = (_skillController.hackCD-_skillController.countedHackCD) / _skillController.hackCD;
            image.fillAmount = length;
        }
    }
}
