using Microsoft.Xna.Framework;
using Sprint0.Sprites;

namespace FirstGame
{
    class CoinBox : AnimatedSprite
    {
        bool FD { get; set; }
        public CoinBox()
        {
            AnimationFrame = 0;
            FD = true;
            TimeSinceLastFrame = 0;
        }

        public override void UpdateSprite(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;
                if (FD)
                {
                    AnimationFrame++;
                }
                else
                {
                    AnimationFrame--;
                }

                if (AnimationFrame == 2 || AnimationFrame==0)
                {
                    FD=!FD;
                }

                CurrentFrame = new Point(AnimationFrame % SheetSize.X, AnimationFrame / SheetSize.X);
            }
        }
    }
}
