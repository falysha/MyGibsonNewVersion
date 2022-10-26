using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class TimeCounter : MonoBehaviour
{
    private float atc0 = 0.41625f;
    private float atc1 = 0.52125f;
    private float atc2 = 0.52125f;
    private float atc3 = 0.3125f;
    private float atc4 = 0.625f;

    private float rocket = 0.71428f;
    private float smash = 0.666f;
    private float shotGun = 0.83285f;
    
    private Vector2 Direction;
    private Rigidbody2D _rigidbody2D;
    public PlayerController _PlayerController;
    private AudioSource _audioSource;
    
    private Gunfire[] gunFires;
    private Gunshot gunShot;
    private GameObject Leg0;
    private GameObject Leg1;
    private GameObject _rocket;
    private GameObject _smash;
    private GameObject shotgun;
    
    public bool atcing0 = false;
    public bool atcing1 = false;
    public bool atcing2 = false;
    public bool atcing3 = false;
    
    private AudioClip doubleGunSound;
    private AudioClip gunSound;
    private AudioClip leg0;
    private AudioClip leg1;
    private AudioClip rocketSound;
    private AudioClip smashSound;
    private AudioClip shotGunSound;
    
    
    private VolumeProfile hackVolume;
    private VolumeProfile defaultVolumeProfile;
    private Volume _volume;

    private void Awake()
    {
        _PlayerController = gameObject.GetComponent<PlayerController>();
        
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();

        gunFires = FindObjectsOfType<Gunfire>();

        gunShot = FindObjectOfType<Gunshot>();

        Leg0 = GameObject.Find("Leg0");

        Leg1 = GameObject.Find("Leg1");
    
        _rocket = GameObject.Find("Rocket");
        
        _smash = GameObject.Find("Smash");
        
        shotgun = GameObject.Find("Shotgun");
        
        Direction.y = 0;

        _audioSource=gameObject.GetComponent<AudioSource>();

        doubleGunSound= Resources.Load<AudioClip>("Sounds/doubleGun");
        
        gunSound = Resources.Load<AudioClip>("Sounds/gun");

        rocketSound = Resources.Load<AudioClip>("Sounds/rocket");

        smashSound = Resources.Load<AudioClip>("Sounds/smash");

        shotGunSound = Resources.Load<AudioClip>("Sounds/shotgun");
        
        leg0 = Resources.Load<AudioClip>("Sounds/leg0");
        
        leg1 = Resources.Load<AudioClip>("Sounds/leg1");

    }
    
    void Update()
    {
        Direction.x = gameObject.transform.localScale.x;
    }
    public void startAttack0()
    {
        StartCoroutine(attack0());
    }

    public void startAttack1()
    {
        StartCoroutine(attack1());
    }

    public void startAttack2()
    {
        StartCoroutine(attack2());
    }

    public void startAttack3()
    {
        StartCoroutine(attack3());
    }

    public void startAttack4()
    {
        StartCoroutine(attack4());
    }

    public void startRocket()
    {
        StartCoroutine(Rocket());
    }

    public void startSmash()
    {
        StartCoroutine(Smash());
    }
    
    public void starShotGun()
    {
        StartCoroutine(ShotGun());
    } 
    IEnumerator attack0()
    {
        _audioSource.PlayOneShot(gunSound);
        gunShot.gunShotOnce();
        gunFires[5].gunFire();
        _rigidbody2D.AddForce(Direction * 4, ForceMode2D.Impulse);
        yield return new WaitForSeconds(atc0 * 0.75f);
        if (atcing0)
        {
            _audioSource.PlayOneShot(gunSound);
            gunShot.gunShotOnce();
            gunFires[4].gunFire();
        }
    }

    IEnumerator attack1()
    {
        yield return new WaitForSeconds(atc1 * 0.6f);
        if (atcing1)
        {
            _audioSource.PlayOneShot(gunSound);
            gunShot.gunShotOnce();
            gunFires[3].gunFire();
        }

        yield return new WaitForSeconds(atc0 * 0.2f);
        if (atcing1)
        {
            _audioSource.PlayOneShot(gunSound);
            gunShot.gunShotOnce();
            gunFires[2].gunFire();
        }
    }

    IEnumerator attack2()
    {
        yield return new WaitForSeconds(atc2 * 0.3f);
        if (atcing2)
        {
            _rigidbody2D.AddForce(Direction * 2, ForceMode2D.Impulse);
            _audioSource.PlayOneShot(leg0);
            Leg0.GetComponent<PlayerDamageJudge>().startAttack();
        }
    }

    IEnumerator attack3()
    {
        yield return new WaitForSeconds(atc3 * 0.333f);
        if (atcing3)
        {
            _audioSource.PlayOneShot(leg1);
            _rigidbody2D.AddForce(Direction * 2, ForceMode2D.Impulse);
            Leg1.GetComponent<PlayerDamageJudge>().startAttack();
        }
    }

    IEnumerator attack4()
    {
        yield return new WaitForSeconds(atc4 * 0.833f);
        _audioSource.pitch = 1.6f;
        _audioSource.PlayOneShot(doubleGunSound);
        FindObjectOfType<Gunshot>().gunShotlast();
        FindObjectOfType<Gunshot>().gunShotlast();
        gunFires[1].gunFire();
        gunFires[0].gunFire();
        gameObject.GetComponent<Cinemachine.CinemachineCollisionImpulseSource>().GenerateImpulse(Vector2.up*0.2f);
        _rigidbody2D.AddForce(-Direction * 7, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.1f);
        _audioSource.pitch = 0.8f;
    }

    IEnumerator Rocket()
    {
        _rocket.GetComponent<RocketFire>().rocketFire();
        _audioSource.pitch = 1.2f;
        _audioSource.PlayOneShot(rocketSound);
        yield return new WaitForSeconds(rocket * 0.666f);
        gameObject.GetComponent<Cinemachine.CinemachineCollisionImpulseSource>().GenerateImpulse(Vector2.up*0.2f);
        _rigidbody2D.AddForce(-Direction*7,ForceMode2D.Impulse);
        _rocket.GetComponent<PlayerDamageJudge>().startAttack();
        _audioSource.pitch = 0.8f;
    }

    IEnumerator Smash()
    {
        yield return new WaitForSeconds(smash * 0.5f);
        _audioSource.pitch = 1f;
        _smash.GetComponent<BoxCollider2D>().enabled = true;
        _audioSource.PlayOneShot(smashSound);
        _rigidbody2D.AddForce(Direction*12,ForceMode2D.Impulse);
        gameObject.GetComponent<Cinemachine.CinemachineCollisionImpulseSource>().GenerateImpulse(Vector2.up*0.2f);
        _smash.GetComponent<SmashFire>().smashFire();
        _smash.GetComponent<PlayerDamageJudge>().startAttack();
        yield return new WaitForSeconds(smash * 0.5f);
        _smash.GetComponent<BoxCollider2D>().enabled = false;
    }

    IEnumerator ShotGun()
    {
        yield return new WaitForSeconds(shotGun * 0.857f);
        _audioSource.pitch = 0.8f;
        _audioSource.PlayOneShot(shotGunSound);
        _PlayerController.canControl = false;
        _rigidbody2D.AddForce(-Direction*9,ForceMode2D.Impulse);
        gameObject.GetComponent<Cinemachine.CinemachineCollisionImpulseSource>().GenerateImpulse(Vector2.up*0.2f);
        shotgun.GetComponent<ShotGunFire>().shotGunFire();
        shotgun.GetComponent<PlayerDamageJudge>().startAttack();
    }
}