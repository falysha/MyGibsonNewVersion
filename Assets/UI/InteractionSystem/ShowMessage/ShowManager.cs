using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;
public class ShowManager : MonoBehaviour
{
    private static ShowManager instance;//静态控制以便外部访问
    public Story currentStory;//墨迹文件

    [Header("对话框UI")]
    public GameObject ShowPanel;//总框

    public Text Textdia;//文本框内容

    public Text NameTag;//名字框内容

    public Image Image;//物品图像

    public Button Close;//名字框内容
    public bool ShowIsPlaying { get; private set; }//判断是否出现


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public static ShowManager GetInstance()//获取组件
    {
        return instance;
    }
    private void Start()//开始时重置
    { 
        Close.onClick.AddListener(ClosePanel);
        ShowIsPlaying = false;
        ShowPanel.SetActive(false);
    }

    private void Update()
    {
        if (!ShowIsPlaying)//如果没有进入对话框返回正常
        {
            return;
        }
    }
    public void EnterDialogueMode(TextAsset inkJson)//进入对话模式
    {
        GameManager.instance.isTalking();
        currentStory = new Story(inkJson.text);//读取text的json文件
        ShowIsPlaying = true;
        ShowPanel.SetActive(true);
        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()//退出对话模式
    {
        yield return new WaitForSeconds(0.2f);//等待0.2s后触发
        ShowIsPlaying = false;
        ShowPanel.SetActive(false);
        Textdia.text = "";//清空对话框
        GameManager.instance.isPlaying();
    }

    private void ContinueStory()//继续播放
    {
        Textdia.text = currentStory.Continue();
        DisplayName();//展示姓名
    }
    public void ClosePanel()
    {
        StartCoroutine(ExitDialogueMode());
    }
    public void DisplayName()
    {
        List<string> tags = currentStory.currentTags;//名称统计
        if (tags.Count > 0)
        {
            NameTag.text = tags[0];
        }
        else
        {
            NameTag.text = "";//清空姓名框
        }
    }
}
