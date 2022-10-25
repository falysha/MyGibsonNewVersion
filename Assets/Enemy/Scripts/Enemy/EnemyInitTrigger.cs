using Platformer.Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Enemy
{
    public class EnemyInitTrigger : MonoBehaviour
    {
        public GameObject attackField;

        public EnemySet[] enemySets;

        private void OnTriggerEnter2D(Collider2D player)
        {
            if (player.gameObject.tag == "Player")
            {
                for(int i = 0; i < enemySets.Length; i++)
                {
                    GameObject enemy = (GameObject)Instantiate(Resources.Load("Enemys/" + enemySets[i].enemyType));
                    enemy.transform.parent = transform.parent;
                    enemy.transform.position = enemySets[i].initPos;
                    enemy.GetComponent<EnemyData>().attackField = attackField;
                    enemy.GetComponent<EnemyData>().leftPos = enemySets[i].leftPos;
                    enemy.GetComponent<EnemyData>().rightPos = enemySets[i].rightPos;
                }
                Destroy(gameObject);
            }
        }

        [System.Serializable]
        public class EnemySet
        {
            public string enemyType;

            public Vector3 initPos;

            public float leftPos;

            public float rightPos;
        }
    }
}
