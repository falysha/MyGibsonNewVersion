using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{
    [Header("����UI")]
    public GameObject visualCue;//����ͼ��

    private bool playerInRange;//����Ƿ��ڶԻ���

    [Header("īˮ�ļ�")]
    public TextAsset inkJson;//json�ļ�

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
            if (Input.GetButtonDown("interaction"))//������
            {
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
