using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.State;
using System;

namespace FirstGame
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses")]



    class DeadState : IActionState, IState
    {

        private IEntity Avatar;
        public IEntity Entity { get; set; }
        public Game1 Game { get; set; }

        public DeadState(Game1 game, IEntity avatar)
        {
            this.Avatar = avatar;
            Avatar.HitBox = new Rectangle(0, 0,0,0);
            Game = game;
            
            Avatar.CurrentSprite = AvatarFactory.DeadAvatarFactory(Game, Avatar.Name);
           ((AvatarMain)Avatar).PhysicsEnabled = false;
        }
        public void Punch(int type)
        {

        }
        public void Stun()
        {
            Avatar.CurrentActionState = new StunState(Game, Avatar);
        }
        public void GoRight(int type)
        {


        }

        public void GoLeft(int type)
        {

        }


        public void GoDown(int type)
        {

        }


        public void GoUp(int type)
        {

        }

        public void Update(GameTime time)
        {

        }
    }
}
