using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPoint : MonoBehaviour
{
    public GameObject visualCue;//����ͼ��
    public Transform point;//���͵�
    private bool playerInRange;

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
    private void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
            if (Input.GetButtonDown("interaction"))//������
            {
                loadpointnext();
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    public void loadpointnext()
    {
        PlayerPrefs.SetFloat("PlayerPosX", point.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", point.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", point.position.z);
        GameManager.instance.UpdatePosition();
        Destroy(gameObject, 1f);
    }
}
