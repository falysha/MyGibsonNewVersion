using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScroolContent : MonoBehaviour
{
    public static ScroolContent instance;
    private float Speed = 500.0f;
    private float boundaryTextEnd = 3100f;

    public RectTransform myGorectTransform;
    public Text Maintext;
    public bool isLooping =false;

    public void Start()
    {
        myGorectTransform = gameObject.GetComponent<RectTransform>();
    }
    public IEnumerator autoScroll()
    {
        while(myGorectTransform.localPosition.y < boundaryTextEnd)
        {
            myGorectTransform.Translate(Vector3.up * Speed * Time.deltaTime);
            yield return null;
        }
    }

    public void AutoS()
    {
        StartCoroutine(autoScroll());
    }

    public void nextscene()
    {
        GameManager.instance.LoadScenenext();
    }

    public void istalk()
    {
        GameManager.instance.isTalking();
    }
}
