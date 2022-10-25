using UnityEngine;
using UnityEngine.UI;

public class PlayerHideCD : MonoBehaviour
{
    // ������Ϣ
    private SkillController _skillController;

    // ����ʵ��
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        // ��ʼ��������Ϣ
        _skillController = GameObject.Find("Player").GetComponent<SkillController>();
        // ��ʼ��CD��ʵ��
        image = GetComponent<Image>();
        // ��ʼ����CD

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

    // ������������
    void ShowMP()
    {
        var length = _skillController.countedFlashCD / _skillController.flashCD;
        image.fillAmount = length;
    }
}
