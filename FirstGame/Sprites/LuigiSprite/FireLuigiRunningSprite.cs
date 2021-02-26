using Microsoft.Xna.Framework;
using Sprint0.Sprites;

namespace FirstGame
{
    class FireLuigiRunningSprite : AnimatedSprite
    {
        bool FD;
        public FireLuigiRunningSprite()
        {
            AnimationFrame = 3;
            this.FD = true;
            this.TimeSinceLastFrame = 0;
        }
        public override void UpdateSprite(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;
                if (FD)
                {
                    AnimationFrame += 1;
                }
                else
                {
                    AnimationFrame -= 1;
                }

                if (AnimationFrame == 5 || AnimationFrame == 3)
                {
                    FD = !FD;
                }

                CurrentFrame = new Point(AnimationFrame % SheetSize.X, AnimationFrame / SheetSize.X);
            }
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

        }
    }
}