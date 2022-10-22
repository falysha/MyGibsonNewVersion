using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{   
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameManager.instance.GameOver();
            //StartCoroutine(SceneLoad.instance.RELoadScene(SceneManager.GetActiveScene().buildIndex));
        }
    }
}
