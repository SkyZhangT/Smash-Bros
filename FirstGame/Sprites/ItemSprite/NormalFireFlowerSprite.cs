using Microsoft.Xna.Framework;
using Sprint0.Sprites;

namespace FirstGame
{
    class NormalFireFlowerSprite : AnimatedSprite
    {
        
        public NormalFireFlowerSprite()
        {
            AnimationFrame = 18;

            this.TimeSinceLastFrame = 0;
        }

        public override void UpdateSprite(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            CurrentFrame = new Point(AnimationFrame % SheetSize.X, AnimationFrame / SheetSize.X);

            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;
                if (this.AnimationFrame == 21)
                {
                    this.AnimationFrame = 18;
                }
                else this.AnimationFrame++;

            }
        }
    }
}
