using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ink.Runtime;
using TMPro;
public class SceneLoad : MonoBehaviour
{
    public static SceneLoad instance;
    public Animator animator;
    public GameObject BlackPanel;//总框
    public TextMeshProUGUI Textdia;//文本框内容
    public Story blackStory;//墨迹文件
    public TextAsset inkJson;//文本

    public void Awake()
    {
        BlackPanel.SetActive(false);
        blackStory = new Story(inkJson.text);
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

    public IEnumerator LoadScene(int index)
    {
        
        BlackPanel.SetActive(true);
        animator.SetBool("FadeIn", true);
        animator.SetBool("FadeOut", false);
        yield return new WaitForSeconds(2f);
        AsyncOperation async =  SceneManager.LoadSceneAsync(index);
        async.completed += OnloadedScene;
    }

    public void OnloadedScene(AsyncOperation obj)
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
