using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.State.BlockStates;

namespace Sprint0.Game_Enities.Blocks
{
    public class PlatformEntity :BlockEntity
    {
        public PlatformEntity(Game1 game, string name, Vector2 position, Vector2 tPosition) : base(game, name, position, tPosition)
        {
            Position = position;
            Game = game;
            Name = name;
            TPosition = tPosition;
            CoinLeft = -1;
            Visible = true;
            Indicator = Color.White;
            HitBoxColor = Color.Blue;
        }

        public override void Initialize()
        {
            Collision = new BlockCollision(this);
            CurrentState = new StaticBlockState(Game, this);
        }

        public override void UpdateEntity(GameTime gameTime)
        {
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, CurrentSprite.FrameSize.X, CurrentSprite.FrameSize.Y);

            if (Indicator == Color.Brown)
            {
                TimeElapsed += gameTime.ElapsedGameTime.Milliseconds;
                if (TimeElapsed >= TimeDelay)
                {
                    Indicator = Color.White;
                    TimeElapsed = 0;
                }
            }
        }
    }
}
