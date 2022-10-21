using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Enemy;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
public class Gunshot : MonoBehaviour
{
    private Vector2 Direction;
    private Vector2 startPoint;
    private GameObject player;
    private PlayerDamageJudge _playerDamageJudge;
    public int damage0 = 10;
    public int damage1 = 20;
    private void Awake()
    {
        player = GameObject.Find("Player");
        startPoint = gameObject.transform.position;
        Direction.x = player.transform.localScale.x;
        Direction.y = 0;
    }
    public void gunShotOnce()
    {
        Direction.x = player.transform.localScale.x;
        startPoint = gameObject.transform.position;
        RaycastHit2D obj = Physics2D.Raycast(startPoint, Direction, 10);
        if (obj.collider)
        {
            GameObject enemy = obj.collider.gameObject;
            if (enemy.CompareTag("Enemy"))
            {
                var Hit = Schedule<EnemyHitted>();
                Hit.enemyData = enemy.GetComponent<EnemyData>();
                Hit.playerDamage = damage0;
            }
        }
    }
    
    public void gunShotlast()
    {
        Direction.x = player.transform.localScale.x;
        startPoint = gameObject.transform.position;
        RaycastHit2D obj = Physics2D.Raycast(startPoint, Direction, 10);
        if (obj.collider)
        {
            GameObject enemy = obj.collider.gameObject;
            if (enemy.CompareTag("Enemy"))
            {
                var Hit = Schedule<EnemyHitted>();
                Hit.enemyData = enemy.GetComponent<EnemyData>();
                Hit.playerDamage = damage1;
            }
        }
    }
}