using Microsoft.Xna.Framework;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Sounds;
using Sprint0.State;
using System;

namespace FirstGame
{
    class IdleState : IActionState, IState
    {

        private IEntity Avatar;
        public IEntity Entity { get; set; }
        public Game1 Game { get; set; }

        public IdleState(Game1 game, IEntity avatar)
        {
            this.Avatar = avatar;
            ((AvatarMain)Avatar).AccelX = 0;
            Game = game;
            this.Update(null);  
        }
        public void Stun()
        {
            Avatar.CurrentActionState = new StunState(Game, Avatar);
        }
        public void Punch(int type)
        {
            Avatar.CurrentActionState = new PunchState(Game, Avatar);
        }

        public void GoRight(int type)
        {

            if (type == 0)
            {
                if (!Avatar.FacingRight)
                {
                    Avatar.FacingRight = true;
                    Avatar.CurrentActionState = new WalkingState(Game, Avatar);
                }
                else
                {
                    Avatar.CurrentActionState = new WalkingState(Game, Avatar);
                }
            }
        }

        public void GoLeft(int type)
        {
            if (type == 0)
            {
                if (Avatar.FacingRight)
                {

                    Avatar.FacingRight = false;
                    Avatar.CurrentActionState = new WalkingState(Game, Avatar);
                }
                else
                {
                    Avatar.CurrentActionState = new WalkingState(Game, Avatar);
                }
            }    
        }

        public void GoDown(int type)
        {
            if (type != 1)
            {
                if (!(Avatar.CurrentPowerState is SmallMarioPowerUpState))
                {
                    Avatar.Position = new Vector2(Avatar.Position.X, Avatar.Position.Y + 12);
                }
                Avatar.CurrentActionState = new CrouchState(Game, Avatar);
            }
        }

        public void GoUp(int type)
        {
            if (type != 1)
            {
                Avatar.Velocity = new Vector2(Avatar.Velocity.X, AvatarMain.JUMP_VEL);
                if (Avatar.Velocity.Y == 0)
                {
                    Avatar.CurrentActionState = new IdleState(Game, Avatar);
                }
                else
                {
                    Avatar.CurrentActionState = new JumpState(Game, Avatar,true);
                    if (Avatar.CurrentPowerState is SmallMarioPowerUpState)
                    {
                        SoundManager.PlaySound("jump");
                    }
                    else
                    {
                        SoundManager.PlaySound("jump-super");
                    }
                }
            }         
        }

        public void Update(GameTime time)
        {
            if (Avatar.CurrentPowerState is DeadMarioPowerUpState)
            {
                Avatar.CurrentSprite = AvatarFactory.DeadAvatarFactory(Game, Avatar.Name);
                Avatar.CurrentSprite.Top = new Vector2(Avatar.Position.X, Avatar.Position.Y - 20);
            }
            else if (Avatar.CurrentPowerState is SmallMarioPowerUpState && !Avatar.FacingRight)
            {
                Avatar.CurrentSprite = AvatarFactory.SmallAvatarFacingLeftFactory(Game, Avatar.Name);
            }
            else if (Avatar.CurrentPowerState is SmallMarioPowerUpState)
            {
                Avatar.CurrentSprite = AvatarFactory.SmallAvatarFacingRightFactory(Game, Avatar.Name);
            }
            else if (Avatar.CurrentPowerState is SuperMarioPowerUpState && !Avatar.FacingRight)
            {
                Avatar.CurrentSprite = AvatarFactory.SuperAvatarFacingLeftFactory(Game, Avatar.Name);
            }
            else if (Avatar.CurrentPowerState is SuperMarioPowerUpState)
            {
                Avatar.CurrentSprite = AvatarFactory.SuperAvatarFacingRightFactory(Game, Avatar.Name);
            }
            else if (Avatar.CurrentPowerState is FireMarioPowerUpState && !Avatar.FacingRight)
            {
                Avatar.CurrentSprite = AvatarFactory.FireAvatarFacingLeftFactory(Game, Avatar.Name);
            }
            else if (Avatar.CurrentPowerState is FireMarioPowerUpState)
            {
                Avatar.CurrentSprite = AvatarFactory.FireAvatarFacingLeftFactory(Game, Avatar.Name);
            }
        }
    }
}
