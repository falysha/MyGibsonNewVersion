using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
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
    private Volume _volume;
    private VolumeProfile speedUpVolume;
    private VolumeProfile speedDownVolume;
    private VolumeProfile defaultVolumeProfile;
    private Shadow _shadow;
    // Start is called before the first frame update

    private void Awake()
    {
        countedHackCD = 20f;
        countedShotGunCD = 10f;
        countedRocketCD = 15f;
        _playerController = FindObjectOfType<PlayerController>();
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _volume = GameObject.Find("Global Volume").GetComponent<Volume>();
        speedUpVolume = Resources.Load<VolumeProfile>("CameraStuff/SpeedUp");
        speedDownVolume = Resources.Load<VolumeProfile>("CameraStuff/SpeedDown");
        _shadow = FindObjectOfType<Shadow>();
        defaultVolumeProfile = _volume.profile;
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
        if (_speedState == SpeedState.Empty)
        {
            if (Fury < 20)
            {
                if (_playerHealth.realHealth > 20)
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
        if (_speedState == SpeedState.Empty)
        {
            if (Fury < 20)
            {
                if (_playerHealth.realHealth > 20)
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
        _shadow.startShadow();
        _volume.profile = speedUpVolume;
        _speedState = SpeedState.SpeedUp;
        _playerController.horizontalMoveSpeed = 20f;
        _playerController.Strength = 15f;
        EnemyHitted.ratio = 1.5f;
        //攻击提升代码
        yield return new WaitForSeconds(10f);
        EnemyHitted.ratio = 1f;
        _shadow.closeShadow();
        _volume.profile = defaultVolumeProfile;
        _speedState = SpeedState.Empty;
        _playerController.Strength = 10f;
        _playerController.horizontalMoveSpeed = 10f;
    }

    IEnumerator speedDown()
    {
        _volume.profile = speedDownVolume;
        _speedState = SpeedState.SpeedDown;
        hackCD = 15f;
        shotGunCD = 5f;
        rocketCD = 10f;
        _playerHealth.locked = true;
        yield return new WaitForSeconds(10f);
        _playerHealth.locked = false;
        _volume.profile = defaultVolumeProfile;
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