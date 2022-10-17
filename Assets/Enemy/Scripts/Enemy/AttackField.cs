using UnityEngine;

namespace Platformer.Enemy
{
    public class AttackField : MonoBehaviour
    {
        /// <summary>
        /// If player in this field, the value will be true.
        /// Prompt: Please do not put player in the field when game begin.
        /// </summary>
        public bool isPlayerInAttackField = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("player enter field");
            isPlayerInAttackField = true;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            Debug.Log("player exit field");
            isPlayerInAttackField = false;
        }
    }
}
