using Microsoft.Xna.Framework;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Sounds;
using Sprint0.State;
using System;
using System.Diagnostics;

namespace FirstGame
{
    class TurtleWalkingState : IActionState, IState
    {

        private IEntity Avatar;
        public IEntity Entity {get;set;}
        public Game1 Game { get; set; }
        private IPowerUpState Curpow { get; set; }

        public TurtleWalkingState(Game1 game, IEntity avatar)
        {
            this.Avatar = avatar;

            if (Avatar.FacingRight)
            {
                ((AvatarMain)Avatar).AccelX = .1f;
            }
            else ((AvatarMain)Avatar).AccelX = -.1f;
            Curpow = avatar.CurrentPowerState;
            Game = game;
            Update(null);
        }
        public void Stun()
        {
            Avatar.CurrentActionState = new TurtleStunState(Game, Avatar);
        }
        public void Punch(int type)
        {
            Avatar.CurrentActionState = new TurtlePunchState(Game, Avatar);
        }

        public void GoRight(int type)
        {
            if (!Avatar.FacingRight)
            {
                if (type == 0)
                {
                    Avatar.FacingRight = true;
                    Avatar.CurrentActionState = new TurtleWalkingState(Game, Avatar);
                }
                else 
                {
                    ((AvatarMain)Avatar).AccelX = 0;
                    Avatar.CurrentActionState = new TurtleIdleState(Game, Avatar);
                }
            }
            else
            {
                Avatar.CurrentActionState = new TurtleWalkingState(Game, Avatar);
            }
        }

        public void GoLeft(int type)
        {
            if (Avatar.FacingRight)
            {
                if (type == 0)
                {
                    Avatar.FacingRight = false;
                    Avatar.CurrentActionState = new TurtleWalkingState(Game, Avatar);
                }
                else
                {
                    ((AvatarMain)Avatar).AccelX = 0;
                    Avatar.CurrentActionState = new TurtleIdleState(Game, Avatar);
                }
            }
            else
            {
                Avatar.CurrentActionState = new TurtleWalkingState(Game, Avatar);
            }       
        }


        public void GoDown(int type)
        {
           Avatar.CurrentActionState = new TurtleCrouchState(Game, Avatar);
        }


        public void GoUp(int type)
        {
            if (type != 1)
            {
                Avatar.Velocity = new Vector2(Avatar.Velocity.X, AvatarMain.JUMP_VEL);

                Avatar.CurrentActionState = new TurtleJumpState(Game, Avatar);
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

        public void Update(GameTime time)
        {
            if (!(Avatar.CurrentActionState is TurtleWalkingState) ||!(Avatar.CurrentPowerState == Curpow))
            {
                Curpow = Avatar.CurrentPowerState;
                if (Avatar.CurrentPowerState is DeadMarioPowerUpState)
                {
                    Avatar.CurrentSprite = MarioFactory.GreenDeadKoopa(Game);
                    Avatar.CurrentSprite.Top = new Vector2(Avatar.Position.X, Avatar.Position.Y - 20);
                }
                else if (Avatar.CurrentPowerState is SmallMarioPowerUpState)
                {
                    Avatar.CurrentSprite = MarioFactory.GreenWalkingKoopa(Game);
                }
                else if (Avatar.CurrentPowerState is FireMarioPowerUpState)
                {
                    Avatar.CurrentSprite = MarioFactory.BlueKoopaWalking(Game);
                }
                else if (Avatar.CurrentPowerState is SuperMarioPowerUpState)
                {
                    Avatar.CurrentSprite = MarioFactory.RedWalkingKoopa(Game);
                }
                
            }
        }
    }
}