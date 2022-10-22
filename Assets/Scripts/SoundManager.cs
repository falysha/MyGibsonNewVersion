using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;//����Ԥ�����Ա��ⲿ����
    public AudioSource backaudio;//��������
    public static bool KeepFadeIn = false, KeepFadeOut = false;

    public AudioClip MenuAudio,BarAudio, underAudio, skyAudio, CompanyAudio;//��������

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
        instance.backaudio.volume = 0.5f;//������С
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
    public void SkyMusic()//��̨��������
    {
        instance.backaudio.Stop();
        backaudio.clip = skyAudio;
        StartCoroutine(FadeIn());
    }
    public void BarMusic()//�ưɳ�������
    {
        instance.backaudio.Stop();
        backaudio.clip = BarAudio;
        StartCoroutine(FadeIn());
    }

    public void CompanyMusic()//��˾��������
    {
        instance.backaudio.Stop();
        backaudio.clip = CompanyAudio;
        StartCoroutine(FadeIn());
    }
    public void Undermusic()//���µ���������
    {
        instance.backaudio.Stop();
        backaudio.clip = underAudio;
        StartCoroutine(FadeIn());
    }
    public void Menumusic()//���˵���������
    {
        instance.backaudio.Stop();
        backaudio.clip = MenuAudio;
        StartCoroutine(FadeIn());
    }
    public void PauseLevelAudio()//��ͣ����
    {
        StartCoroutine(FadeOut());
    }
    public void StartLevelAudio()//��ʼ����
    {
        StartCoroutine(FadeIn());
    }
    public IEnumerator FadeIn()//��������
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
    public IEnumerator FadeOut()//��������
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
