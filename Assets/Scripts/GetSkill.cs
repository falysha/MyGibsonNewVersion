using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSkill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameManager.instance.haveskill = true;
        Destroy(gameObject);
    }
}
