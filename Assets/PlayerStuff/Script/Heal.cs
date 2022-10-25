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
        public override void Execute()
        {
            PlayerHealth.realHealth = 100;
            SkillController.Fury = 100;
        } 
    }
}