using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [Header("����UI")]
    [SerializeField] public GameObject visualCue;//����ͼ��

    private bool playerInRange;//����Ƿ��ڶԻ���

    [Header("īˮ�ļ�")]
    [SerializeField] public TextAsset inkJson;//json�ļ�


    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if(playerInRange && !DialogManager.GetInstance().DialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if(Input.GetButtonDown("interaction"))//������
            {
                DialogManager.GetInstance().EnterDialogueMode(inkJson);
                visualCue.SetActive(false);
                Destroy(gameObject);
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
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
