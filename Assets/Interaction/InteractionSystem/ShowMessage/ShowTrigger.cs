using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTrigger : MonoBehaviour
{
    [Header("����UI")]
    public GameObject visualCue;//����ͼ��

    private bool playerInRange;//����Ƿ��ڶԻ���

    [Header("īˮ�ļ�")]
    public TextAsset inkJson;//json�ļ�

    public SpriteRenderer sprite;//��ȡͼ��

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && !ShowManager.GetInstance().ShowIsPlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetButtonDown("interaction"))//������
            {
                ShowManager.GetInstance().Image.sprite = sprite.sprite;
                ShowManager.GetInstance().EnterDialogueMode(inkJson);
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
