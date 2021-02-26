using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Sounds;
using Sprint0.State;
using System;

namespace FirstGame
{
    //public delegate void LifeConsumingEventHandler();

    class DeadMarioPowerUpState : IPowerUpState, IState
    {
        //public event LifeConsumingEventHandler LifeConsumingEvent;

        public IEntity Entity { get; set; }

        private IEntity Avatar;

        public Game1 Game { get; set; }
 

        public DeadMarioPowerUpState(Game1 game, IEntity avatar)
        {

            Avatar = avatar;
            if(Avatar is MarioAvatar)
                Avatar.CurrentActionState = new DeadState(game, avatar);
            else
            {
                Avatar.CurrentActionState = new TurtleDeadState(game, avatar);
            }
            SoundManager.PlaySound("dead");

            Game = game;
            //LifeConsumingEvent += new LifeConsumingEventHandler(Game.GameStateTransition.LifeConsuming);

            //game.AvatorLife--;
            if (game.CurrentScene.PlayerAvatar == this.Avatar)
            {
                game.CurrentScene.IndicatorManager.Lives.lives--;
            }
            else
            {
                game.CurrentScene.IndicatorManager2.Lives.lives--;
            }
            

            //if (LifeConsumingEvent != null)
            //{
            //    LifeConsumingEvent();
            //}

        }

        public IPowerUpState PromoteMario()
        {
            Avatar.CurrentActionState = new IdleState(Game, Avatar);
            return new SmallMarioPowerUpState(Game, Avatar);
        }

        public IPowerUpState PromoteSuperMario()
        {
            Avatar.CurrentActionState = new IdleState(Game, Avatar);

            return new SuperMarioPowerUpState(Game, Avatar);
        }

        public IPowerUpState PromoteFireMario()
        {
            Avatar.CurrentActionState = new IdleState(Game, Avatar);

            return new FireMarioPowerUpState(Game, Avatar);
        }

        public IPowerUpState Hit()
        {
            return new DeadMarioPowerUpState(Game, Avatar);
        }
        public void Update(GameTime time)
        {
            
        }
        public IState PromoteStarMario()
        {
            return new StarMarioPowerUpState(Game, Avatar);
        }
    }
}
