using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Sounds;
using Sprint0.State;
using System;

namespace FirstGame
{
    class PunchState : IActionState, IState
    {
        private IEntity Avatar;
        public IEntity Entity { get; set; }
        
        public Game1 Game { get; set; }

        private int punchTime;
        private int punchStateADuration = 10;
        private int punchDuration = 20;


        public PunchState(Game1 game, IEntity avatar)
        {
            this.Avatar = avatar;
            Avatar.Indicator = Color.White;

            this.punchTime = 0;
            Game = game;
            Update(null);
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

            this.punchTime++;
            if(this.punchTime > this.punchDuration)
            {
                if(this.Avatar.Velocity.Y != 0)
                {
                    Avatar.CurrentActionState = new JumpState(Game, Avatar,false);
                }
                else
                {
                    Avatar.CurrentActionState = new IdleState(Game, Avatar);
                }
            }
            else
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
                        if (this.punchTime < this.punchStateADuration)
                        {
                            Avatar.CurrentSprite = AvatarFactory.SuperAvatarPunchingLeftFactory(Game, Avatar.Name);
                        }
                        else
                        {
                            Avatar.CurrentSprite = AvatarFactory.SuperAvatarPunchingLeftBFactory(Game, Avatar.Name);
                        }
                        
                    }
                    else if (Avatar.CurrentPowerState is FireMarioPowerUpState)
                    {
                        if (this.punchTime < this.punchStateADuration)
                        {
                            Avatar.CurrentSprite = AvatarFactory.FireAvatarPunchingLeftFactory(Game, Avatar.Name);
                        }
                        else
                        {
                            Avatar.CurrentSprite = AvatarFactory.FireAvatarPunchingLeftBFactory(Game, Avatar.Name);
                        }
                    }
                    /*
                    else if (Avatar.CurrentPowerState is SmallMarioPowerUpState)
                    {
                        Avatar.CurrentSprite = MarioFactory.SmallMarioJumpingLeftFactory(Game);
                    }
                    */
                }
                else
                {
                    if (Avatar.CurrentPowerState is SuperMarioPowerUpState)
                    {
                        if (this.punchTime < this.punchStateADuration)
                        {
                            Avatar.CurrentSprite = AvatarFactory.SuperAvatarPunchingRightFactory(Game, Avatar.Name);
                        }
                        else
                        {
                            Avatar.CurrentSprite = AvatarFactory.SuperAvatarPunchingRightBFactory(Game, Avatar.Name);
                        }
                        
                    }
                    else if (Avatar.CurrentPowerState is FireMarioPowerUpState)
                    {
                        if (this.punchTime < this.punchStateADuration)
                        {
                            Avatar.CurrentSprite = AvatarFactory.FireAvatarPunchingRightFactory(Game, Avatar.Name);
                        }
                        else
                        {
                            Avatar.CurrentSprite = AvatarFactory.FireAvatarPunchingRightBFactory(Game, Avatar.Name);
                        }
                    }
                    /*
                    else if (Avatar.CurrentPowerState is SmallMarioPowerUpState)
                    {
                        Avatar.CurrentSprite = MarioFactory.SmallMarioJumpingRightFactory(Game);
                    }
                    */
                }
            }
            
        }
    }
}
