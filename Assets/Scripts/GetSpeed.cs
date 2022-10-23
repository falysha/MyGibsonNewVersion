using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GetSpeed : MonoBehaviour
{
    public GameObject current;//新手教程

    public void Awake()
    {
        current.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameManager.instance.havespeed = true;
            current.SetActive(true);
            current.GetComponent<Animator>().SetBool("FadeInText",true);
            current.GetComponent<Animator>().SetBool("FadeOutText",false);
            StartCoroutine(fadeout());
            Destroy(gameObject,5f);
        }
    }

    public IEnumerator fadeout()
    {
        yield return new WaitForSeconds(2f);
        current.GetComponent<Animator>().SetBool("FadeInText", false);
        current.GetComponent<Animator>().SetBool("FadeOutText", true);
    }
}
