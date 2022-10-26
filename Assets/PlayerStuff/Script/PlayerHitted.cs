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
        public GameObject player ;
        public Transform enemyTransform;
        public int damage = 0;

        public override void Execute()
        {
            // Debug.Log(damage);
            if (!player.GetComponent<PlayerHealth>().locked)
            {
                PlayerHealth.realHealth = PlayerHealth.realHealth - damage;
            }

            if (!player.GetComponent<PlayerController>().Stoic)
            {
                player.GetComponent<Animator>().SetTrigger("hitted");
                if (enemyTransform.position.x >= player.GetComponent<Transform>().position.x)
                {
                    player.GetComponent<Cinemachine.CinemachineCollisionImpulseSource>()
                        .GenerateImpulse(Vector2.up * 0.2f);
                    player.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 2, ForceMode2D.Impulse);
                    player.GetComponent<Animator>().SetLayerWeight(2, 1); //right
                    player.GetComponent<Animator>().SetLayerWeight(1, 0); //left
                    player.transform.localScale = Vector3.one;
                }
                else
                {
                    player.GetComponent<Cinemachine.CinemachineCollisionImpulseSource>()
                        .GenerateImpulse(Vector2.up * 0.2f);
                    player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 2, ForceMode2D.Impulse);
                    player.GetComponent<Animator>().SetLayerWeight(1, 1);
                    player.GetComponent<Animator>().SetLayerWeight(2, 0);
                    player.transform.localScale = Vector3.one + Vector3.left * 2;
                }
            }
        }
    }
}