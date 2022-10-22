using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;


public class DialogManager : MonoBehaviour
{
    private static DialogManager instance;//��̬�����Ա��ⲿ����
    public Story currentStory;//ī���ļ�

    [Header("�Ի���UI")]
    public GameObject dialoguePanel;//�ܿ�

    public GameObject continueIcon;//�����Ի�ͼ��

    public TextMeshProUGUI Textdia;//�ı�������

    public TextMeshProUGUI NameTag;//���ֿ�����

    public GameObject PlayerImage;//��������

    public GameObject KImage;//K����

    public GameObject doctorImage;//��ʿ����

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
        DialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        continueIcon.SetActive(false);
        PlayerImage.SetActive(false);
        KImage.SetActive(false);
        doctorImage.SetActive(false);
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
        currentStory = new Story(inkJson.text);//��ȡtext��json�ļ�
        DialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()//�˳��Ի�ģʽ
    {
        yield return new WaitForSeconds(0.2f);//�ȴ�0.2s�󴥷�
        DialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        PlayerImage.SetActive(false);
        KImage.SetActive(false);
        doctorImage.SetActive(false);

        Textdia.text = "";//��նԻ���
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
        Textdia.text = "\t";//��նԻ���

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
            if(NameTag.text == "c")
            {
                PlayerImage.SetActive(true);
                KImage.SetActive(false);
                doctorImage.SetActive(false);
            }
            else if (NameTag.text == "k")
            {
                KImage.SetActive(true);
                PlayerImage.SetActive(false);
                doctorImage.SetActive(false);
            }
            else if (NameTag.text == "Doctor")
            {
                KImage.SetActive(false);
                PlayerImage.SetActive(false);
                doctorImage.SetActive(true);
            }
            else
            {
                PlayerImage.SetActive(false);
                KImage.SetActive(false);
                doctorImage.SetActive(false);
            }
        }
        else
        {
            NameTag.text = "";//���������
        }
    }
}
