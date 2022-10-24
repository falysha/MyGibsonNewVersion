using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;
public class ShowManager : MonoBehaviour
{
    private static ShowManager instance;//��̬�����Ա��ⲿ����
    public Story currentStory;//ī���ļ�

    [Header("�Ի���UI")]
    public GameObject ShowPanel;//�ܿ�

    public Text Textdia;//�ı�������

    public Text NameTag;//���ֿ�����

    public Image Image;//��Ʒͼ��

    public Button Close;//���ֿ�����
    public bool ShowIsPlaying { get; private set; }//�ж��Ƿ����


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

    public static ShowManager GetInstance()//��ȡ���
    {
        return instance;
    }
    private void Start()//��ʼʱ����
    { 
        Close.onClick.AddListener(ClosePanel);
        ShowIsPlaying = false;
        ShowPanel.SetActive(false);
    }

    private void Update()
    {
        if (!ShowIsPlaying)//���û�н���Ի��򷵻�����
        {
            return;
        }
    }
    public void EnterDialogueMode(TextAsset inkJson)//����Ի�ģʽ
    {
        GameManager.instance.isTalking();
        currentStory = new Story(inkJson.text);//��ȡtext��json�ļ�
        ShowIsPlaying = true;
        ShowPanel.SetActive(true);
        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()//�˳��Ի�ģʽ
    {
        yield return new WaitForSeconds(0.2f);//�ȴ�0.2s�󴥷�
        ShowIsPlaying = false;
        ShowPanel.SetActive(false);
        Textdia.text = "";//��նԻ���
        GameManager.instance.isPlaying();
    }

    private void ContinueStory()//��������
    {
        Textdia.text = currentStory.Continue();
        DisplayName();//չʾ����
    }
    public void ClosePanel()
    {
        StartCoroutine(ExitDialogueMode());
    }
    public void DisplayName()
    {
        List<string> tags = currentStory.currentTags;//����ͳ��
        if (tags.Count > 0)
        {
            NameTag.text = tags[0];
        }
        else
        {
            NameTag.text = "";//���������
        }
    }
}
