using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ink.Runtime;
using TMPro;
public class SceneLoad : MonoBehaviour
{
    public static SceneLoad instance;
    public Animator animator;//动画绑定
    public GameObject BlackPanel;//总框
    public TextMeshProUGUI Textdia;//文本框内容
    public Story blackStory;//墨迹文件
    public TextAsset inkJson;//文本

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
        yield return new WaitForSeconds(2f);
        AsyncOperation async =  SceneManager.LoadSceneAsync(index);
        async.completed += OnloadedScene;
    }
    public IEnumerator RELoadScene(int index)//重新加载当前场景
    {
        BlackPanel.SetActive(true);
        animator.SetBool("FadeIn", true);
        animator.SetBool("FadeOut", false);
        yield return new WaitForSeconds(2f);
        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        async.completed += OnREloadedScene;
    }

    public void OnREloadedScene(AsyncOperation obj)//回调当前场景
    {
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
            SoundManager.instance.SkyMusic();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SoundManager.instance.BarMusic();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SoundManager.instance.Undermusic();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SoundManager.instance.CompanyMusic();
        }
        animator.SetBool("FadeIn", false);
        animator.SetBool("FadeOut", true);
        
    }
    public void ContinueStory()//继续播放
    {
         Textdia.text = blackStory.Continue();
    }
}
