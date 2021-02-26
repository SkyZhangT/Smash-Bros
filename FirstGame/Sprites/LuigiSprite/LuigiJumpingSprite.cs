using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;

namespace FirstGame
{
    class LuigiJumpingSprite : AnimatedSprite
    {
        public LuigiJumpingSprite()
        {
            AnimationFrame = 0;
            JumpDirection = -1;
        }

        public override void UpdateSprite(GameTime gameTime)
        {
            /* moving position is not needed in sprint 1
             * 
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                
                TimeSinceLastFrame -= MillisecondsPerFrame;
                if (Position.Y < Top.Y)
                {
                    JumpDirection = 1;
                }
                else if (Position.Y > Ground.Y)
                {
                    JumpDirection = 0;
                }
                Position = new Vector2(Position.X, Position.Y + JumpDirection);
            }

            */



        }
    }
}
