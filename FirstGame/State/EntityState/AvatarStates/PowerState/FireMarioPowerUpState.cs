using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Sounds;

namespace FirstGame
{
    class FireMarioPowerUpState : IPowerUpState
    {

        private IEntity Avatar;
        private AvatarMain ava;
        

        public Game1 Game { get; set; }

        public FireMarioPowerUpState(Game1 game, IEntity avatar)
        {
            this.Avatar = avatar;
            this.ava = (AvatarMain)avatar;
            Avatar.CurrentActionState.Update(null);
            Game = game;
            SoundManager.PlaySound("powerup");
            ava.FireBallLeft += 5;

        }

        public IPowerUpState PromoteMario()
        {
            if (Avatar.CurrentActionState is CrouchState)
            {
                Avatar.Position = new Vector2(Avatar.Position.X, Avatar.Position.Y - 9);
                Avatar.CurrentActionState = new IdleState(Game, Avatar);
            }
            return new SmallMarioPowerUpState(Game, Avatar);
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
    }
}
