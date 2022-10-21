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
    }

    public void Start()
    {
        m_player = GameObject.Find("Player");
        /*Vector3 vec = Vector3.zero;

        vec.x = PlayerPrefs.GetFloat("PlayerPosX", wherePlayer.transform.position.x);
        vec.y = PlayerPrefs.GetFloat("PlayerPosY", wherePlayer.transform.position.y);
        vec.z = PlayerPrefs.GetFloat("PlayerPosX", wherePlayer.transform.position.z);
        m_player.transform.position = vec;*/
    }

    public void LoadScenenext()
    {
        SceneLoad.instance.ContinueStory();
        StartCoroutine(SceneLoad.instance.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ReLoadScene()
    {
        StartCoroutine(SceneLoad.instance.LoadScene(SceneManager.GetActiveScene().buildIndex));
    }

}

public enum GameState
{
    IsPlaying,//��Ϸ������
    IsPause,//��Ϸ��ͣ��
    GameOver,//��Ϸ����
    IsTalking//���ڶԻ�
}
