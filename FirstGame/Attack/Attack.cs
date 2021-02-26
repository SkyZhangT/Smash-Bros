using FirstGame;
using Sprint0.Game_Enities.Avatar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Attack
{
    /* Main class for handling attack (moreso damage) logistics */

        /* How the damage system works
         * 
         * Damage is calculated partly in this class
         * 
         * The amount of damage a player receives is dependent upon the hit player's small/super state, the attacking player's small/super state, and the type of attack performed
         * 
         * If the attacking player is small mario, the attack does half the BaseDamge value to the other player
         * On top of this, if the attacked player is small mario, they receive DOUBLE the value calculated above
         * 
         * As an example, if a small player attacks another small player, the amount of damage done to the attacked player would be equal to BaseDamage
         */
    
        /* A few notes on this class
         * 
         * 1. Currently, this attack system is set up so that it's not tied to a specific implemention of attack collision detection
         *     - This class could easily be modified to be a collidable object. In that case, everything related to attacks would be handled in here
         * 2. MarioAvatar has a method called ReceiveAttack, where the rest of the damage calculations are handled
         * 3. After ReceiveAttack, the avatar calls launch, which is the actual physics response to an attack
         */
    public class Attack
    {
        public MarioAvatar AttackingPlayer { get; set; }
        public float BaseDamage { get; set; }


        public Attack(MarioAvatar attacker, float baseDamage)
        {
            this.BaseDamage = baseDamage;
            this.AttackingPlayer = attacker;
        }

        public float CalcImpactDamage()
        {
            if (AttackingPlayer.CurrentPowerState is SmallMarioPowerUpState)
            {
                return BaseDamage / 2;
            }
            else return BaseDamage;
        }
    }
}
