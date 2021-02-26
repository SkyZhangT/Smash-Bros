using Microsoft.Xna.Framework;
using Sprint0.Sprites;

namespace FirstGame
{
    class FireBallSprite : AnimatedSprite
    {


        public FireBallSprite()
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
