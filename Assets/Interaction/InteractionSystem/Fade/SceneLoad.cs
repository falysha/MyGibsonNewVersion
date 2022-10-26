using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ink.Runtime;
using UnityEngine.UI;
public class SceneLoad : MonoBehaviour
{
    public static SceneLoad instance;
    public Animator animator;//动画绑定
    public GameObject BlackPanel;//总框
    public Text Textdia;//文本框内容
    public Story blackStory;//墨迹文件
    public TextAsset inkJson;//文本

    public TextAsset bar;//json文件
    public int dialogueobj = 0;//对话对象

    public void Awake()
    {
        BlackPanel.SetActive(false);
        blackStory = new Story(inkJson.text);//获取字体
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

    public IEnumerator LoadScene(int index)//加载下一场景
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
    public IEnumerator RELoadScene(int index)//重新加载当前场景
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

    public void OnREloadedScene(AsyncOperation obj)//回调当前场景
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
    public void OnloadedScene(AsyncOperation obj)//回调下一场景并更改音乐
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
    public void ContinueStory()//继续播放
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
