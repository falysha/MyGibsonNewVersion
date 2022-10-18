using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public bool fired = false;
    private Rigidbody2D _rigidbody2D;
    private GameObject Player;
    private GameObject startPosition;

    private Vector2 Direction;
    // Start is called before the first frame update

    private void Awake()
    {
        Player = GameObject.Find("Player");
        startPosition = GameObject.Find("RocketLaunchStart");
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        Direction.x = Player.transform.localScale.x;
        Direction.y = 0;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (fired)
        {
            _rigidbody2D.velocity = Direction * 10;
        }
        else
        {
            _rigidbody2D.velocity = Vector2.zero;
        }

        distanceCheck();
    }

    void distanceCheck()
    {
        if (Vector2.Distance(gameObject.transform.position, Player.transform.position) > 30)
        {
            fired = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //gameObject.transform.position = startPosition.transform.position;
        }
    }

    public void fireRocket()
    {
        gameObject.transform.position = startPosition.transform.position;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        Direction.x = Player.transform.localScale.x;
        fired = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy" && fired)
        {
            fired = false;
            //爆炸动画
            Debug.Log("Rocket explode");
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.transform.position = Player.transform.position;
        }
    }
}