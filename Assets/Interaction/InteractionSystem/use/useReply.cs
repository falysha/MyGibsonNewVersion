using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useReply : MonoBehaviour
{
    [Header("����UI")]
    public GameObject visualCue;//����ͼ��
    private bool playerInRange;//�Ƿ�ɻ���
    private void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
            if (Input.GetButtonDown("interaction"))//������
            {
                visualCue.SetActive(false);
                //��Ѫ
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
