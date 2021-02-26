using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.State;
using System;

namespace FirstGame
{
    class TurtleCrouchState : IActionState, IState
    {
        private IEntity Avatar;
        public IEntity Entity { get; set; }


        public Game1 Game { get; set; }

        public TurtleCrouchState(Game1 game,IEntity avatar)
        {
            this.Avatar = avatar;
            ((AvatarMain)Avatar).AccelX = 0;
            this.Entity = avatar;
            Game = game;
            Avatar.Position = new Vector2(avatar.Position.X, avatar.Position.Y + 10);
            Update(null);       
        }

        public void Punch(int type)
        {
        }

        public void GoRight(int type)
        {
            if (!Avatar.FacingRight && type ==0)
            {
                Avatar.FacingRight = true;
               // Avatar.Position = new Vector2(Avatar.Position.X, Avatar.Position.Y);
            }
        }
        public void GoLeft(int type)
        {
            if (Avatar.FacingRight && type == 0)
            {
                Avatar.FacingRight = false;
                //Avatar.Position = new Vector2(Avatar.Position.X, Avatar.Position.Y);
            }
        }

        public void GoDown(int type) {}

        public void GoUp(int type)
        {
            if (Math.Abs(Avatar.Velocity.X) == 1)
            {
                Avatar.CurrentActionState = new TurtleWalkingState(Game, Avatar);
            }
            else
            {
                Avatar.CurrentActionState = new TurtleIdleState(Game, Avatar);
            }
            Avatar.Position = new Vector2(Avatar.Position.X, Avatar.Position.Y - 9);

        }
        public void Stun()
        {
            Avatar.CurrentActionState = new TurtleStunState(Game, Avatar);
        }

        public void Update(GameTime time)
        {
           
            if (Avatar.CurrentPowerState is DeadMarioPowerUpState)
            {
                Avatar.CurrentSprite = MarioFactory.GreenDeadKoopa(Game);
                Avatar.CurrentSprite.Top = new Vector2(Avatar.Position.X, Avatar.Position.Y - 20);
            }

            if (Avatar.CurrentPowerState is FireMarioPowerUpState)
            {
                Avatar.CurrentSprite = MarioFactory.BlueCrouchingKoopa(Game);

            }
            else if (Avatar.CurrentPowerState is SuperMarioPowerUpState)
            {
                Avatar.CurrentSprite = MarioFactory.RedCrouchingKoopa(Game);
            }
            else
            {
                Avatar.CurrentSprite = MarioFactory.GreenCrouchingKoopa(Game);
            }
            
        }
    }
}
