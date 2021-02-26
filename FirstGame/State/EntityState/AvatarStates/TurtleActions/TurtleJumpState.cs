using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Sounds;
using Sprint0.State;
using System;

namespace FirstGame
{
    class TurtleJumpState : IActionState, IState
    {
        private readonly float JUMP_ACCEL_FACING = AvatarMain.JUMP_ACCEL_FACING;
        private readonly float JUMP_ACCEL_NOT_FACING = AvatarMain.JUMP_ACCEL_NOT_FACING;
        private IEntity Avatar;
        public IEntity Entity { get; set; }
        private IPowerUpState Curpow { get; set; }

        public Game1 Game { get; set; }
        private bool doubleJump = true;

        public TurtleJumpState(Game1 game, IEntity avatar)
        {
            this.Avatar = avatar;
            Avatar.Indicator = Color.White;
            Curpow = avatar.CurrentPowerState;
            if (((AvatarMain)Avatar).AccelX.CompareTo(0) != 0)
            {
                if (Avatar.FacingRight)
                {
                    ((AvatarMain)Avatar).AccelX = JUMP_ACCEL_FACING;

                }
                else
                {
                    ((AvatarMain)Avatar).AccelX = -JUMP_ACCEL_FACING;
                }
            }

            Game = game;
            Update(null);
        }

        public void Punch(int type)
        {
                Avatar.CurrentActionState = new TurtlePunchState(Game, Avatar);
        }
        public void Stun()
        {
            Avatar.CurrentActionState = new TurtleStunState(Game, Avatar);
        }

        public void GoRight(int type)
        {
            if (type == 0)
            {
                if (Avatar.FacingRight)
                {
                    ((AvatarMain)Avatar).AccelX = JUMP_ACCEL_FACING;

                }
                else
                {
                    ((AvatarMain)Avatar).AccelX = JUMP_ACCEL_NOT_FACING;

                }
            }
            else if (type == 1)
            {
                ((AvatarMain)Avatar).AccelX = 0;
            }
            else
            {
                Avatar.Velocity = new Vector2(0, Avatar.Velocity.Y);
            }
        }
        public void GoLeft(int type)
        {
            if (type ==0)
            {
                if (Avatar.FacingRight)
                {
                    ((AvatarMain)Avatar).AccelX = -JUMP_ACCEL_NOT_FACING;

                }
                else
                {
                    ((AvatarMain)Avatar).AccelX = -JUMP_ACCEL_FACING;

                }
            }
            else if (type == 1)
            {
                ((AvatarMain)Avatar).AccelX = 0;
            }
            else
            {
                Avatar.Velocity = new Vector2(0, Avatar.Velocity.Y);
            }
        }

        public void GoDown(int type)
        {
            if (type != 0)
            {
                if (type == 1 && Avatar.Velocity.Y<0)
                {
                    ((AvatarMain)Avatar).Velocity = new Vector2(((AvatarMain)Avatar).Velocity.X, ((AvatarMain)Avatar).Velocity.Y / 1.5f);
                }
                else if (type == 2)
                {
                    Avatar.Indicator = Color.White;
                    if (Avatar.FacingRight)
                    {
                        if (((AvatarMain)Avatar).AccelX.CompareTo(-JUMP_ACCEL_NOT_FACING) == 0)
                        {
                            Avatar.FacingRight = false;
                            Avatar.CurrentActionState = new TurtleWalkingState(Game, Avatar);
                        }
                        else if (((AvatarMain)Avatar).AccelX.CompareTo(JUMP_ACCEL_FACING) == 0)
                        {
                            Avatar.CurrentActionState = new TurtleWalkingState(Game, Avatar);
                        }
                        else if (((AvatarMain)Avatar).AccelX.CompareTo(0) == 0)
                        {
                            Avatar.CurrentActionState = new TurtleIdleState(Game, Avatar);
                        }
                    }
                    else
                    {
                        if (((AvatarMain)Avatar).AccelX.CompareTo(JUMP_ACCEL_NOT_FACING) == 0)
                        {
                            Avatar.FacingRight = true;
                            Avatar.CurrentActionState = new TurtleWalkingState(Game, Avatar);
                        }
                        else if (((AvatarMain)Avatar).AccelX.CompareTo(-JUMP_ACCEL_FACING) == 0)
                        {
                            Avatar.CurrentActionState = new TurtleWalkingState(Game, Avatar);
                        }
                        else if (((AvatarMain)Avatar).AccelX.CompareTo(0) == 0)
                        {
                            Avatar.CurrentActionState = new TurtleIdleState(Game, Avatar);
                        }
                    }
                }
            }
            
        }

        public void GoUp(int type)
        {
            if(type == 0 && doubleJump)
            {
                this.doubleJump = false;
                Avatar.Velocity = new Vector2(Avatar.Velocity.X, AvatarMain.JUMP_VEL/1.5f);
                Avatar.Indicator = Color.Gray;
                if (Avatar.Velocity.Y == 0)
                {
                    Avatar.CurrentActionState = new TurtleIdleState(Game, Avatar);
                }
                else
                {
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
                Avatar.CurrentSprite = MarioFactory.GreenDeadKoopa(Game);
                Avatar.CurrentSprite.Top = new Vector2(Avatar.Position.X, Avatar.Position.Y - 20);
            }
            if (!(Avatar.CurrentActionState is TurtleJumpState) || !(Avatar.CurrentPowerState == Curpow))
            {
                Curpow = Avatar.CurrentPowerState;
                if (Avatar.CurrentPowerState is FireMarioPowerUpState)
                {
                    Avatar.CurrentSprite = MarioFactory.BlueJumpingKoopa(Game);
                }
                else if (Avatar.CurrentPowerState is SuperMarioPowerUpState)
                {
                    Avatar.CurrentSprite = MarioFactory.RedJumpingKoopa(Game);
                }
                else if (Avatar.CurrentPowerState is SmallMarioPowerUpState)
                {
                    Avatar.CurrentSprite = MarioFactory.GreenJumpingKoopa(Game);
                }
            }
            
            
        }
    }
}
