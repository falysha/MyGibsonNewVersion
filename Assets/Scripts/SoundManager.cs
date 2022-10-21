using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;//����Ԥ�����Ա��ⲿ����
    public AudioSource backaudio;//��������

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
            SkyMusic();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
             BarMusic();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
             Undermusic();
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
        instance.backaudio.Play();
    }
    public void BarMusic()//�ưɳ�������
    {
        instance.backaudio.Stop();
        backaudio.clip = BarAudio;
        instance.backaudio.Play();
    }

    public void CompanyMusic()
    {
        instance.backaudio.Stop();
        backaudio.clip = CompanyAudio;
        instance.backaudio.Play();
    }
    public void Undermusic()
    {
        instance.backaudio.Stop();
        backaudio.clip = underAudio;
        instance.backaudio.Play();
    }
    public void Menumusic()
    {
        instance.backaudio.Stop();
        backaudio.clip = MenuAudio;
        instance.backaudio.Play();
    }
    public void PauseLevelAudio()
    {
        instance.backaudio.Pause();
    }
    public void StartLevelAudio()
    {
        instance.backaudio.Play();
    }

}
