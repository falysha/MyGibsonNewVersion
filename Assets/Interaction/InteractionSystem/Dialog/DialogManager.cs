using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;//��̬�����Ա��ⲿ����
    public Story currentStory;//ī���ļ�
    public int diagoueobj;//�Ի�����
    public GameObject timeline;
    public GameObject player;

    [Header("�Ի���UI")]
    public GameObject dialoguePanel;//�ܿ�


    public GameObject continueIcon;//�����Ի�ͼ��

    public Text Textdia;//�ı�������

    public Text NameTag;//���ֿ�����

    public GameObject PlayerImage;//��������
    public Sprite[] PlayerPic;//��������״̬

    public GameObject KImage;//K����
    public Sprite[] KPic;//K����״̬

    public GameObject doctorImage;//��ʿ����
    public Sprite[] doctorPic;//��ʿ����״̬

    [SerializeField] private float typingSpeed = 0.04f;//�����ٶ�

    public bool DialogueIsPlaying { get; private set; }//�ж��Ƿ����

    private Coroutine displayLineCoroutine;//ΨһչʾЭ��

    private bool canContinueToNextLine = false;//�Ƿ������һ��

    [Header("ѡ��UI")]
    public VerticalLayoutGroup _choiceButtonContainer;//����ֱ����

    public Button _choiceButtonPrefab;//��ťԤ����


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

    public static DialogManager GetInstance()//��ȡ���
    {
        return instance;
    }
    private void Start()//��ʼʱ����
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
        if(!DialogueIsPlaying)//���û�н���Ի��򷵻�����
        {
            return;
        }

        if (canContinueToNextLine &&Input.GetButtonDown("Continue") && currentStory.currentChoices.Count == 0)//������
        {
            ContinueStory();//��ʼ�Ի�
        }
    }

    public void EnterDialogueMode(TextAsset inkJson)//����Ի�ģʽ
    {
        player = GameObject.Find("Player");
        if (diagoueobj == 0)//����ͨnpc�Ի�
        {
            PlayerImage.SetActive(true);
        }
        else if(diagoueobj == 1)//��K�Ի�
        {
            PlayerImage.SetActive(true);
            KImage.SetActive(true);
        }
        else if(diagoueobj == 2)//����ʿ�Ի�
        {
            PlayerImage.SetActive(true);
            doctorImage.SetActive(true);
        }
        if (player!=null)
        {
            player.GetComponent<Animator>().SetBool("run", false);
        }
        currentStory = new Story(inkJson.text);//��ȡtext��json�ļ�
        DialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        GameManager.instance.isTalking();
        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()//�˳��Ի�ģʽ
    {
        timeline = GameObject.Find("Timeline");
        yield return new WaitForSeconds(0.2f);//�ȴ�0.2s�󴥷�
        DialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        PlayerImage.SetActive(false);
        KImage.SetActive(false);
        doctorImage.SetActive(false);
        GameManager.instance.isPlaying();
        Textdia.text = "";//��նԻ���
        if(timeline != null)
        {
            timeline.GetComponent<PlayableDirector>().Play();
        }
        if(SceneManager.GetActiveScene().buildIndex == 6)
        {
            GameManager.instance.LoadScenenext();
        }
    }

    private void ContinueStory()//��������
    {
        if (currentStory.canContinue)
        {
            if(displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            //Textdia.text = currentStory.Continue();
            DisplayName();//չʾ����
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }
    private IEnumerator DisplayLine(string line)
    {
        Textdia.text = "<color=#FFFFFF00>jayw</color>";//��������

        canContinueToNextLine = false;
        continueIcon.SetActive(false);

        foreach (char letter in line.ToCharArray())//���ֻ���Ч
        {
            Textdia.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        continueIcon.SetActive(true);//��ʾ����icon
        canContinueToNextLine = true;//�������
        DisplayChoices();//չʾѡ��
    }
    private void DisplayChoices()
    {
        //���ѡ���Ƿ�����ʾ
            if (_choiceButtonContainer.GetComponentsInChildren<Button>().Length > 0) return;
            for (int i = 0; i < currentStory.currentChoices.Count; i++) //չʾ�����е�ѡ��
            {

                var choice = currentStory.currentChoices[i];
                var button = CreateChoiceButton(choice.text); //����ѡ��ť

                button.onClick.AddListener(() => OnClickChoiceButton(choice));
            }
    }

    Button CreateChoiceButton(string text)
    {
        //��Ԥ���崴�찴ť
        var choiceButton = Instantiate(_choiceButtonPrefab);
        choiceButton.transform.SetParent(_choiceButtonContainer.transform, false);

        //�������밴ť
        var buttonText = choiceButton.GetComponentInChildren<Text>();
        buttonText.text = text;

        return choiceButton;
    }
    void OnClickChoiceButton(Choice choice)
    {
        currentStory.ChooseChoiceIndex(choice.index); //����ink����ѡ��
        RefreshChoiceView(); //�Ƴ�ѡ��
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
        List<string> tags = currentStory.currentTags;//����ͳ��
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
            NameTag.text = "";//���������
        }
    }
}
