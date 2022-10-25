using UnityEngine;
using UnityEngine.UI;

public class PlayerHideCD : MonoBehaviour
{
    // 主角信息
    private SkillController _skillController;

    // 蓝条实体
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        // 初始化主角信息
        _skillController = GameObject.Find("Player").GetComponent<SkillController>();
        // 初始化CD条实体
        image = GetComponent<Image>();
        // 初始化总CD

        ShowMP();
    }

    // Update is called once per frame
    void Update()
    {
        if (_skillController.countedFlashCD >= _skillController.flashCD)
        {
            
        }
        else
        {
            ShowMP();
        }
    }

    // 更新蓝条长度
    void ShowMP()
    {
        var length = _skillController.countedFlashCD / _skillController.flashCD;
        image.fillAmount = length;
    }
}
