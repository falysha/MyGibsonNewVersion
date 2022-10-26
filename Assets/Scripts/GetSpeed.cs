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
            if(!GameManager.instance.havespeed)
            {
                GameManager.instance.havespeed = true;
            }
            current.SetActive(true);
            current.GetComponent<Animator>().SetBool("FadeInText",true);
            current.GetComponent<Animator>().SetBool("FadeOutText", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            current.GetComponent<Animator>().SetBool("FadeInText", false);
            current.GetComponent<Animator>().SetBool("FadeOutText", true);
            StartCoroutine(fadeout());
        }
    }

    public IEnumerator fadeout()
    {
        yield return new WaitForSeconds(1f);
        current.SetActive(false);
    }
}
