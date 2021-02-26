using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;

namespace FirstGame
{
    class DeadMario : AnimatedSprite
    {

        public DeadMario()
        {
            AnimationFrame = 0;
            JumpDirection = -1;
        }

        public override void UpdateSprite(GameTime gameTime)
        { //Moving postion is not needed
            /*
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
