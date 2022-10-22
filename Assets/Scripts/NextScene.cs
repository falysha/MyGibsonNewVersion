using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public GameObject visualCue;//»¥¶¯Í¼±ê
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
            if (Input.GetButtonDown("interaction"))//»¥¶¯¼ü
            {
                loadScenenext();
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }
    
    public void loadScenenext()
    {
        SceneLoad.instance.ContinueStory();
        StartCoroutine(SceneLoad.instance.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }
}
