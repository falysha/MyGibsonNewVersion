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
    //public Transform wherePlayer;//玩家在每个场景的出生位置
    public GameObject m_player;//玩家
    public GameState State;//游戏状态

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
        PlayerPrefs.DeleteAll();
        if (m_player!=null)
        {
            Vector3 vec = Vector3.zero;
            vec.x = PlayerPrefs.GetFloat("PlayerPosX", m_player.transform.position.x);
            vec.y = PlayerPrefs.GetFloat("PlayerPosY", m_player.transform.position.y);
            vec.z = PlayerPrefs.GetFloat("PlayerPosZ", m_player.transform.position.z);
            m_player.transform.position = vec;
        }

    }

    public void UpdatePosition()
    {
        m_player = GameObject.Find("Player");
        if (m_player != null)
        {
            Vector3 vec = Vector3.zero;
            vec.x = PlayerPrefs.GetFloat("PlayerPosX", m_player.transform.position.x);
            vec.y = PlayerPrefs.GetFloat("PlayerPosY", m_player.transform.position.y);
            vec.z = PlayerPrefs.GetFloat("PlayerPosZ", m_player.transform.position.z);
            m_player.transform.position = vec;
        }
    }
    public void LoadScenenext()//加载下一个场景
    {
        SceneLoad.instance.ContinueStory();
        StartCoroutine(SceneLoad.instance.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ReLoadScene()//重载当前场景
    {
        StartCoroutine(SceneLoad.instance.RELoadScene(SceneManager.GetActiveScene().buildIndex));
        instance.State = GameState.IsPlaying;
    }

    public void GameOver()//游戏结束
    {
        instance.State = GameState.GameOver;
        ReLoadScene();
    }
    public void ispause()//正在暂停
    {
        instance.State = GameState.IsPause;
        SoundManager.instance.PauseLevelAudio();
    }
    public void isPlaying()//正在游戏
    {
        if(!SoundManager.instance.backaudio.isPlaying)
        {
            SoundManager.instance.StartLevelAudio();
        }
        instance.State = GameState.IsPlaying;
    }
    public void isTalking()//正在说话
    {
        m_player = GameObject.Find("Player");
        if (m_player != null)
        {
            m_player.GetComponent<Animator>().SetBool("run",false);
        }
        instance.State = GameState.IsTalking;
    }
}

public enum GameState
{
    IsPlaying,//游戏进行中
    IsPause,//游戏暂停中
    GameOver,//游戏结束
    IsTalking//正在对话
}
