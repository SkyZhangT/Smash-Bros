using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.State;
using System;

namespace FirstGame
{
    class RunningState : IActionState, IState
    {

        private IEntity Avatar;
        public IEntity Entity { get; set; }

        public Game1 Game { get; set; }

        public RunningState(Game1 game, IEntity avatar)
        {
            this.Avatar = avatar;

            Game = game;

            Update(null);

            //when sprite is created, move its position to avator's position
            //Avatar.CurrentSprite.Position = avatar.EntityPosition;
        }



        public void GoRight()
        {
            if (!Avatar.NeedFlip)
            {
                Avatar.Velocity = new Vector2(0, Avatar.Velocity.Y);
                Avatar.CurrentActionState = new IdleState(Game, Avatar);
            }

            
        }

        public void GoLeft()
        {
            if (Avatar.NeedFlip)
            {
                Avatar.Velocity = new Vector2(0,Avatar.Velocity.Y);
                Avatar.CurrentActionState = new IdleState(Game, Avatar);
            }

            
        }


        public void GoDown()
        {
            if (!(Avatar.CurrentPowerState is SmallMarioPowerUpState))
            {
                Avatar.Position = new Vector2(Avatar.Position.X, Avatar.Position.Y + 9);
                Avatar.CurrentActionState = new CrouchState(Game, Avatar);
            }
            
        }


        public void GoUp()
        {
            Avatar.CurrentActionState = new JumpState(Game, Avatar);
        }

        public void Update(GameTime time)
        {
            if (Avatar.CurrentPowerState is DeadMarioPowerUpState)
            {
                Avatar.CurrentSprite = MarioFactory.DeadMarioFactory(Game);
                Avatar.CurrentSprite.Top = new Vector2(Avatar.Position.X, Avatar.Position.Y - 20);
            }
            else if (Avatar.CurrentPowerState is SmallMarioPowerUpState && !Avatar.NeedFlip)
            {
                Avatar.CurrentSprite = MarioFactory.SmallMarioRunningLeftFactory(Game);
            }
            else if (Avatar.CurrentPowerState is SmallMarioPowerUpState)
            {
                Avatar.CurrentSprite = MarioFactory.SmallMarioRunningRightFactory(Game);
            }
            else if (Avatar.CurrentPowerState is SuperMarioPowerUpState && !Avatar.NeedFlip)
            {
                Avatar.CurrentSprite = MarioFactory.SuperMarioRunningLeftFactory(Game);
            }
            else if (Avatar.CurrentPowerState is SuperMarioPowerUpState)
            {
                Avatar.CurrentSprite = MarioFactory.SuperMarioRunningRightFactory(Game);
            }
            else if (Avatar.CurrentPowerState is FireMarioPowerUpState && !Avatar.NeedFlip)
            {
                Avatar.CurrentSprite = MarioFactory.FireMarioRunningLeftFactory(Game);
            }
            else if (Avatar.CurrentPowerState is FireMarioPowerUpState)
            {
                Avatar.CurrentSprite = MarioFactory.FireMarioRunningRightFactory(Game);
            }
        }
        
        public String StateName()
        {
            return "RunningState";
        }

        //Does this need to be used?
        /* public MarioAvatar GetAvatar()
         {
             return this.Avatar;
         }*/
    }
}
