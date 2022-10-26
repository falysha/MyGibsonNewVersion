using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ink.Runtime;
using UnityEngine.UI;
public class SceneLoad : MonoBehaviour
{
    public static SceneLoad instance;
    public Animator animator;//������
    public GameObject BlackPanel;//�ܿ�
    public Text Textdia;//�ı�������
    public Story blackStory;//ī���ļ�
    public TextAsset inkJson;//�ı�

    public TextAsset bar;//json�ļ�
    public int dialogueobj = 0;//�Ի�����

    public void Awake()
    {
        BlackPanel.SetActive(false);
        blackStory = new Story(inkJson.text);//��ȡ����
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

    public IEnumerator LoadScene(int index)//������һ����
    {
        BlackPanel.SetActive(true);
        animator.SetBool("FadeIn", true);
        animator.SetBool("FadeOut", false);
        StartCoroutine(SoundManager.instance.FadeOut());
        PlayerPrefs.DeleteAll();
        if(SceneManager.GetActiveScene().buildIndex == 6)
        {
            yield return new WaitForSeconds(2f);
            AsyncOperation asyncy = SceneManager.LoadSceneAsync(0);
            asyncy.completed += OnloadedScene;
        }
        else
        {
            yield return new WaitForSeconds(2f);
            AsyncOperation async = SceneManager.LoadSceneAsync(index);
            async.completed += OnloadedScene;
        }

    }
    public IEnumerator RELoadScene(int index)//���¼��ص�ǰ����
    {
        animator.gameObject.SetActive(true);
        instance.Textdia.text = " ";
        BlackPanel.SetActive(true);
        SoundManager.instance.PauseLevelAudio();
        animator.SetBool("FadeIn", true);
        animator.SetBool("FadeOut", false);
        yield return new WaitForSeconds(2f);
        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        async.completed += OnREloadedScene;
    }

    public void OnREloadedScene(AsyncOperation obj)//�ص���ǰ����
    {
        GameManager.instance.m_player = GameObject.Find("Player");
        if (GameManager.instance.m_player != null)
        {
            Vector3 vec = Vector3.zero;
            vec.x = PlayerPrefs.GetFloat("PlayerPosX", GameManager.instance.m_player.transform.position.x);
            vec.y = PlayerPrefs.GetFloat("PlayerPosY", GameManager.instance.m_player.transform.position.y);
            vec.z = PlayerPrefs.GetFloat("PlayerPosZ", GameManager.instance.m_player.transform.position.z);
            GameManager.instance.m_player.transform.position = vec;
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SoundManager.instance.StartLevelAudio();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SoundManager.instance.StartLevelAudio();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameManager.instance.havespeed = true;
            SoundManager.instance.StartLevelAudio();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            GameManager.instance.haveskill = true;
            GameManager.instance.havespeed = true;
            SoundManager.instance.StartLevelAudio();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            GameManager.instance.haveskill = true;
            GameManager.instance.havespeed = true;
            SoundManager.instance.StartLevelAudio();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            GameManager.instance.haveskill = true;
            GameManager.instance.havespeed = true;
            SoundManager.instance.StartLevelAudio();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            DialogManager.instance.diagoueobj = dialogueobj;
            DialogManager.GetInstance().EnterDialogueMode(bar);
        }
        animator.SetBool("FadeIn", false);
        animator.SetBool("FadeOut", true);

    }
    public void OnloadedScene(AsyncOperation obj)//�ص���һ��������������
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        { 
            SoundManager.instance.Menumusic();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SoundManager.instance.Undermusic();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SoundManager.instance.SkyMusic();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SoundManager.instance.BarMusic();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SoundManager.instance.CompanyMusic();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            SoundManager.instance.TopMusic();
        }
        else if(SceneManager.GetActiveScene().buildIndex == 6)
        {
            DialogManager.instance.diagoueobj = dialogueobj;
            DialogManager.GetInstance().EnterDialogueMode(bar);
            SoundManager.instance.BarMusic();
        }
        animator.SetBool("FadeIn", false);
        animator.SetBool("FadeOut", true);
        
    }
    public void ContinueStory()//��������
    {
        if (blackStory.canContinue)
        {
            Textdia.text = blackStory.Continue();
        }
        else
        {
            Textdia.text = "";
        }
    }
}
