using Platformer.Core;
using Platformer.Mechanics;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player performs a Jump.
    /// </summary>
    /// <typeparam name="PlayerJumped"></typeparam>
    public class PlayerHitted : Simulation.Event<PlayerHitted>
    {
        public GameObject player=GameObject.Find("Player");
        public Transform enemyTransform;
        public int damage = 0;
        
        public override void Execute()
        {
            if (!player.GetComponent<PlayerHealth>().locked)
            {
                player.GetComponent<PlayerHealth>().realHealth = player.GetComponent<PlayerHealth>().realHealth - damage;
            }
            player.GetComponent<Animator>().SetTrigger("hitted");
            if (enemyTransform.position.x>=player.GetComponent<Transform>().position.x)
            {
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.left*2,ForceMode2D.Impulse);
                player.GetComponent<Animator>().SetLayerWeight(2, 1); //right
                player.GetComponent<Animator>().SetLayerWeight(1, 0); //left
                player.transform.localScale=Vector3.one;
            }
            else
            {
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.right*2,ForceMode2D.Impulse);
                player.GetComponent<Animator>().SetLayerWeight(1, 1);
                player.GetComponent<Animator>().SetLayerWeight(2, 0);
                player.transform.localScale=Vector3.one+Vector3.left*2;
            }
        }
    }
}