using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;//生成预制体以便外部访问
    public AudioSource backaudio;//背景音乐
    public static bool KeepFadeIn = false, KeepFadeOut = false;

    public AudioClip MenuAudio,BarAudio, underAudio, skyAudio, CompanyAudio;//背景音乐

    public void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
        backaudio = gameObject.AddComponent<AudioSource>();
        instance.backaudio.volume = 0.5f;//音量大小
        instance.backaudio.loop = true;
        instance.backaudio.playOnAwake = true;
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Menumusic();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Undermusic();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SkyMusic();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            BarMusic();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            CompanyMusic();
        }
    }
    public void SkyMusic()//天台场景音乐
    {
        instance.backaudio.Stop();
        backaudio.clip = skyAudio;
        StartCoroutine(FadeIn());
    }
    public void BarMusic()//酒吧场景音乐
    {
        instance.backaudio.Stop();
        backaudio.clip = BarAudio;
        StartCoroutine(FadeIn());
    }

    public void CompanyMusic()//公司场景音乐
    {
        instance.backaudio.Stop();
        backaudio.clip = CompanyAudio;
        StartCoroutine(FadeIn());
    }
    public void Undermusic()//地下道场景音乐
    {
        instance.backaudio.Stop();
        backaudio.clip = underAudio;
        StartCoroutine(FadeIn());
    }
    public void Menumusic()//主菜单场景音乐
    {
        instance.backaudio.Stop();
        backaudio.clip = MenuAudio;
        StartCoroutine(FadeIn());
    }
    public void PauseLevelAudio()//暂停音乐
    {
        StartCoroutine(FadeOut());
    }
    public void StartLevelAudio()//开始音乐
    {
        StartCoroutine(FadeIn());
    }
    public IEnumerator FadeIn()//淡入音乐
    {
        instance.backaudio.Play();
        float timeToFade = 2f;
        float timeElapsed = 0;
        while(timeElapsed< timeToFade)
        {
            instance.backaudio.volume = Mathf.Lerp(0, 0.5f, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
    public IEnumerator FadeOut()//淡出音乐
    {
        float timeToFade = 2f;
        float timeElapsed = 0;
        while (timeElapsed < timeToFade)
        {
            instance.backaudio.volume = Mathf.Lerp(0.5f, 0, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        instance.backaudio.Stop();
    }
}
