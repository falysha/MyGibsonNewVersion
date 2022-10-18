using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunshot : MonoBehaviour
{
    public Vector2 Direction;
    public Vector2 startPoint;

    public GameObject player;

    // Start is called before the first frame update
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
        if (obj.collider != null)
        {
            GameObject enemy = obj.collider.gameObject;
            if (enemy.CompareTag("Enemy"))
            {
                Debug.Log("HIT!");
            }
        }
    }
}