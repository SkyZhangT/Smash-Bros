using Microsoft.Xna.Framework;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Sounds;
using Sprint0.State;
using System;

namespace FirstGame
{
    class FireBallThrow : IActionState, IState
    {

        private IEntity Avatar;
        public IEntity Entity { get; set; }
        private int Elapse = 0;

        public Game1 Game { get; set; }

        public FireBallThrow(Game1 game, IEntity avatar)
        {
            this.Avatar = avatar;
            ((AvatarMain)Avatar).AccelX = 0;
            //avatar.Velocity = Vector2.Zero;
            Game = game;
            this.Avatar.CurrentSprite = AvatarFactory.FireBallThrowingAvatar(Game, Avatar.Name);

            // Avatar.CurrentSprite.Position = avatar.EntityPosition;
        }
        public void Punch(int type)
        {

        }


        public void GoRight(int type)
        {

            if (type == 0)
            {
                //Here for when we use button held
                //((AvatarMain)Avatar).AccelX = .1f;

                //For button held, we will need to always return a walking state
                if (!Avatar.FacingRight)
                {
                    Avatar.FacingRight = true;
                    Avatar.CurrentActionState = new WalkingState(Game, Avatar);
                }
                else
                {
                    // Avatar.Velocity = new Vector2(1,Avatar.Velocity.Y);

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
                if (Avatar.Velocity.Y == 0)
                {
                    Avatar.Velocity = new Vector2(Avatar.Velocity.X, -3.5f);
                    Avatar.CurrentActionState = new JumpState(Game, Avatar,false);
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
        public void Stun()
        {
            Avatar.CurrentActionState = new StunState(Game, Avatar);
        }

        public void Update(GameTime time)
        {
            if (time != null)
            {
                Elapse += time.ElapsedGameTime.Milliseconds;
                if (Elapse > 300)
                {
                    Avatar.CurrentActionState = new IdleState(Game, Avatar);
                }
            }
        }
    }
}
