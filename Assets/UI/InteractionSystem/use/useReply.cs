using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useReply : MonoBehaviour
{
    [Header("弹出UI")]
    public GameObject visualCue;//互动图标
    private bool playerInRange;//是否可互动
    private void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
            if (Input.GetButtonDown("interaction"))//互动键
            {
                visualCue.SetActive(false);
                //回血
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
