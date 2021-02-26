using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Sounds;
using Sprint0.State;
using System;

namespace FirstGame
{
    class TurtlePunchState : IActionState, IState
    {
        private IEntity Avatar;
        public IEntity Entity { get; set; }
        
        public Game1 Game { get; set; }

        private int punchTime;
       // private int punchStateADuration = 10;
        private int punchDuration = 20;


        public TurtlePunchState(Game1 game, IEntity avatar)
        {
            this.Avatar = avatar;
            Avatar.Indicator = Color.White;
            this.punchTime = 0;
            Avatar.Position = new Vector2(Avatar.Position.X, Avatar.Position.Y + 9);
            Game = game;
            //((TurtleAvatar)Avatar).Damage += 2;
        }

        public void Punch(int type)
        {
            
        }
        public void Stun()
        {
            Avatar.Position = new Vector2(Avatar.Position.X, Avatar.Position.Y - 9);
            Avatar.CurrentActionState = new TurtleStunState(Game, Avatar);
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
                if (this.punchTime > this.punchDuration)
                {
                    Avatar.Position = new Vector2(Avatar.Position.X, Avatar.Position.Y - 9);

                    if (this.Avatar.Velocity.Y != 0)
                    {
                        Avatar.CurrentActionState = new TurtleJumpState(Game, Avatar);
                    }
                    else
                    {
                        Avatar.CurrentActionState = new TurtleIdleState(Game, Avatar);
                    }
                }
                else
                {
                    if (Avatar.CurrentPowerState is DeadMarioPowerUpState)
                    {
                        Avatar.CurrentSprite = MarioFactory.GreenDeadKoopa(Game);
                        Avatar.CurrentSprite.Top = new Vector2(Avatar.Position.X, Avatar.Position.Y - 20);
                    }

                    if (Avatar.FacingRight)
                    {
                        Avatar.Velocity = new Vector2(2, 0);
                    }
                    else
                    {
                        Avatar.Velocity = new Vector2(-2, 0);
                    }
                    if (Avatar.CurrentPowerState is FireMarioPowerUpState)
                    {
                        Avatar.CurrentSprite = MarioFactory.BlueKoopaShell(Game);
                    }
                    else if (Avatar.CurrentPowerState is SuperMarioPowerUpState)
                    {
                        Avatar.CurrentSprite = MarioFactory.RedKoopaShell(Game);
                    }
                    else if (Avatar.CurrentPowerState is SmallMarioPowerUpState)
                    {
                        Avatar.CurrentSprite = MarioFactory.GreenKoopaShell(Game);
                    }
                    
                }
            

        }
    }
}
