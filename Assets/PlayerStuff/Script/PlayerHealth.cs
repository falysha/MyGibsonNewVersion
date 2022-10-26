using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static float realHealth = 100;
    public bool locked = false;
    public static float fakeHealth = 100;
    private bool oneShotKey = false;
    private GameManager _gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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

        if (fakeHealth<=0&&!oneShotKey)
        {
            oneShotKey = true;
            _gameManager.ReLoadScene();
            
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            realHealth = 0;
            fakeHealth = 0;
        }
    }

    
}
