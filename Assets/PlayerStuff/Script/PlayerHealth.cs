using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static float realHealth = 100;
    public bool locked = false;
    public float fakeHealth = 100;
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
        if (realHealth<fakeHealth)
        {
            fakeHealth = fakeHealth - 0.04f;
        }
        else
        {
            fakeHealth = realHealth;
        }
    }

    public void Heal(float healthNum)
    {
        realHealth = realHealth + healthNum;
    }
}
