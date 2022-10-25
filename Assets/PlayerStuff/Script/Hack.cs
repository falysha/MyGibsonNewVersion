using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Buff;
using UnityEngine;
using Platformer.Enemy;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using UnityEngine.Rendering;
public class Hack : MonoBehaviour
{
    private VolumeProfile hackVolume;
    private VolumeProfile defaultVolumeProfile;
    private Volume _volume;
    private AudioClip hackSound;
    private AudioSource _audioSource;
    private void Awake()
    {
        _volume = GameObject.Find("Global Volume").GetComponent<Volume>();
        
        defaultVolumeProfile = _volume.profile;
        
        hackVolume = Resources.Load<VolumeProfile>("CameraStuff/Hack");
        
        hackSound  = Resources.Load<AudioClip>("Sounds/Hacker");
        
        _audioSource=gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            var Hit = Schedule<EnemyHitted>();
            Hit.enemyData = col.GetComponent<EnemyData>();
            Hit.playerDamage = 180;
            BuffControl enemyBuffControl = col.GetComponent<BuffControl>();
            enemyBuffControl.AddBuff(new CodeChaosBuff(enemyBuffControl, BuffKind.CodeChaos, 10f));
        }
    }

    public void startAttack()
    {
        StartCoroutine(volumeSwitch());
        StartCoroutine(attackLast());
    }

    IEnumerator attackLast()
    {
        _audioSource.PlayOneShot(hackSound);
        gameObject.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    IEnumerator volumeSwitch()
    {
        _volume.profile = hackVolume;
        yield return new WaitForSeconds(10f);
        _volume.profile = defaultVolumeProfile;
    }
    
}
