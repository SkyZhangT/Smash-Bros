using Microsoft.Xna.Framework;
using Sprint0.Sprites;

namespace FirstGame
{
    class Fireworks : AnimatedSprite
    {


        public Fireworks()
        {
        }

        public override void UpdateSprite(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;
                CurrentFrame = new Point(CurrentFrame.X + 1, CurrentFrame.Y);
            }
        }
    }
}
