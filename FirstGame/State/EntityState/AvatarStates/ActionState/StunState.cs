using Microsoft.Xna.Framework;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Sounds;
using Sprint0.State;
using System;

namespace FirstGame
{
    class StunState : IActionState, IState
    {

        private IEntity Avatar;
        public IEntity Entity { get; set; }
        public Game1 Game { get; set; }
        private int TimeDelay { get; set; }
        public StunState(Game1 game, IEntity avatar)
        {
            this.Avatar = avatar;
            ((MarioAvatar)Avatar).AccelX = 0;
            Game = game;
            TimeDelay = 0;
        }

        public void Punch(int type)
        {

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
            if (time != null)
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
                Avatar.Indicator = Color.YellowGreen;

                TimeDelay += time.ElapsedGameTime.Milliseconds;
                if (TimeDelay > 1000)
                {
                    TimeDelay = 0;
                    Avatar.CurrentActionState = new IdleState(Game, Avatar);
                    Avatar.Indicator = Color.White;
                }
            }
        }
        public void Stun()
        {
            Avatar.CurrentActionState = new StunState(Game, Avatar);
        }
    }
}
