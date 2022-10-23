using Platformer.Core;
using Platformer.Mechanics;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player performs a Jump.
    /// </summary>
    /// <typeparam name="PlayerJumped"></typeparam>
    public class PlayerHeal : Simulation.Event<PlayerHeal>
    {
        private PlayerHealth _playerHealth=GameObject.Find("Player").GetComponent<PlayerHealth>();
        private SkillController _skillController = GameObject.Find("Player").GetComponent<SkillController>();
        
        public override void Execute()
        {
            _playerHealth.realHealth = 100;
            _skillController.Fury = 100;
        }
    }
}