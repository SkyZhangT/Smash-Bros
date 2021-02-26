using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;

namespace FirstGame
{
    class StarMarioPowerUpState : IPowerUpState, IState
    {

        private IEntity Avatar;

        public Game1 Game { get; set; }
        //public IPowerUpState LastState { get; set; }
        public IEntity Entity { get; set; }

        public StarMarioPowerUpState(Game1 game, IEntity avatar)
        {
            this.Avatar = avatar;
            Game = game;

        }

        public IPowerUpState PromoteMario()
        {
            if (Avatar.CurrentActionState is CrouchState)
            {
                Avatar.Position = new Vector2(Avatar.Position.X, Avatar.Position.Y - 9);
                Avatar.CurrentActionState = new IdleState(Game, Avatar);
            }
            return new Shrinking(Game, Avatar);
        }

        public IPowerUpState PromoteSuperMario()
        {
            return new SuperMarioPowerUpState(Game, Avatar);
        }

        public IPowerUpState PromoteFireMario()
        {
            return new FireMarioPowerUpState(Game, Avatar);
        }

        public IPowerUpState Hit()
        {
            if (Avatar.CurrentActionState is CrouchState)
            {
                Avatar.Position = new Vector2(Avatar.Position.X, Avatar.Position.Y - 9);
                Avatar.CurrentActionState = new IdleState(Game, Avatar);
            }
            return new Shrinking(Game, Avatar);
        }

        public IState PromoteStarMario()
        {
            return new StarMarioPowerUpState(Game, Avatar);
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
