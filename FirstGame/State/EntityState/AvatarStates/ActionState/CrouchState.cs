using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.State;
using System;

namespace FirstGame
{
    class CrouchState : IActionState, IState
    {
        private IEntity Avatar;
        public IEntity Entity { get; set; }


        public Game1 Game { get; set; }

        public CrouchState(Game1 game,IEntity avatar)
        {
            this.Avatar = avatar;
            ((AvatarMain)Avatar).AccelX = 0;
            this.Entity = avatar;
          //  if (!(Avatar.CurrentPowerState is SmallMarioPowerUpState))
          //  {
           //     Avatar.Position = new Vector2(Avatar.Position.X, Avatar.Position.Y);
           // }
            Game = game;
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
            Avatar.CurrentActionState = new CrouchState(Game, Avatar);
        }
        public void GoLeft(int type)
        {
            if (Avatar.FacingRight && type == 0)
            {
                Avatar.FacingRight = false;
                //Avatar.Position = new Vector2(Avatar.Position.X, Avatar.Position.Y);
            }
            Avatar.CurrentActionState = new CrouchState(Game, Avatar);
        }

        public void GoDown(int type) {}

        public void GoUp(int type)
        {
            if (!(Avatar.CurrentPowerState is SmallMarioPowerUpState))
            {
                Avatar.Position = new Vector2(Avatar.Position.X, Avatar.Position.Y - 12);
            }

            if (Math.Abs(Avatar.Velocity.X) == 1)
            {
                Avatar.CurrentActionState = new WalkingState(Game, Avatar);
            }
            else
            {
                Avatar.CurrentActionState = new IdleState(Game, Avatar);
            }
        }
        public void Stun()
        {
            Avatar.CurrentActionState = new StunState(Game, Avatar);
        }

        public void Update(GameTime time)
        {
           
            if (Avatar.CurrentPowerState is DeadMarioPowerUpState)
            {
                Avatar.CurrentSprite = AvatarFactory.DeadAvatarFactory(Game, Avatar.Name);
                Avatar.CurrentSprite.Top = new Vector2(Avatar.Position.X, Avatar.Position.Y - 20);
            }
            if (!Avatar.FacingRight)
            {
                if (Avatar.CurrentPowerState is SuperMarioPowerUpState)
                {
                    Avatar.CurrentSprite = AvatarFactory.SuperAvatarCrouchLeftFactory(Game, Avatar.Name);

                }
                else if (Avatar.CurrentPowerState is FireMarioPowerUpState)
                {
                    Avatar.CurrentSprite = AvatarFactory.FireAvatarCrouchLeftFactory(Game, Avatar.Name);
                }
                else
                {
                    Avatar.CurrentSprite = AvatarFactory.SmallAvatarFacingLeftFactory(Game, Avatar.Name);
                }
            }
            else
            {
                if (Avatar.CurrentPowerState is SuperMarioPowerUpState)
                {
                    Avatar.CurrentSprite = AvatarFactory.SuperAvatarCrouchRightFactory(Game, Avatar.Name);
                }
                else if (Avatar.CurrentPowerState is FireMarioPowerUpState)
                {
                    Avatar.CurrentSprite = AvatarFactory.FireAvatarCrouchRightFactory(Game, Avatar.Name);
                }
                else
                {
                    Avatar.CurrentSprite = AvatarFactory.SmallAvatarFacingRightFactory(Game, Avatar.Name);
                }
            }
        }
    }
}
