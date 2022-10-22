using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [Header("弹出UI")]
    [SerializeField] public GameObject visualCue;//互动图标

    private bool playerInRange;//玩家是否处于对话中

    [Header("墨水文件")]
    [SerializeField] public TextAsset inkJson;//json文件


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
            if(Input.GetButtonDown("interaction"))//互动键
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
