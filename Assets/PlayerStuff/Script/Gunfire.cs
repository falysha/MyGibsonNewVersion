using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Gunfire : MonoBehaviour
{
    private bool Shot = false;

    private Light2D Head;

    private Light2D[] Back;

    // Start is called before the first frame update
    void Start()
    {
        Head = gameObject.GetComponent<Light2D>();
        Back = gameObject.GetComponentsInChildren<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (Shot)
        {
            if (Head.pointLightOuterRadius > 0f)
            {
                Head.pointLightOuterRadius = Head.pointLightOuterRadius - Time.fixedDeltaTime * 20;
                Back[1].pointLightOuterRadius = Back[1].pointLightOuterRadius - Time.fixedDeltaTime * 20;
            }
            else
            {
                Head.pointLightOuterRadius = 0;
                Back[1].pointLightOuterRadius =0;
                Shot = false;
            }
        }
    }

    public void gunFire()
    {
        Head.pointLightOuterRadius = 1;
        Back[1].pointLightOuterRadius = 1;
        Shot = true;
    }
}