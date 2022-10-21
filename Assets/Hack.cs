using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Enemy;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
public class Hack : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            var Hit = Schedule<EnemyHitted>();
            Hit.enemyData = col.GetComponent<EnemyData>();
            Hit.playerDamage = 180;
            StartCoroutine(hackLast());
        }
    }

    public void startAttack()
    {
        StartCoroutine(attackLast());
    }

    IEnumerator attackLast()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    IEnumerator hackLast()
    {
        
        yield return new WaitForSeconds(10f);
        //return
    }
}
