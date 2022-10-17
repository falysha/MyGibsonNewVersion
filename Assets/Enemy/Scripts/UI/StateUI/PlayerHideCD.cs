using UnityEngine;
using UnityEngine.UI;

public class PlayerHideCD : MonoBehaviour
{
    // 主角信息
    private PlayerData playerData;

    // 蓝条实体
    private Image image;

    // 总CD
    private float maxCD;

    // 当前剩余CD
    private float CD;

    // Start is called before the first frame update
    void Start()
    {
        // 初始化主角信息
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
        // 初始化CD条实体
        image = GetComponent<Image>();
        // 初始化总CD
        maxCD = 3f;
        // 初始化当前剩余CD
        CD = playerData.currentHideCD;

        ShowMP();
    }

    // Update is called once per frame
    void Update()
    {
        if (CD == playerData.currentHideCD)
        {
            return;
        }
        else
        {
            CD = playerData.currentHideCD;
            ShowMP();
        }
    }

    // 更新蓝条长度
    void ShowMP()
    {
        var length = CD / maxCD;
        image.fillAmount = length;
    }
}
