using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageJudge : MonoBehaviour
{
    public int damage=0;

    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startAttack()
    {
        StartCoroutine(attackLast());
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            //减生命值
//            Debug.Log(1);
        }
    }



    IEnumerator attackLast()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<Collider2D>().enabled = false;
    }
}