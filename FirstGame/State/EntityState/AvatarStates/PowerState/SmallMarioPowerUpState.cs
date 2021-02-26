using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;

namespace FirstGame
{
    class SmallMarioPowerUpState : IPowerUpState
    {



        private IEntity Avatar;

        public Game1 Game { get; set; }

        public SmallMarioPowerUpState(Game1 game, IEntity avatar)
        {
            this.Avatar = avatar;
            if(avatar is MarioAvatar)
                Avatar.Position = new Vector2(Avatar.Position.X, Avatar.Position.Y + 16);
            Avatar.CurrentActionState.Update(null);
            Game = game;

        }


        public IPowerUpState PromoteMario()
        {
            Avatar.Position = new Vector2(Avatar.Position.X, Avatar.Position.Y - 16);
            return new SmallMarioPowerUpState(Game, Avatar);
        }

        public IPowerUpState PromoteSuperMario()
        {
            if(Avatar is MarioAvatar)
                Avatar.Position = new Vector2(Avatar.Position.X, Avatar.Position.Y - 17);
            Avatar.HitBox = new Rectangle((int)Avatar.Position.X + 3, (int)Avatar.Position.Y + 2, Avatar.CurrentSprite.FrameSize.X - 6, Avatar.CurrentSprite.FrameSize.Y - 4);
            return new Growing(Game, Avatar);
        }

        public IPowerUpState PromoteFireMario()
        {
            if(Avatar is MarioAvatar)
                Avatar.Position = new Vector2(Avatar.Position.X, Avatar.Position.Y - 16);
            return new FireMarioPowerUpState(Game, Avatar);

        }

        public IPowerUpState Hit()
        {
            if (Avatar is MarioAvatar)
                Avatar.Position = new Vector2(Avatar.Position.X, Avatar.Position.Y - 16);
            ((AvatarMain)Avatar).AccelX = 0;
            Avatar.Velocity = new Vector2(0, -3);
            if(Avatar is MarioAvatar)
            {
                Avatar.CurrentActionState = new DeadState(Game, Avatar);
            }
            else
            {
                Avatar.CurrentActionState = new TurtleDeadState(Game, Avatar);
            }
            return new DeadMarioPowerUpState(Game, Avatar);
        }
        public IState PromoteStarMario()
        {
            return new StarMarioPowerUpState(Game, Avatar);
        }
    }
}
