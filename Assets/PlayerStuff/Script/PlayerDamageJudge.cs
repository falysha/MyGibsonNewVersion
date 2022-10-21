using System;
using System.Collections;
using System.Collections.Generic;
using Pada1.BBCore.Tasks;
using Platformer.Enemy;
using Platformer.Mechanics;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
public class PlayerDamageJudge : MonoBehaviour
{
    public int damage=0;

    public float time = 0;
    // Start is called before the first frame update
    public void startAttack()
    {
        StartCoroutine(attackLast());
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            var Hit = Schedule<EnemyHitted>();
            Hit.enemyData = col.GetComponent<EnemyData>();
            Hit.playerDamage = damage;
        }
    }



    IEnumerator attackLast()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<Collider2D>().enabled = false;
    }
}