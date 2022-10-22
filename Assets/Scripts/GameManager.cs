using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool havespeed = false;
    public bool haveskill = false;
    public static GameManager instance;
    //public Transform wherePlayer;//�����ÿ�������ĳ���λ��
    public GameObject m_player;//���
    public GameState State;//��Ϸ״̬

    public void Awake()
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

    public void Start()
    {
        m_player = GameObject.Find("Player");
        /*if(m_player != null)
        {
            Vector3 vec = Vector3.zero;
            vec.x = PlayerPrefs.GetFloat("PlayerPosX", wherePlayer.transform.position.x);
            vec.y = PlayerPrefs.GetFloat("PlayerPosY", wherePlayer.transform.position.y);
            vec.z = PlayerPrefs.GetFloat("PlayerPosX", wherePlayer.transform.position.z);
            m_player.transform.position = vec;
        }*/
    }

    public void LoadScenenext()
    {
        SceneLoad.instance.ContinueStory();
        StartCoroutine(SceneLoad.instance.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ReLoadScene()
    {
        StartCoroutine(SceneLoad.instance.RELoadScene(SceneManager.GetActiveScene().buildIndex));
    }

    public void GameOver()//��Ϸ����
    {
        instance.State = GameState.GameOver;
        ReLoadScene();
    }
    public void ispause()//������ͣ
    {
        instance.State = GameState.IsPause;
        SoundManager.instance.PauseLevelAudio();
    }
    public void isPlaying()//������Ϸ
    {
        if(!SoundManager.instance.backaudio.isPlaying)
        {
            SoundManager.instance.StartLevelAudio();
        }
        instance.State = GameState.IsPlaying;
    }
    public void isTalking()//����˵��
    {
        instance.State = GameState.IsTalking;
    }
}

public enum GameState
{
    IsPlaying,//��Ϸ������
    IsPause,//��Ϸ��ͣ��
    GameOver,//��Ϸ����
    IsTalking//���ڶԻ�
}
