using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour
{
    public GameObject current;//���ֽ̳�
    public void Awake()
    {
        current.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            current.SetActive(true);
            current.GetComponent<Animator>().SetBool("FadeInText", true);
            current.GetComponent<Animator>().SetBool("FadeOutText", false);
            StartCoroutine(fadeout());
            Destroy(gameObject, 10f);
        }
    }

    public IEnumerator fadeout()
    {
        yield return new WaitForSeconds(8f);
        current.GetComponent<Animator>().SetBool("FadeInText", false);
        current.GetComponent<Animator>().SetBool("FadeOutText", true);
    }
}
