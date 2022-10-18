using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Gunfire : MonoBehaviour
{
    private bool Shot = false;
    

    private Light2D[] Fire;

    // Start is called before the first frame update
    void Awake()
    {
        Fire = gameObject.GetComponentsInChildren<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (Shot)
        {
            if (Fire[0].pointLightOuterRadius > 0f)
            {
                Fire[0].pointLightOuterRadius = Fire[0].pointLightOuterRadius - Time.fixedDeltaTime * 20;
                Fire[1].pointLightOuterRadius = Fire[1].pointLightOuterRadius - Time.fixedDeltaTime * 20;
            }
            else
            {
                Fire[0].pointLightOuterRadius = 0;
                Fire[1].pointLightOuterRadius =0;
                Shot = false;
            }
        }
    }

    public void gunFire()
    {
        Fire[0].pointLightOuterRadius = 1;
        Fire[1].pointLightOuterRadius = 1;
        Shot = true;
    }
}