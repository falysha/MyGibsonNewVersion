using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    private SpriteRenderer playerRenderer;
    private Transform playerTransform;
    private SpriteRenderer[] Shadows;
    public bool shadowStart = true;
    private int counter = 0;

    private void Awake()
    {
        playerRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        Shadows = GetComponentsInChildren<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        counter = (counter+1)%5;
        if (shadowStart)
        {
            if (counter==0)
            {
                for (int i = 1; i < 7; i++)
                {
                    Shadows[i].sprite = Shadows[i - 1].sprite;
                    Shadows[i].gameObject.transform.position = Shadows[i - 1].gameObject.transform.position;
                    Shadows[i].gameObject.transform.localScale = Shadows[i - 1].gameObject.transform.localScale;
                }

                Shadows[0].sprite = playerRenderer.sprite;
                Shadows[0].gameObject.transform.position = playerTransform.transform.position;
                Shadows[0].gameObject.transform.localScale = playerTransform.transform.localScale;
            }
        }
    }
}