using UnityEngine;
using UnityEngine.UI;

public class PlayerHideCD : MonoBehaviour
{
    // ������Ϣ
    private PlayerData playerData;

    // ����ʵ��
    private Image image;

    // ��CD
    private float maxCD;

    // ��ǰʣ��CD
    private float CD;

    // Start is called before the first frame update
    void Start()
    {
        // ��ʼ��������Ϣ
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
        // ��ʼ��CD��ʵ��
        image = GetComponent<Image>();
        // ��ʼ����CD
        maxCD = 3f;
        // ��ʼ����ǰʣ��CD
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

    // ������������
    void ShowMP()
    {
        var length = CD / maxCD;
        image.fillAmount = length;
    }
}
