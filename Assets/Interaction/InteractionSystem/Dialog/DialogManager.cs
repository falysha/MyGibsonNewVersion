using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;//静态控制以便外部访问
    public Story currentStory;//墨迹文件
    public int diagoueobj;//对话对象
    public GameObject timeline;
    public GameObject player;

    [Header("对话框UI")]
    public GameObject dialoguePanel;//总框


    public GameObject continueIcon;//继续对话图像

    public Text Textdia;//文本框内容

    public Text NameTag;//名字框内容

    public GameObject PlayerImage;//主角立绘
    public Sprite[] PlayerPic;//主角立绘状态

    public GameObject KImage;//K立绘
    public Sprite[] KPic;//K立绘状态

    public GameObject doctorImage;//博士立绘
    public Sprite[] doctorPic;//博士立绘状态

    [SerializeField] private float typingSpeed = 0.04f;//打字速度

    public bool DialogueIsPlaying { get; private set; }//判断是否出现

    private Coroutine displayLineCoroutine;//唯一展示协程

    private bool canContinueToNextLine = false;//是否进入下一行

    [Header("选项UI")]
    public VerticalLayoutGroup _choiceButtonContainer;//纵向垂直布局

    public Button _choiceButtonPrefab;//按钮预制体


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

    public static DialogManager GetInstance()//获取组件
    {
        return instance;
    }
    private void Start()//开始时重置
    {
        player = GameObject.Find("Player");
        DialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        continueIcon.SetActive(false);
        PlayerImage.SetActive(false);
        KImage.SetActive(false);
        doctorImage.SetActive(false);
        diagoueobj = 0;
    }   

    private void Update()
    {
        if(!DialogueIsPlaying)//如果没有进入对话框返回正常
        {
            return;
        }

        if (canContinueToNextLine &&Input.GetButtonDown("Continue") && currentStory.currentChoices.Count == 0)//互动键
        {
            ContinueStory();//开始对话
        }
    }

    public void EnterDialogueMode(TextAsset inkJson)//进入对话模式
    {
        player = GameObject.Find("Player");
        if (diagoueobj == 0)//跟普通npc对话
        {
            PlayerImage.SetActive(true);
        }
        else if(diagoueobj == 1)//跟K对话
        {
            PlayerImage.SetActive(true);
            KImage.SetActive(true);
        }
        else if(diagoueobj == 2)//跟博士对话
        {
            PlayerImage.SetActive(true);
            doctorImage.SetActive(true);
        }
        if (player!=null)
        {
            player.GetComponent<Animator>().SetBool("run", false);
        }
        currentStory = new Story(inkJson.text);//读取text的json文件
        DialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        GameManager.instance.isTalking();
        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()//退出对话模式
    {
        timeline = GameObject.Find("Timeline");
        yield return new WaitForSeconds(0.2f);//等待0.2s后触发
        DialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        PlayerImage.SetActive(false);
        KImage.SetActive(false);
        doctorImage.SetActive(false);
        GameManager.instance.isPlaying();
        Textdia.text = "";//清空对话框
        if(timeline != null)
        {
            timeline.GetComponent<PlayableDirector>().Play();
        }
        if(SceneManager.GetActiveScene().buildIndex == 6)
        {
            GameManager.instance.LoadScenenext();
        }
    }

    private void ContinueStory()//继续播放
    {
        if (currentStory.canContinue)
        {
            if(displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            //Textdia.text = currentStory.Continue();
            DisplayName();//展示姓名
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }
    private IEnumerator DisplayLine(string line)
    {
        Textdia.text = "<color=#FFFFFF00>jayw</color>";//首行缩进

        canContinueToNextLine = false;
        continueIcon.SetActive(false);

        foreach (char letter in line.ToCharArray())//打字机特效
        {
            Textdia.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        continueIcon.SetActive(true);//显示继续icon
        canContinueToNextLine = true;//允许继续
        DisplayChoices();//展示选项
    }
    private void DisplayChoices()
    {
        //检查选项是否已显示
            if (_choiceButtonContainer.GetComponentsInChildren<Button>().Length > 0) return;
            for (int i = 0; i < currentStory.currentChoices.Count; i++) //展示出所有的选择
            {

                var choice = currentStory.currentChoices[i];
                var button = CreateChoiceButton(choice.text); //创造选择按钮

                button.onClick.AddListener(() => OnClickChoiceButton(choice));
            }
    }

    Button CreateChoiceButton(string text)
    {
        //从预制体创造按钮
        var choiceButton = Instantiate(_choiceButtonPrefab);
        choiceButton.transform.SetParent(_choiceButtonContainer.transform, false);

        //文字输入按钮
        var buttonText = choiceButton.GetComponentInChildren<Text>();
        buttonText.text = text;

        return choiceButton;
    }
    void OnClickChoiceButton(Choice choice)
    {
        currentStory.ChooseChoiceIndex(choice.index); //返回ink告诉选项
        RefreshChoiceView(); //移除选项
        ContinueStory();
    }
    void RefreshChoiceView()
    {
        if (_choiceButtonContainer != null)
        {
            foreach (var button in _choiceButtonContainer.GetComponentsInChildren<Button>())
            {
                Destroy(button.gameObject);
            }
        }
    }
    public void DisplayName()
    {
        List<string> tags = currentStory.currentTags;//名称统计
        if (tags.Count > 0)
        {
            NameTag.text =tags[0];
            if (NameTag.text == "Mayer")
            {
                PlayerImage.GetComponent<Image>().sprite = PlayerPic[1];
                if (KImage != null)
                {
                    KImage.GetComponent<Image>().sprite = KPic[0];
                }
                if (doctorImage != null)
                {
                    doctorImage.GetComponent<Image>().sprite = doctorPic[0];
                }
            }
            else if (NameTag.text == "K")
            {
                KImage.GetComponent<Image>().sprite = KPic[1];
                if (PlayerImage != null)
                {
                    PlayerImage.GetComponent<Image>().sprite = PlayerPic[0];
                }
                if (doctorImage != null)
                {
                    doctorImage.GetComponent<Image>().sprite = doctorPic[0];
                }
            }
            else if (NameTag.text == "Tyrell")
            {
                doctorImage.GetComponent<Image>().sprite = doctorPic[1];

                if (PlayerImage != null)
                {
                    PlayerImage.GetComponent<Image>().sprite = PlayerPic[0];
                }
                if (KImage != null)
                {
                    KImage.GetComponent<Image>().sprite = KPic[0];
                }
            }
            else if (NameTag.text == "")
            {
                if (PlayerImage != null)
                {
                    PlayerImage.GetComponent<Image>().sprite = PlayerPic[0];
                }
                if (KImage != null)
                {
                    KImage.GetComponent<Image>().sprite = KPic[0];
                }
                if (doctorImage != null)
                {
                    doctorImage.GetComponent<Image>().sprite = doctorPic[0];
                }
            }
            else
            {
                if (PlayerImage != null)
                {
                    PlayerImage.GetComponent<Image>().sprite = PlayerPic[0];
                }
                if (KImage != null)
                {
                    KImage.GetComponent<Image>().sprite = KPic[0];
                }
                if (doctorImage != null)
                {
                    doctorImage.GetComponent<Image>().sprite = doctorPic[0];
                }
            }
        }
        else
        {
            NameTag.text = "";//清空姓名框
        }
    }
}
