using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public bool isHackReady = true;

    public bool isShotGunReady = true;

    public bool isRocketReady = true;

    public float hackCD = 20f;

    public float shotGunCD = 10f;

    public float rocketCD = 15f;

    private float countedHackCD = 20f;

    private float countedShotGunCD = 10f;

    private float countedRocketCD = 15f;
    
    public float Fury = 0;

    private PlayerController _playerController;

    private PlayerHealth _playerHealth;

    private SpeedState _speedState = SpeedState.Empty;

    // Start is called before the first frame update
    void Start()
    {
        countedHackCD = 20f;
        countedShotGunCD = 10f;
        countedRocketCD = 15f;
        _playerController = FindObjectOfType<PlayerController>();
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        //Hack
        if (countedHackCD >= hackCD)
        {
            isHackReady = true;
        }
        else
        {
            countedHackCD = countedHackCD + Time.fixedDeltaTime;
        }


        //ShotGun
        if (countedShotGunCD >= shotGunCD)
        {
            isShotGunReady = true;
        }
        else
        {
            countedShotGunCD = countedShotGunCD + Time.fixedDeltaTime;
        }


        //Rocket
        if (countedRocketCD >= rocketCD)
        {
            isRocketReady = true;
        }
        else
        {
            countedRocketCD = countedRocketCD + Time.fixedDeltaTime;
        }
    }

    public void startCountingHack()
    {
        isHackReady = false;
        countedHackCD = 0;
    }

    public void startCountingShotGun()
    {
        isShotGunReady = false;
        countedShotGunCD = 0;
    }

    public void startCountingRocket()
    {
        isRocketReady = false;
        countedRocketCD = 0;
    }

    public void speedUpStart()
    {
        if (_speedState==SpeedState.Empty)
        {
            if (Fury<20)
            {
                if (_playerHealth.realHealth>20)
                {
                    _playerHealth.realHealth = _playerHealth.realHealth - (20 - Fury);
                    Fury = 0;
                    StartCoroutine(speedUp());
                }
            }
            else
            {
                Fury = Fury - 20;
                StartCoroutine(speedUp());
            }
        }
    }

    public void speedDownStart()
    {
        if (_speedState==SpeedState.Empty)
        {
            if (Fury<20)
            {
                if (_playerHealth.realHealth>20)
                {
                    _playerHealth.realHealth = _playerHealth.realHealth - (20 - Fury);
                    Fury = 0;
                    StartCoroutine(speedDown());
                }
            }
            else
            {
                Fury = Fury - 20;
                StartCoroutine(speedDown());
            }
        }
    }

    IEnumerator speedUp()
    {
        _speedState = SpeedState.SpeedUp;
        _playerController.horizontalMoveSpeed = 20f;
        _playerController.Strength = 15f;
        //攻击提升代码
        yield return new WaitForSeconds(10f);
        _speedState = SpeedState.Empty;
        _playerController.Strength = 10f;
        _playerController.horizontalMoveSpeed = 10f;
    }

    IEnumerator speedDown()
    {
        _speedState = SpeedState.SpeedDown;
        hackCD = 15f;
        shotGunCD = 5f;
        rocketCD = 10f;
        yield return new WaitForSeconds(10f);
        _speedState = SpeedState.Empty;
        hackCD = 20f;
        shotGunCD = 10f;
        rocketCD = 15f;
    }
    public enum SpeedState
    {
        Empty,
        SpeedUp,
        SpeedDown
    }
}