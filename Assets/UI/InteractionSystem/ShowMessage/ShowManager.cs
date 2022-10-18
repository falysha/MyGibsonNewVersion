using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
public class ShowManager : MonoBehaviour
{
    private static ShowManager instance;//��̬�����Ա��ⲿ����
    public Story currentStory;//ī���ļ�

    [Header("�Ի���UI")]
    public GameObject ShowPanel;//�ܿ�

    public Text Textdia;//�ı�������

    public Text NameTag;//���ֿ�����

    public Button Close;//���ֿ�����
    public bool ShowIsPlaying { get; private set; }//�ж��Ƿ����


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("�ڳ������ҵ�����Ի�������");
        }
        instance = this;
    }

    public static ShowManager GetInstance()//��ȡ���
    {
        return instance;
    }
    private void Start()//��ʼʱ����
    {
        Close = GetComponent<Button>();
        ShowIsPlaying = false;
        ShowPanel.SetActive(false);
    }

    private void Update()
    {
        if (!ShowIsPlaying)//���û�н���Ի��򷵻�����
        {
            return;
        }

        if (Input.GetButtonDown("Continue"))//������
        {
            if (ShowIsPlaying)//���û�н���Ի��򷵻�����
            {
                return;
            }
            ContinueStory();//��ʼ�Ի�
        }
    }

    public void EnterDialogueMode(TextAsset inkJson)//����Ի�ģʽ
    {
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
    }

    private void ContinueStory()//��������
    {
        if (currentStory.canContinue)
        {
            Textdia.text = currentStory.Continue();
            DisplayName();//չʾ����
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
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
