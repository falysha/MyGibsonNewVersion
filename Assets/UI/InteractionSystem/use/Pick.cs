using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{
    [Header("弹出UI")]
    public GameObject visualCue;//互动图标

    private bool playerInRange;//玩家是否处于对话中

    [Header("墨水文件")]
    public TextAsset inkJson;//json文件

    public SpriteRenderer sprite;

    public GameObject player;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (playerInRange && !ShowManager.GetInstance().ShowIsPlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetButtonDown("interaction"))//互动键
            {
                ShowManager.GetInstance().Image.sprite = sprite.sprite;
                //player.GetComponent<PlayerController>().canControl = false;
                player.GetComponent<Animator>().SetTrigger("pick");
                StartCoroutine(pick());
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }
    private IEnumerator pick()
    {
        yield return new WaitForSeconds(0.5f);
        ShowManager.GetInstance().EnterDialogueMode(inkJson);
        Destroy(gameObject);
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
